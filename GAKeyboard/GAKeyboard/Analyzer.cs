using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAKeyboard.GeneticAlgorithm;
using GAKeyboard.Language;
using System.IO;

namespace GAKeyboard
{
    public class Analyzer
    {
        static string filePath = "C:\\Users\\Daniel\\GitHub\\AAC-System\\GAKeyboard\\GAKeyboard\\word_rank_abrev.txt";
        static bool hasRank = true;
        static int suggestionCriteriaNumber = 4;


        public Analyzer(Random _randomseed)
        {
            Dictionary myDictionary = new Dictionary(filePath, hasRank, suggestionCriteriaNumber);
            GA myGA = new GA(0.8, 0.05, 10, 10, myDictionary, _randomseed);

            var o = new List<Chromossome>(myGA.bestPerGeneration);
            var bestKeyboard = o.OrderBy(p => p.fitness).ToList()[0];

        }
    }

    public static class Exporter
    {
        public static bool exportData()
        {
            bool hasSuccess = false;

            var a = KeyboardProcessor.getTableOfEffortToWriteADictionary(keyboard, dictionary);

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(String.Join("", keyboard.keys.ToArray()));

                    foreach (KeyValuePair<WordModel, int> kvp in a)
                        writer.WriteLine(kvp.Key.rank + "\t" + kvp.Key.content + "\t" + kvp.Key.abrev + "\t" + kvp.Value);
                }
                hasSuccess = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return hasSuccess;
        }

    }
}
