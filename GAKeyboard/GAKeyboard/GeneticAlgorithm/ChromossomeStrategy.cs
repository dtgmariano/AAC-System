using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAKeyboard.Language;

namespace GAKeyboard.GeneticAlgorithm
{
    public static class ChromossomeStrategy
    {
        //public static List<object> keys = new List<object>(){ "a","b","c","d","e",
        //                                               "f","g","h","i","j",
        //                                               "k","l","m","n","o",
        //                                               "p","q","r","s","t",
        //                                               "u","v","x","w","y",
        //                                               "z","-","1","2","3"};

        //static List<double> weights = new List<double>(){1, 2, 3, 4, 5, 
        //                                                 2, 3, 4, 5, 6, 
        //                                                 3, 4, 5, 6, 7, 
        //                                                 4, 5, 6, 7, 8, 
        //                                                 5, 6, 7, 8, 9, 
        //                                                 6, 7, 8, 9, 10 };

        public static List<object> keys = new List<object>(){"a","b","c","d","e",
                                                           "f","g","h","i","j",
                                                           "k","l","m","n","o",
                                                           "p","q","r","s","t",
                                                           "u","v","x","w","y",
                                                           "z","-"};

        static List<double> weights = new List<double>(){1,2,2,3,3,
                                                         3,4,4,4,4,
                                                         5,5,5,5,5,
                                                         6,6,6,6,6,
                                                         7,7,7,7,8,
                                                         8,8};

        public static bool validateChromossome(Chromossome _chromossome)
        {
            bool isValid = false;
            var isNotInChromossomeGene = _chromossome.aleles.Except(keys);

            if (isNotInChromossomeGene.Count() == 0)
               isValid = true;
            else
            {
                Console.WriteLine("AQUI");
            }

            return isValid;
        }

        public static List<object> genSequencyOfChars()
        {
            return keys.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public static double getFitness(Dictionary<Word,double>tableOfEffort)
        {
            //var b = tableOfEffort.ToDictionary(p => p.Key, p => p.Value / p.Key.rank);
            //var c = b.Sum(v => v.Value);
            //return c;

            return tableOfEffort.ToDictionary(p => p.Key, p => p.Value / p.Key.rank).Sum(v => v.Value);
        }


        /*A table of effort to write a dictionary*/
        public static Dictionary<Word, double> getTableOfEffortToWriteADictionary(List<object> aleles, List<double> weights, Dictionary dictionary)
        {
            //var a = dictionary.wordsList.Select(x => x).ToList();
            //var b = a.Select((k, i) => new { k, i = calculatesTheEffortToWriteAInput(aleles, weights, k.prefix) });
            //var c = b.ToDictionary(x => x.k, x => x.i);

            //return c;

            return dictionary.wordsList.Select(x => x).ToList().Select((k, i) => new { k, i = calculatesTheEffortToWriteAInput(aleles, weights, k.prefix) }).ToDictionary(x => x.k, x => x.i);
        }

        public static double calculatesTheEffortToWriteAInput(List<object> aleles, List<double> weights, string input)
        {

            //var a1 = input.Select(x => x.ToString());
            //var a2 = a1.Select(k => aleles.IndexOf(k));
            //var a3 = a2.Select(k => weights[k]);
            //var a4 = a3.Sum();

            //return a4;

            return input.Select(x => x.ToString()).Select(k => aleles.IndexOf(k)).Select(k => weights[k]).Sum();
            
        }


        
    }
}
