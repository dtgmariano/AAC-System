using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardAnalyzerWithGA
{
    public class DictionaryModel
    {
        public Dictionary<string, int> dict; /*Key: Word || Value: Word's frequency at the specific language */
        //public Dictionary<string, string> tableNecessaryInputs;
        //public Dictionary<string, int> tableNecessaryEffort;

        /* Constructor
         * Initializes the class based on the .txt file
         * to load the dictionary the hasFrequency bool
         * argument establish if the dictionary will
         * consider word's frequency or not
         */
        public DictionaryModel(string dictionaryFile, bool hasFrequency)
        {
            dict = loadDictionary(dictionaryFile, hasFrequency);

        }

        /* Function that read an .txt file to populate the dictionary object 
         * as a Dictionary<string, int> class where:
         * Key = Content || Value = Word frequency
         */
        public static Dictionary<string, int> loadDictionary(string dictionaryFile, bool hasFrequency)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(dictionaryFile, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] info = line.Split();
                    if (!dict.ContainsKey(info[1]))
                        dict.Add(info[1], Convert.ToInt16(info[0]));
                }
            }

            //set all key's values to 1 -> uniform frequency
            if (!hasFrequency)
            {
                dict = dict.ToDictionary(p => p.Key, p => 1);
            }

            return dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        
    }
}
