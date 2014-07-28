using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardPerformanceAnalyzer
{
    public static class ImportData
    {
        /**/
        public static List<WordModel> getListofWords(string dictionaryFile)
        {
            var lDictionary = new List<WordModel>();

            using (StreamReader reader = new StreamReader(dictionaryFile, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] info = line.Split();

                    if (!lDictionary.Exists(x => x.content.Equals(info[1])))
                        lDictionary.Add(new WordModel(info[0], Convert.ToInt32(info[1]),info[2]));
                }
            }
            //lDictionary = lDictionary.OrderBy(x => x.rank).ToList();
            //lDictionary = lDictionary.OrderBy(x => x.content).ToList();
            return lDictionary;
        }

        /**/
        public static List<string> getKeysConfiguration(string keysConfigurationFilePath)
        {
            Dictionary<string,int> table = new Dictionary<string,int>();

            try
            {
                using (StreamReader reader = new StreamReader(keysConfigurationFilePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] info = line.Split();
                        table.Add(info[0],Convert.ToInt16(info[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            var keys = table.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
            return keys;
        }


        public static Dictionary<string, int> getKeyboardConfiguration(string keysConfigurationFilePath)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();
            int countline = 0;

            try
            {
                using (StreamReader reader = new StreamReader(keysConfigurationFilePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] info = line.Split();
                        for (int i = 0; i < info.Length; i++)
                        {
                            table.Add(info[i],(countline + i + 1));
                        }

                        countline++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //var listKeys = table.Select(kvp => kvp.Key).ToList();
            //var listWeights = table.Select(kvp => kvp.Value).ToList();

            return table;
        }
    }
}
