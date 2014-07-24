using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    static public class PopulateStrategy
    {
        public static List<Individual> populate(int _populationSize, Random _random)
        {
            List<Individual> population = new List<Individual>();
            for (int i = 0; i < _populationSize; i++)
                population.Add(new Individual(_random));
            return population;
        }
    }
}