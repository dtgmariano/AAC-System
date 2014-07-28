using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public static class KeyboardProcessor
    {
        //public static List<int> scores = new List<int>() { 1, 2, 3, 4, 5, 
        //                                                   2, 3, 4, 5, 6, 
        //                                                   3, 4, 5, 6, 7, 
        //                                                   4, 5, 6, 7, 8,
        //                                                   5, 6, 7, 8,
        //                                                   6, 7, 8};

        /**/
        //public static List<string> generateListKeys()
        //{
        //    return (new List<string>(){ "a","b","c","d","e",
        //                                "f","g","h","i","j",
        //                                "k","l","m","n","o",
        //                                "p","q","r","s","t",
        //                                "u","v","x","-",
        //                                "y","w","z"});
        //}

        /**/
        //public static List<string> generateListKeys(Random _rand)
        //{
        //    return (new List<string>(){ "a","b","c","d","e",
        //                                "f","g","h","i","j",
        //                                "k","l","m","n","o",
        //                                "p","q","r","s","t",
        //                                "u","v","x","-",
        //                                "y","w","z"}.OrderBy(a => Guid.NewGuid()).ToList());
        //}

        /**/
        //public static List<string> organizeDistributionOfKeys(List<string> keys)
        //{
        //    List<int> seq = new List<int>(){1,	2,	4,	7,	11,
        //                                    3,	5,	8,	12,	16,
        //                                    6,	9,	13,	17,	21,
        //                                    10,	14,	18, 22,	25,
        //                                    15,	19,	23,	26,	
        //                                    20,	24,	27};

        //    List<string> organizedKeys = new List<string>();
        //    foreach (int i in seq)
        //    {
        //        organizedKeys.Add(keys[i-1]);
        //    }

        //    return organizedKeys;
        //}

        /**/
        public static int calculatesTheEffortToWriteAInput(KeyboardModel keyboard, string input)
        {
            var a1 = input.Select(x => x.ToString());
            var a2 = a1.Select(k => keyboard.keys.IndexOf(k));
            var a3 = a2.Select(k => keyboard.weights[k]);
            var a4 = a3.Sum();
            return a4;
            //return input.Select(x => x.ToString()).Select(k => keyboard.keys.IndexOf(k)).Select(k => scores[k]).Sum();
        }

        /**/
        public static Dictionary<WordModel, int> calculatesTheEffortToWriteADictionary(KeyboardModel km, DictionaryModel dictionary)
        {
            var a = dictionary.wordsList.Select(x => x).ToList();
            var b = a.Select((k, i) => new { k, i = calculatesTheEffortToWriteAInput(km, k.abrev) });
            var c = b.ToDictionary(x => x.k, x => x.i);

            return c;
        }


        

    }
}
