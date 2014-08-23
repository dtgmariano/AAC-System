using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GAKeyboard.Language;

namespace GAKeyboard.Modules
{
    public class DictionaryAnalyzer
    {
        static string dictionaryFilePath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\GAKeyboard\\GAKeyboard\\Data\\portuguese_dictionary_of_frequency.txt";
        Dictionary myDictionary;
        Dictionary<string, int> charactersFrequencyTable;

        public DictionaryAnalyzer()
        {
            myDictionary = new Dictionary(dictionaryFilePath, true);
            charactersFrequencyTable = getCFTable(this.myDictionary);
            "".ToString();
            //myDictionary = new Dictionary(getDictionary(dictionaryFilePath), _rank;
        }

        public Dictionary<string, int> getCFTable(Dictionary _myDictionary)
        {
            var listAbrev = _myDictionary.wordsList.Select(e => e.content).ToList();

            var charactersFrequency = new List<string>(){ "a","b","c","d","e",
                                                    "f","g","h","i","j",
                                                    "k","l","m","n","o",
                                                    "p","q","r","s","t",
                                                    "u","v","x","-",
                                                    "y","w","z"}.ToDictionary(x => x, y => 0);
            foreach (string s in listAbrev)
            {
                foreach (char c in s)
                {
                    charactersFrequency[c.ToString()]++;
                }
            }


            return charactersFrequency;
        }

    }
}
