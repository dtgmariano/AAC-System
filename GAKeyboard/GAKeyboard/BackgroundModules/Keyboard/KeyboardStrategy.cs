using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GAKeyboard.GeneticAlgorithm;
using GAKeyboard.Keyboard;
using GAKeyboard.Language;

namespace GAKeyboard.Keyboard
{
    public static class KeyboardStrategy
    {
        public static List<Keyboard> loadKeyboardList(string filePath, Dictionary _dict)
        {
            List<Keyboard> listOfKeyboards = new List<Keyboard>();

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string header;
              
                while((header = reader.ReadLine()) != null)
                {
                    int countNumOfRows = Convert.ToInt16(reader.ReadLine());

                    List<List<string>> keys = new List<List<string>>();
                    for (int i = 0; i < countNumOfRows; i++)
                    {
                        //var b = string.Join("",reader.ReadLine().Split('\t'));
                        var a = reader.ReadLine().Split().ToList();
                        keys.Add(a);
                    }

                    listOfKeyboards.Add(new Keyboard(header, keys, _dict));
                }

            }
            return listOfKeyboards;
        }

        public static Dictionary<string, double> extractTableOfKeysAndWeights(List<List<string>> listOfKeys)
        {
            List<double> sequencyWeights = new List<double>();
            List<string> sequencyKeys = new List<string>();

            for (int i = 0; i < listOfKeys.Count; i++)
            {
                for (int j = 0; j < listOfKeys[i].Count; j++)
                {
                    sequencyWeights.Add(i + j + 1);
                    sequencyKeys.Add(listOfKeys[i][j]);
                }
            }

            var dict = sequencyKeys.Zip(sequencyWeights, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            return dict;
        }

        public static double getFitness(Dictionary<Word, double> tableOfEffort)
        {
            //var b = tableOfEffort.ToDictionary(p => p.Key, p => p.Value / p.Key.rank);
            //var c = b.Sum(v => v.Value);
            //return c;

            return tableOfEffort.ToDictionary(p => p.Key, p => p.Value / p.Key.rank).Sum(v => v.Value);
        }

        public static Dictionary<Word, double> getTableOfEffortToWriteADictionary(Dictionary<string, double> tableOfKeys, Dictionary dictionary)
        {
            var a = dictionary.wordsList.Select(x => x).ToList();
            var b = a.Select((k, i) => new { k, i = calculatesTheEffortToWriteAInput(tableOfKeys, k.prefix) });
            var c = b.ToDictionary(x => x.k, x => x.i);

            return c;

            //return null;
            //return dictionary.wordsList.Select(x => x).ToList().Select((k, i) => new { k, i = calculatesTheEffortToWriteAInput(aleles, weights, k.prefix) }).ToDictionary(x => x.k, x => x.i);
        }

        public static double calculatesTheEffortToWriteAInput(Dictionary<string, double> tableOfKeys, string input)
        {

            var a1 = input.Select(x => x.ToString());
            var a2 = a1.Sum(x => tableOfKeys[x]);
            //var a2 = a1.Select(k => aleles.IndexOf(k));
            //var a3 = a2.Select(k => weights[k]);
            //var a4 = a3.Sum();

            //return a4;

            return a2;
            //return input.Select(x => x.ToString()).Select(k => aleles.IndexOf(k)).Select(k => weights[k]).Sum();

        }
    }
}
