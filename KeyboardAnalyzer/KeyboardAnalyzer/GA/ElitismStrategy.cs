using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    static public class ElitismStrategy
    {
        public static List<Individual> basicElitism(List<Individual> _population, int _elitismSize)
        {
            List<Individual> population = new List<Individual>(_population);
            List<double> populationFitness = new List<double>();

            foreach (Individual c in population)
                populationFitness.Add(c.fitness);

            Array acandidates = population.ToArray();
            Array acandidates_fitness = populationFitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            population = acandidates.OfType<Individual>().ToList();
            population.Reverse();
            population.RemoveRange(_elitismSize, population.Count() - _elitismSize);

            return population;
        }
    }
}
