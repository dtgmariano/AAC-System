using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzerWithGA
{
    class Chromossome
    {
        List<string> chars = new List<string>() { "a","b","c","d","e",
                                                  "f","g","h","i","j",
                                                  "k","l","m","n","o",
                                                  "p","q","r","s","t",
                                                  "u","v","x",
                                                  "y","w","z"};

        List<int> scores = new List<int>() { 1, 2, 3, 4, 5, 
                                             2, 3, 4, 5, 6, 
                                             3, 4, 5, 6, 7, 
                                             4, 5, 6, 7, 8,
                                             5, 6, 7,
                                             6, 7, 8};

        Dictionary<int, int> scoreByPosition;

        public List<string> genes;
        double fitness;

        public Chromossome(Random _randomseed)
        {
            scoreByPosition = populatesMatrixValues(scores);
            genes = genChromossome(_randomseed);
        }


        //Populates dictionary -> key: position | value: weight
        public Dictionary<int, int> populatesMatrixValues(List<int> _scores)
        {
            Dictionary<int, int> matrixValues = new Dictionary<int, int>();
            for (int i = 0; i < _scores.Count; i++)
                matrixValues.Add(i, _scores[i]);
            return matrixValues;
        }

        //Generates a Random Keyboard
        public List<string> genChromossome(Random _randomseed)
        {
            Random rnd = _randomseed;
            return chars.OrderBy(item => rnd.Next()).ToList();
        }

        public double getFitness()
        {
            double value = 0.0;

            return value;
        }
    }
}
