using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAKeyboard.Language;

namespace GAKeyboard.GeneticAlgorithm
{
    public class GA
    {
        double crossoverRate;
        double mutationRate;
        int numGenerations;
        int populationSize;
        int elitismSize;
        public List<Chromossome> initialPopulation, finalPopulation;
        public List<Chromossome> bestPerGeneration;
        public Dictionary dictionary;

        Random randomseed;
        //var a = myGA.finalPopulation;
        //    a.OrderBy(o => o.fitness);
        //    a.Reverse();
        //    var c = a[0];

        public GA(double _crossoverRate, double _mutationRate, int _numGenerations, int _populationSize, int _elitismSize, Dictionary _dictionary, Random _randomseed)
        {
            this.crossoverRate = _crossoverRate;
            this.mutationRate = _mutationRate;
            this.numGenerations = _numGenerations;
            this.populationSize = _populationSize;
            this.elitismSize = _elitismSize;
            this.dictionary = _dictionary;
            this.randomseed = _randomseed;
            
            this.initialPopulation = GAStrategy.startPopulation(populationSize, dictionary);
            //this.finalPopulation = GAStrategy.gaProcess(numGenerations, crossoverRate, mutationRate, initialPopulation, 2, dictionary, randomseed);
            processGA();
        }
   
        public void processGA()
        {
            List<Chromossome> previousGeneration = new List<Chromossome>(initialPopulation);
            List<Chromossome> newGeneration;
            bestPerGeneration = new List<Chromossome>();

            for(int i=0; i< numGenerations; i++)
            {

                newGeneration = GAStrategy.generationProcess(crossoverRate, mutationRate, elitismSize, previousGeneration, 2, dictionary, randomseed);
                var a = newGeneration.OrderBy(o => o.fitness);
                var bestOfGeneration = a.ToList()[0];
                bestPerGeneration.Add(bestOfGeneration);

                var d = newGeneration.Select(o => o.fitness).Average();

                Console.WriteLine((i + 1) + " Code: " + String.Join("", bestOfGeneration.aleles.ToArray()) + " Fit: " + bestOfGeneration.fitness.ToString() + " Avg Fit: " + d.ToString());

                previousGeneration.Clear();
                previousGeneration = new List<Chromossome>(newGeneration);
            }
            this.finalPopulation = new List<Chromossome>(previousGeneration);

        }
    }
}
