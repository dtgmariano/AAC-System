using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ReadDict
{
    class Interpreter
    {
        public static List<Word> extractDictionary(string _inputFile)
        {
            List<Word> myDictionary = new List<Word>();
            List<string> dataInput = readFile(_inputFile);

            for (int i = 0; i < dataInput.Count; i++)
            {
                if (isNumeric(dataInput[i][0]))
                {
                    int firstspace = dataInput[i].IndexOf(' ');
                    string idx = dataInput[i].Substring(0, firstspace);

                    if (isNumber(idx))
                    {
                        int index = Convert.ToInt32(idx);
                        int size = dataInput[i].Length - firstspace - 1;
                        dataInput[i] = dataInput[i].Substring(firstspace + 1, size);
                        int secondspace = dataInput[i].IndexOf(' ');
                        string word = dataInput[i].Substring(0, secondspace);
                        myDictionary.Add(new Word(index, word));
                    }
                }
            }
            
            myDictionary = myDictionary.OrderBy(o => o.index).ToList();
            return myDictionary;
        }

        public static bool isNumeric(char firstchar) //firstCharInTheLine
        {
            var numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool contains = numbers.Contains(firstchar);
            return contains;
        }

        public static bool isNumber(string index)
        {
            var numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool itIsANumber = true;
            for (int i = 0; i < index.Length; i++)
            {
                if (!numbers.Contains(index[i]))
                    itIsANumber = false;
                break;
            }
            return itIsANumber;
        }

        public static List<string> readFile(string inputFileName)
        {
            List<string> fileLines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(inputFileName, Encoding.Default))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        fileLines.Add(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            

            return fileLines;
        }

        public static void generateCSV(string outputPath, List<Word> _myDictionary)
        {
            try
            {
                var csv = new StringBuilder();

                foreach (Word w in _myDictionary)
                {
                    string cleanText = w.normalized_content;
                    string originalText = w.content;
                    string t9code = w.t9crypt;
                    string frequency = w.index.ToString();
                    //string separator = ";";
                    string newLine = string.Format("{0};{1};{2};{3}\n", cleanText, originalText, t9code, frequency, Encoding.Default);
                    csv.Append(newLine);
                }

                File.WriteAllText(outputPath, csv.ToString(), Encoding.Default);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            
        }

        public static void writeFileFromListWords(string outputFileName, string separator, List<Word> List)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (Word w in List)
                {
                    writer.WriteLine(w.index + "separator" + w.normalized_content + "separator" + w.content + "separator" + w.t9crypt);
                }
            }
        }
    }
}
