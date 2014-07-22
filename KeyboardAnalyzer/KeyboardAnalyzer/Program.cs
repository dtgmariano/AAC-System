using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyboardModelFile = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzer\\KeyboardAnalyzer\\Data\\keyboard_model_1a.txt";
            string dictionaryFile = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzer\\KeyboardAnalyzer\\Data\\dictionary_freq_pt_br.txt";

            LanguageDictionaryModel dict = new LanguageDictionaryModel(dictionaryFile);
            Word wd = new Word("procurar");
            KeyboardModel km = new KeyboardModel(keyboardModelFile);
            
            Console.WriteLine(KeyboardAnalyzer.calculateTimeToWrite(km, wd));

            dict.organizeDictionaryByFrequency();

            for (int i = 0; i < wd.normalized_content.Length; i++)
            {
                string prefix = wd.normalized_content.Substring(0, (i + 1));
                List<Word> sugestions = LanguageDictionaryAnalyzer.getSugestions(dict.words, prefix);
                int idx = sugestions.FindIndex(p => p.normalized_content.Equals(wd.normalized_content));
                Console.WriteLine(i + ")  index at sugestion list: " + idx);
            }

            //dict.organizeDictionaryByFrequency();
            //for (int i = 0; i < wd.normalized_content.Length; i++)
            //{
            //    string prefix = wd.normalized_content.Substring(0, (i+1));
            //    List<Word> sugestions = LanguageDictionaryAnalyzer.getSugestions(dict.words, prefix);
            //}
        }
    }
}
