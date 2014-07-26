using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer.GeneticAlgorithm
{
    public class Individual
    {
        public List<string> chromossome;
        public double fitness;

        public Individual(Random _random)
        {
            chromossome = ChromossomeStrategy.generateRandomListKeys(_random);

        }

        /*Constructor to Create an individual from  Crossover Process*/
        public Individual(Individual A, Individual B)
        {

        }

    }
}
