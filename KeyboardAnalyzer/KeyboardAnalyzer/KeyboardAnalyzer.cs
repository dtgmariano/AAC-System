using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzer
{
    public static class KeyboardAnalyzer
    {
        public static int calculateTimeToWrite(KeyboardModel km, Word word)
        {
            int sum=0;
            for (int i = 0; i < word.normalized_content.Length; i++)
            {
                Key k = km.keys.Find(x => x.content.Equals(word.normalized_content[i].ToString()));
                sum += (k.col + k.row + k.block);
            }

            return sum;
        }

        public static int indexAtDictionary(LanguageDictionaryModel ld, Word word)
        {
            int pos = 0;

            return pos;
        }
    }
}
