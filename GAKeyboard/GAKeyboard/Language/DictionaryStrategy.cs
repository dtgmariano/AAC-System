using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GAKeyboard.Language
{
    public static class DictionaryStrategy
    {
        public static List<Word> getDictionary(string dictionaryFile)
        {
            var lDictionary = new List<Word>();

            using (StreamReader reader = new StreamReader(dictionaryFile, Encoding.UTF8))
            {
                string line;
                /*File format: word\trank\tprefix*/
                while ((line = reader.ReadLine()) != null)
                {
                    String[] info = line.Split();

                    if (!lDictionary.Exists(x => x.content.Equals(info[1])))
                        lDictionary.Add(new Word(info[0], Convert.ToInt32(info[1]), info[2]));
                }
            }

            return lDictionary;
        }
    }
}
