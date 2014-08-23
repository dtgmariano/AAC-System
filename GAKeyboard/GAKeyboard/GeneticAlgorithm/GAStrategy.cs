using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAKeyboard.Language;

namespace GAKeyboard.GeneticAlgorithm
{
    public static class GAStrategy
    {
        public static List<Chromossome> startPopulation(int _populationSize, Dictionary _dictionary)
        {
            List<Chromossome> randomPopulation = new List<Chromossome>();
            for (int i = 0; i < _populationSize; i++)
                randomPopulation.Add(new Chromossome(_dictionary));

            return randomPopulation;
        }

        public static List<Chromossome> generationProcess(double crossoverRate, double mutationRate, int elitismSize, List<Chromossome> previousGeneration, int _numOfPlayers, Dictionary _dictionary, Random _randomseed)
        {
            int size = previousGeneration.Count();
            var a = previousGeneration.OrderBy(p => p.fitness);
            var b = a.Take(elitismSize).ToList();
            List<Chromossome> newGeneration = new List<Chromossome>(b);
            
            while (newGeneration.Count() < previousGeneration.Count())
            {

                /*Selecting candidates to reproduction -> Parents selection*/
                var a1 = previousGeneration.OrderBy(x => _randomseed.Next()).ToList();
                var a2 = a1.Take(_numOfPlayers).ToList();
                var a3 = a2.Min(q => q.fitness);
                var parent1 = previousGeneration.Find(p => p.fitness == a3);

                //var parent1 = previousGeneration.Find(p => p.fitness == previousGeneration.OrderBy(x => _randomseed.Next()).ToList().Take(_numOfPlayers).ToList().Min(q => q.fitness));

                var b1 = previousGeneration.OrderBy(x => _randomseed.Next()).ToList();
                var b2 = b1.Take(_numOfPlayers).ToList();
                var b3 = b2.Min(q => q.fitness);
                var parent2 = previousGeneration.Find(p => p.fitness == b3);

                //var parent2 = previousGeneration.Find(p => p.fitness == previousGeneration.OrderBy(x => _randomseed.Next()).ToList().Take(_numOfPlayers).ToList().Min(q => q.fitness));

                double dice = _randomseed.NextDouble(); //dice for crossoverRate
                if (crossoverRate >= dice)
                {
                    int aleleSize = parent1.aleles.Count;

                    List<object> child = PMXProcedure(parent1, parent2, _randomseed);

                    dice = _randomseed.NextDouble(); //dice for crossoverRate

                    var comp = new List<Chromossome>() { new Chromossome(child, _dictionary) };

                    /*Swapping mutation procedure*/
                    if (mutationRate >= dice)
                    {
                        List<object> child2 = SwapProcedure(child, _randomseed);
                        comp.Add(new Chromossome(child2, _dictionary));
                    }

                    var c = comp.OrderBy(o => o.fitness).Reverse().ToList()[0];

                    newGeneration.Add(c);
                }
                else
                {
                    if (parent1.fitness >= parent2.fitness)
                        newGeneration.Add(parent1);
                    else
                        newGeneration.Add(parent2);
                }
            }

            return newGeneration;
        }
        /*Selection: Tournament
         Crossover: PMX
         Mutation: Swap
         */
        public static List<Chromossome> gaProcess(int numberOfGenerations, double crossoverRate, double mutationRate, List<Chromossome> _population, int _numOfPlayers, Dictionary _dictionary, Random _randomseed)
        {
            int size = _population.Count();

            List<Chromossome> previousGeneration = new List<Chromossome>(_population); 
            List<Chromossome> newGeneration = new List<Chromossome>();

            for (int ng = 0; ng < numberOfGenerations; ng++)
            {
                Console.WriteLine("Generation: " + ng);
                newGeneration.Clear();
                while (newGeneration.Count() < previousGeneration.Count())
                {

                    /*Selecting candidates to reproduction -> Parents selection*/
                    //var a1 = previousGeneration.OrderBy(x => _randomseed.Next()).ToList();
                    //var a2 = a1.Take(_numOfPlayers).ToList();
                    //var a3 = a2.Min(q => q.fitness);
                    //var parent1 = previousGeneration.Find(p => p.fitness == a3);

                    var parent1 = previousGeneration.Find(p => p.fitness == previousGeneration.OrderBy(x => _randomseed.Next()).ToList().Take(_numOfPlayers).ToList().Min(q => q.fitness));

                    //var b1 = previousGeneration.OrderBy(x => _randomseed.Next()).ToList();
                    //var b2 = b1.Take(_numOfPlayers).ToList();
                    //var b3 = b2.Min(q => q.fitness);
                    //var parent2 = previousGeneration.Find(p => p.fitness == b3);

                    var parent2 = previousGeneration.Find(p => p.fitness == previousGeneration.OrderBy(x => _randomseed.Next()).ToList().Take(_numOfPlayers).ToList().Min(q => q.fitness));

                    double dice = _randomseed.NextDouble(); //dice for crossoverRate
                    if (crossoverRate >= dice)
                    {
                        int aleleSize = parent1.aleles.Count;

                        List<object> child = PMXProcedure(parent1, parent2, _randomseed);

                        dice = _randomseed.NextDouble(); //dice for crossoverRate

                        var comp = new List<Chromossome>() { new Chromossome(child, _dictionary) };

                        /*Swapping mutation procedure*/
                        if (mutationRate >= dice)
                        {
                            List<object> child2 = SwapProcedure(child, _randomseed);
                            comp.Add(new Chromossome(child2, _dictionary));
                        }

                        var c = comp.OrderBy(o => o.fitness).Reverse().ToList()[0];

                        newGeneration.Add(c);
                    }
                    else
                    {
                        if (parent1.fitness >= parent2.fitness)
                            newGeneration.Add(parent1);
                        else
                            newGeneration.Add(parent2);
                    }
                }
                previousGeneration.Clear();
                previousGeneration = new List<Chromossome>(newGeneration);
                
            }
            return newGeneration;
        }
        
        public static List<object> PMXProcedure(Chromossome _parent1, Chromossome _parent2, Random _randomseed)
        {
            List<object> garbage = new List<object>() { "*", "*", "*", "*", "*", 
                                                        "*", "*", "*", "*", "*",
                                                        "*", "*", "*", "*", "*", 
                                                        "*", "*", "*", "*", "*",
                                                        "*", "*", "*", "*", "*",
                                                        "*", "*", "*", "*", "*"};
            int _aleleSize = _parent1.aleles.Count;
            
            List<int> cuttingPoint = new List<int>();
            cuttingPoint.Add(_randomseed.Next(0, _aleleSize));
            cuttingPoint.Add(_randomseed.Next(0, _aleleSize));
            while (cuttingPoint[0] == cuttingPoint[1])
            {
                cuttingPoint.Clear();
                cuttingPoint.Add(_randomseed.Next(0, _aleleSize));
                cuttingPoint.Add(_randomseed.Next(0, _aleleSize));
            }


            /*Randomly select a swath of alleles from parent 1 and copy them directly to the child. Note the indexes of the segment.*/
            List<object> swatch1 = _parent1.aleles.GetRange(cuttingPoint.Min(), (cuttingPoint.Max() - cuttingPoint.Min()));
            List<object> swatch2 = _parent2.aleles.GetRange(cuttingPoint.Min(), (cuttingPoint.Max() - cuttingPoint.Min()));

            List<object> child = new List<object>(garbage.GetRange(0, cuttingPoint.Min()));
            child.AddRange(swatch1);
            child.AddRange(garbage.GetRange(cuttingPoint.Max(), (_aleleSize - cuttingPoint.Max())));

            /*Looking in the same segment positions in parent 2*/
            foreach (object o in swatch2)
            {
                /*select each value that hasn't already been copied to the child.*/
                if (!child.Contains(o))
                {
                    object temp = o;

                    while (true)
                    {
                        /*Note the index of this value in Parent 2.*/
                        int idx1 = _parent2.aleles.FindIndex(a => a.Equals(temp));
                        /*Locate the value, V, from parent 1 in this same position.*/
                        object v = _parent1.aleles[idx1];
                        /*Locate this same value in parent 2.*/
                        int idx2 = _parent2.aleles.FindIndex(a => a.Equals(v));
                        /*If the index of this value in Parent 2 is part of the original swath, go to step i. using this value.*/
                        if (swatch2.Contains(v))
                            temp = v;
                        else
                        {
                            child[idx2] = o;
                            break;
                        }
                    }
                }
            }

            var idx = child.FindIndex(a => a.Equals("*"));
            while (idx >= 0)
            {
                child[idx] = _parent2.aleles[idx];
                idx = child.FindIndex(a => a.Equals("*"));
            }

            return child;
        }

        public static List<object> SwapProcedure(List<object> _childAlele, Random _randomseed)
        {
            List<int> mutationPoint = new List<int>();
            int aleleSize = _childAlele.Count();
            mutationPoint.Add(_randomseed.Next(0, aleleSize));
            mutationPoint.Add(_randomseed.Next(0, aleleSize));
            while (mutationPoint[0] == mutationPoint[1])
            {
                mutationPoint.Clear();
                mutationPoint.Add(_randomseed.Next(0, aleleSize));
                mutationPoint.Add(_randomseed.Next(0, aleleSize));
            }

            var temp = _childAlele[mutationPoint.Min()];
            _childAlele[mutationPoint.Min()] = _childAlele[mutationPoint.Max()];
            _childAlele[mutationPoint.Max()] = temp;

            return _childAlele;
        }
    
    }
}