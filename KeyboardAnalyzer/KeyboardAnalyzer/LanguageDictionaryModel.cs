using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardAnalyzer
{
    public class LanguageDictionaryModel
    {
        public List<Word> words;

        public LanguageDictionaryModel(string dictionaryFile)
        {
            words = loadDictionary(dictionaryFile);
        }

        public List<Word> loadDictionary(string dictionaryFile)
        {
            List<Word> dict = new List<Word>();
            using (StreamReader reader = new StreamReader(dictionaryFile, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] info = line.Split();
                    dict.Add(new Word(info[2], Convert.ToInt16(info[0])));
                }
            }
            return dict;
        }

        public List<Word> organizeDictionaryByFrequency()
        {
            return words.OrderBy(o => o.frequency).ToList();
        }

        public List<Word> organizeDictionaryByAlphabeticOrder()
        {
            return words.OrderBy(o => o.normalized_content).ToList();
        }

        public List<Word> organizedictionaryByT9Code()
        {
            return words.OrderBy(o => o.t9crypt).ToList();
        }

        public List<Word> organizedictionaryByT4Code()
        {
            return words.OrderBy(o => o.t4crypt).ToList();
        }

        public List<Word> organizedictionaryByT14Code()
        {
            return words.OrderBy(o => o.t14crypt).ToList();
        }
    }
}
