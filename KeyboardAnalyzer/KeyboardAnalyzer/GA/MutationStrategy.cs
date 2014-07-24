using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class MutationStrategy
    {
        public static List<Individual> doMutation(List<Individual> _offsprings, double probabilityMutation, Random _random)
        {
            List<Individual> mutants = new List<Individual>();
            int size = _offsprings[0].chromossome.Count();

            foreach (Individual c in _offsprings)
            {
                if (_random.NextDouble() <= probabilityMutation)
                    mutants.Add(Swap(c, _random));
                else
                    mutants.Add(c);
            }

            return mutants;
        }

        public static Individual Swap(Individual _offspring, Random _random)
        {
            int size = _offspring.chromossome.Count();
            List<int> swap = new List<int>();
            List<int> m_c = new List<int>(_offspring.chromossome);

            swap.Add(_random.Next(0, size));
            swap.Add(_random.Next(0, size));
            while (swap[0] == swap[1])
            {
                swap.Clear();
                swap.Add(_random.Next(0, size));
                swap.Add(_random.Next(0, size));
            }
            swap.Sort();

            int garbage = m_c[swap[0]];
            m_c[swap[0]] = m_c[swap[1]];
            m_c[swap[1]] = garbage;

            return (new Individual(m_c));
        }


    }
}
