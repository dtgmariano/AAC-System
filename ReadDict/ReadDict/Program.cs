using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ReadDict
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pathFile = "C:\\Users\\Daniel\\GitHub\\AAC-System\\Dictionary_Data\\freqDictPort\\";
                string openFileName = "file2.txt";
                string csvFileName = "out.csv";

                List<Word> myDictionary = Interpreter.extractDictionary(pathFile + openFileName);       //creates a list of Words
                Interpreter.generateCSV(csvFileName, myDictionary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally
            {
                Console.WriteLine("");
            }
            
        }

        

        
    }

    
}
