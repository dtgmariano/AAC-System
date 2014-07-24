using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzer
{
    public static class LanguageDictionaryAnalyzer
    {
        public static List<Word> getSugestions(List<Word> dictionaryWords, string input)
        {
            List<Word> sugestions;
            sugestions = dictionaryWords.Where(x => x.normalized_content.StartsWith(input)).ToList();
            return sugestions;
        }

        public static List<Word> getT4Sugestions(List<Word> dictionaryWords, string input)
        {
            List<Word> sugestions;
            sugestions = dictionaryWords.Where(x => x.t4crypt.StartsWith(input)).ToList();
            return sugestions;
        }

        public static List<Word> getT9Sugestions(List<Word> dictionaryWords, string input)
        {
            List<Word> sugestions;
            sugestions = dictionaryWords.Where(x => x.t9crypt.StartsWith(input)).ToList();
            return sugestions;
        }

        public static List<Word> getT14Sugestions(List<Word> dictionaryWords, string input)
        {
            List<Word> sugestions;
            sugestions = dictionaryWords.Where(x => x.t14crypt.StartsWith(input)).ToList();
            return sugestions;
        }
    }
}
