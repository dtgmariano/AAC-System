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
            //normalKeyboard();
            t9Keyboard();
        }

        static void normalKeyboard()
        {
            string keyboardModelFile = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzer\\KeyboardAnalyzer\\Data\\keyboard_model_1a.txt";
            string dictionaryFile = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzer\\KeyboardAnalyzer\\Data\\dictionary_freq_pt_br.txt";

            LanguageDictionaryModel dict = new LanguageDictionaryModel(dictionaryFile);
            //Word wd = new Word("teste");
            KeyboardModel km = new KeyboardModel(keyboardModelFile);

            Console.WriteLine("Type a word");
            string line = Console.ReadLine();

            while (line != null)
            {
                Word wd = new Word(line);

                if (dict.words.Any(p => p.normalized_content.Equals(wd.normalized_content)))
                {

                    dict.words = dict.organizeDictionaryByFrequency();
                    Console.WriteLine("Organized by frequency");
                    for (int i = 0; i < wd.normalized_content.Length; i++)
                    {
                        string prefix = wd.normalized_content.Substring(0, (i + 1));
                        List<Word> sugestions = LanguageDictionaryAnalyzer.getSugestions(dict.words, prefix);
                        int idx = sugestions.FindIndex(p => p.normalized_content.Equals(wd.normalized_content));
                        Console.WriteLine(i + ")  index at sugestion list: " + idx + "\t1st sugestion: " + sugestions[0].normalized_content);
                    }

                    Console.WriteLine("");

                    dict.words = dict.organizeDictionaryByAlphabeticOrder();
                    Console.WriteLine("Organized by alphabetic order");
                    for (int i = 0; i < wd.normalized_content.Length; i++)
                    {
                        string prefix = wd.normalized_content.Substring(0, (i + 1));
                        List<Word> sugestions = LanguageDictionaryAnalyzer.getSugestions(dict.words, prefix);
                        int idx = sugestions.FindIndex(p => p.normalized_content.Equals(wd.normalized_content));
                        Console.WriteLine(i + ")  index at sugestion list: " + idx + "\t1st sugestion: " + sugestions[0].normalized_content);
                    }

                    Console.WriteLine("");

                }

                else
                {
                    Console.WriteLine("Dictionary don't have the word!");
                }

                Console.WriteLine("Type a word");
                line = Console.ReadLine();
            }
        }

        static void t9Keyboard()
        {
            string keyboardModelFile = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzer\\KeyboardAnalyzer\\Data\\keyboard_model_1a.txt";
            string dictionaryFile = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzer\\KeyboardAnalyzer\\Data\\dictionary_freq_pt_br.txt";

            LanguageDictionaryModel dict = new LanguageDictionaryModel(dictionaryFile);
            KeyboardModel km = new KeyboardModel(keyboardModelFile);

            Console.WriteLine("Type a word");
            string line = Console.ReadLine();

            while (line != null)
            {
                Word wd = new Word(line);

                analyzeNormalKeyboardByFrequency(dict, km, wd);
                analyzeT14KeyboardByFrequency(dict, km, wd);
                analyzeT9KeyboardByFrequency(dict, km, wd);
                analyzeT4KeyboardByFrequency(dict, km, wd);
                

                analyzeNormalKeyboardByAlphabetic(dict, km, wd);
                analyzeT14KeyboardByT14Code(dict, km, wd);
                analyzeT9KeyboardByT9Code(dict, km, wd);
                analyzeT4KeyboardByT4Code(dict, km, wd);

                Console.WriteLine("Type a word");
                line = Console.ReadLine();
            }

        }

        static void analyzeNormalKeyboardByFrequency(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.normalized_content.Equals(wd.normalized_content)))
            {

                dict.words = dict.organizeDictionaryByFrequency();
                Console.WriteLine("NK: Organized by frequency");
                for (int i = 0; i < wd.normalized_content.Length; i++)
                {
                    string prefix = wd.normalized_content.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getSugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.normalized_content.Equals(wd.normalized_content));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeNormalKeyboardByAlphabetic(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.normalized_content.Equals(wd.normalized_content)))
            {

                dict.words = dict.organizeDictionaryByAlphabeticOrder();
                Console.WriteLine("NK: Organized by alphabetic order");
                for (int i = 0; i < wd.normalized_content.Length; i++)
                {
                    string prefix = wd.normalized_content.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getSugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.normalized_content.Equals(wd.normalized_content));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeT4KeyboardByFrequency(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.t4crypt.Equals(wd.t4crypt)))
            {

                dict.words = dict.organizeDictionaryByFrequency();
                Console.WriteLine("T4: Organized by frequency");
                for (int i = 0; i < wd.t4crypt.Length; i++)
                {
                    string prefix = wd.t4crypt.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getT4Sugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.t4crypt.Equals(wd.t4crypt));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeT4KeyboardByT4Code(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.t4crypt.Equals(wd.t4crypt)))
            {
                dict.words = dict.organizedictionaryByT4Code();
                Console.WriteLine("T4: Organized by t4 code");
                for (int i = 0; i < wd.t4crypt.Length; i++)
                {
                    string prefix = wd.t4crypt.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getT4Sugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.t4crypt.Equals(wd.t4crypt));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeT9KeyboardByFrequency(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.t9crypt.Equals(wd.t9crypt)))
            {

                dict.words = dict.organizeDictionaryByFrequency();
                Console.WriteLine("T9: Organized by frequency");
                for (int i = 0; i < wd.t9crypt.Length; i++)
                {
                    string prefix = wd.t9crypt.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getT9Sugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.t9crypt.Equals(wd.t9crypt));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeT9KeyboardByT9Code(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.t9crypt.Equals(wd.t9crypt)))
            {
                dict.words = dict.organizedictionaryByT9Code();
                Console.WriteLine("T9: Organized by t9 code");
                for (int i = 0; i < wd.t9crypt.Length; i++)
                {
                    string prefix = wd.t9crypt.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getT9Sugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.t9crypt.Equals(wd.t9crypt));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeT14KeyboardByFrequency(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.t14crypt.Equals(wd.t14crypt)))
            {

                dict.words = dict.organizeDictionaryByFrequency();
                Console.WriteLine("T14: Organized by frequency");
                for (int i = 0; i < wd.t14crypt.Length; i++)
                {
                    string prefix = wd.t14crypt.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getT14Sugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.t14crypt.Equals(wd.t14crypt));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }

        static void analyzeT14KeyboardByT14Code(LanguageDictionaryModel dict, KeyboardModel km, Word wd)
        {
            if (dict.words.Any(p => p.t14crypt.Equals(wd.t14crypt)))
            {
                dict.words = dict.organizedictionaryByT14Code();
                Console.WriteLine("T14: Organized by t14 code");
                for (int i = 0; i < wd.t14crypt.Length; i++)
                {
                    string prefix = wd.t14crypt.Substring(0, (i + 1));
                    List<Word> sugestions = LanguageDictionaryAnalyzer.getT14Sugestions(dict.words, prefix);
                    int idx = sugestions.FindIndex(p => p.t14crypt.Equals(wd.t14crypt));
                    Console.WriteLine(i + ")  index at sugestion list: " + idx + " 1st sugestion: " + sugestions[0].normalized_content);
                }
            }
            else
            {
                Console.WriteLine("There is no such word in your dictionary");
            }
            Console.WriteLine();
        }
    }
}
