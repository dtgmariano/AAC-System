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
    }
}
