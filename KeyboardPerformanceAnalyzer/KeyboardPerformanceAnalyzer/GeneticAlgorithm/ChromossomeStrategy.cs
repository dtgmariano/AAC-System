using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public static class ChromossomeStrategy
    {
        public static List<int> scores = new List<int>() { 1, 2, 3, 4, 5, 
                                                           2, 3, 4, 5, 6, 
                                                           3, 4, 5, 6, 7, 
                                                           4, 5, 6, 7, 8,
                                                           5, 6, 7, 8,
                                                           6, 7, 8};

        /**/
        public static List<string> generateRandomListKeys(Random _rand)
        {
            return (new List<string>(){ "a","b","c","d","e",
                                        "f","g","h","i","j",
                                        "k","l","m","n","o",
                                        "p","q","r","s","t",
                                        "u","v","x","-",
                                        "y","w","z"}.OrderBy(a => Guid.NewGuid()).ToList());
        }

        /**/
        public static List<string> generateSequencialListKeys(Random _rand)
        {
            return (new List<string>(){ "a","b","c","d","e",
                                        "f","g","h","i","j",
                                        "k","l","m","n","o",
                                        "p","q","r","s","t",
                                        "u","v","x","-",
                                        "y","w","z"});
        }

        /**/
        public static double calculatesFitness()
        {

            return 0.0;
        }
    }
}
