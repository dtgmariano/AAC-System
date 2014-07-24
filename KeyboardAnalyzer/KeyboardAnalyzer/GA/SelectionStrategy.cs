using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    static public class SelectionStrategy
    {
        public static List<Individual> Tournament(List<Individual> _population, int _selectionSize, int _numberofPlayers, Random _random)
        {
            List<Individual> population = new List<Individual>(_population);
            List<Individual> players = new List<Individual>();
            List<Individual> parents = new List<Individual>();

            int dice;

            for (int i = 0; i < _selectionSize; i++)
            {
                players.Clear();
                for (int j = 0; j < _numberofPlayers; j++)
                {
                    dice = _random.Next(0, population.Count());
                    players.Add(population[dice]);
                }
                parents.Add(ElitismStrategy.basicElitism(players, 1)[0]);
            }

            return parents;
        }

        public static List<Individual> RouletteWheel(List<Individual> _population, int _selectionSize, Random _random)
        {
            List<Individual> parents = new List<Individual>();

            double total_fitness = 0;

            foreach (Individual c in _population)
                total_fitness += c.fitness;

            List<double> ps = new List<double>();
            List<double> psa = new List<double>();

            for (int i = 0; i < _population.Count(); i++)
            {
                ps.Add(_population[i].fitness / total_fitness);
                psa.Add(0.0);

                for (int j = 0; j <= i; j++)
                {
                    psa[i] += ps[j];
                }
            }

            double wheelCounter;

            for (int i = 0; i < _selectionSize; i++)
            {
                //wheelCounter = this.random.Next(Convert.ToInt32(Math.Floor(psa.Max())));
                wheelCounter = _random.NextDouble();
                for (int j = 0; j < _population.Count(); j++)
                {
                    if (wheelCounter <= psa[j])
                    {
                        parents.Add(_population[j]);
                        break;
                    }
                }
            }

            return parents;
        }

    }
}
