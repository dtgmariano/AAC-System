using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardPerformanceAnalyzer
{
    public static class ExportData
    {
        public static bool exportTable(string outputFilePath, List<WordModel> listWords, List<string> wordsInput)
        {
            bool hasSuccess = false;

            try
            {
                if (listWords.Count == wordsInput.Count)
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        for (int i = 0; i < listWords.Count; i++)
                        {
                            writer.WriteLine(listWords[i].content + "\t" + listWords[i].rank + "\t" + wordsInput[i]);
                        }
                    }
                    hasSuccess = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return hasSuccess;
        
        }

        public static bool exportFrequencyOfCharsOfADictionary(string outputFilePath, DictionaryModel dictionary)
        {
            bool hasSuccess = false;

            var a = DictionaryProcessor.countTheFrequencyOfEachCharacter(dictionary);

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach(KeyValuePair<string,int> kvp in a)
                    {
                        writer.WriteLine(kvp.Key + "\t" + kvp.Value);
                    }
                }
                hasSuccess = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hasSuccess;

        }

        public static bool exportKeyboardModelPerformance(string outputFilePath, KeyboardModel keyboard, DictionaryModel dictionary)
        {
            bool hasSuccess = false;

            var a = KeyboardProcessor.calculatesTheEffortToWriteADictionary(keyboard, dictionary);

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(String.Join("", keyboard.keys.ToArray()));

                    foreach (KeyValuePair<WordModel, int> kvp in a)
                        writer.WriteLine(kvp.Key.rank + "\t" + kvp.Key.content + "\t" + kvp.Key.abrev + "\t" + kvp.Value);
                }
                hasSuccess = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return hasSuccess;
        }

        public static bool exportRandomKeyboardConfiguration()
        {
            bool hasSuccess = false;

            var sU = "a b c d e f g h i j k l m n o p q r s t u v x y w z -";
            
            try
            {
                var lU = String.Join("",sU.Split().OrderBy(a => Guid.NewGuid()));
                var filename = "keyboard_configuration_" + lU + ".txt";
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(lU);
                }
                hasSuccess = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return hasSuccess;
        }
    }
}
