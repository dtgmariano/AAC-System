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
                string header;
                string line;

                header = reader.ReadLine();

                switch (header)
                {
                    case "rank\tcontent":
                        /*File format: rank\tcontent */
                        while ((line = reader.ReadLine()) != null)
                        {
                            String[] info = line.Split();

                            if (!lDictionary.Exists(x => x.content.Equals(info[1])))
                                lDictionary.Add(new Word(info[1], Convert.ToInt32(info[0])));
                        }
                        break;

                    case "content\trank\tabrev":
                        /*File format: content\trank\tabrev */
                        while ((line = reader.ReadLine()) != null)
                        {
                            String[] info = line.Split();

                            if (!lDictionary.Exists(x => x.content.Equals(info[1])))
                                lDictionary.Add(new Word(info[0], Convert.ToInt32(info[1]), info[2]));
                        }
                        break;
                }
            }

            return lDictionary;
        }
    }
}
