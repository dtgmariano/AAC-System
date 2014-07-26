using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public class GA
    {

        /*Dictionary and Keyboard related Variables*/
        string inputDictionaryFilePath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardPerformanceAnalyzer\\KeyboardPerformanceAnalyzer\\Data\\dict_freq_pt_br.txt";
        bool rankIsConsidered = true;

        DictionaryModel myDictionaryModel;
        KeyboardModel myKeyboardModel;
        Random random;

        List<string> keys = new List<string>() { "a","b","c","d","e",
                                                  "f","g","h","i","j",
                                                  "k","l","m","n","o",
                                                  "p","q","r","s","t",
                                                  "u","v","x","-",
                                                  "y","w","z"};

        /*Genetic Algorithm related Variables*/
        public int populationSize, generationsNumber;
        public double probabilityCrossover, probabilityMutation;

        public GA(Random _randomSeed)
        {
            this.random = _randomSeed;
        }
    }
}
