using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class CrossoverStrategy
    {
        public static List<Individual> doCrossover(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        {
            List<Individual> offspring = new List<Individual>();

            int sizeChromossome = _parents[0].chromossome.Count();

            if (_selectionSize % 2 != 0)
            {
                offspring.Add(_parents[_selectionSize - 1]);
            }

            for (int i = 0; i < (_selectionSize / 2); i++)
            {
                double dice = _random.NextDouble();
                if (dice <= _crossoverProbability)
                {
                    //Do crossover and generates offsprings
                    int index = i * 2;
                    offspring.Add(onePoint(_parents[index], _parents[index + 1], _random));
                    offspring.Add(onePoint(_parents[index + 1], _parents[index], _random));
                }
                else
                {
                    //Mantain parents
                    int index = i * 2;
                    offspring.Add(_parents[index]);
                    offspring.Add(_parents[index + 1]);
                }
            }

            return offspring;
        }

        public static Individual onePoint(Individual p1, Individual p2, Random _random)
        {
            List<int> o1_c = new List<int>();

            int size = p1.chromossome.Count();
            int cutoff = _random.Next(0, size);

            o1_c.AddRange(p1.chromossome.GetRange(0, cutoff));
            o1_c.AddRange(p2.chromossome.GetRange(0, size - cutoff));

            return (new Individual(o1_c));
        }

        public static Individual oneGen(Individual p1, Individual p2, Random _random)
        {
            List<int> o1_c = new List<int>(p1.chromossome);

            int size = p1.chromossome.Count();
            int cutoff = _random.Next(0, size);

            o1_c[cutoff] = p2.chromossome[cutoff];

            return (new Individual(o1_c));
        }


        //public static List<Individual> TwoPoints(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        //{
        //    List<Individual> offspring = new List<Individual>();

        //    int sizeCode = _parents[0].chromossome.Count();

        //    if (_selectionSize % 2 != 0)
        //    {
        //        offspring.Add(_parents[_selectionSize - 1]);
        //    }

        //    for (int i = 0; i < (_selectionSize / 2); i++)
        //    {
        //        double dice = _random.NextDouble();
        //        if (dice <= _crossoverProbability)
        //        {
        //            //Do crossover and generates offsprings
        //            int index = i * 2;

        //            List<List<int>> offspring_a_gene = new List<List<int>>();
        //            List<List<int>> offspring_b_gene = new List<List<int>>();

        //            List<int> cp = new List<int>();
        //            cp.Add(_random.Next(0, sizeCode));
        //            cp.Add(_random.Next(0, sizeCode));

        //            while (cp[0] == cp[1])
        //            {
        //                cp.Clear();
        //                cp.Add(_random.Next(0, sizeCode));
        //                cp.Add(_random.Next(0, sizeCode));
        //            }

        //            cp.Sort();

        //            offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(0, cp[0]));
        //            offspring_a_gene.AddRange(_parents[index + 1].chromossome.GetRange(cp[0], cp[1] - cp[0] + 1));
        //            if ((cp[1] + 1) <= sizeCode)
        //                offspring_a_gene.AddRange(_parents[index].chromossome.GetRange(cp[1] + 1, sizeCode - cp[1] - 1));

        //            offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(0, cp[0]));
        //            offspring_b_gene.AddRange(_parents[index].chromossome.GetRange(cp[0], cp[1] - cp[0] + 1));
        //            if ((cp[1] + 1) <= sizeCode)
        //                offspring_b_gene.AddRange(_parents[index + 1].chromossome.GetRange(cp[1] + 1, sizeCode - cp[1] - 1));

        //            offspring.Add(new Individual(offspring_a_gene));
        //            offspring.Add(new Individual(offspring_b_gene));
        //        }
        //        else
        //        {
        //            //Mantain parents
        //            int index = i * 2;
        //            offspring.Add(_parents[index]);
        //            offspring.Add(_parents[index + 1]);
        //        }

        //    }
        //    return offspring;
        //}
        
        //public static List<Individual> PMX(List<Individual> _parents, int _selectionSize, double _crossoverProbability, Random _random)
        //{
        //    List<Individual> offsprings = new List<Individual>();

        //    List<List<int>> parent1, parent2;
        //    List<List<int>> offspring1, offspring2;
        //    List<int> cutoffPoints = new List<int>();
        //    double dice;

        //    /*In case the number of parents is an odd number, one parent will be left alone. 
        //     * In this case an exception handling is performed.*/
        //    if (_parents.Count % 2 != 0)
        //    {
        //        offsprings.Add(_parents[_parents.Count()]);
        //        _parents.RemoveAt(_parents.Count());
        //    }

        //    for(int i=0; i<(_parents.Count/2); i++)
        //    {
        //        dice = _random.NextDouble();

        //        if (dice <= _crossoverProbability)
        //        {
        //            cutoffPoints.Clear();
        //            cutoffPoints.Add(_random.Next(0, _parents[2 * i].chromossome.Count()));
        //            cutoffPoints.Add(_random.Next(0, _parents[2 * i].chromossome.Count()));
        //            while (cutoffPoints[0] == cutoffPoints[1])
        //            {
        //                cutoffPoints.Clear();
        //                cutoffPoints.Add(_random.Next(0, _parents[2 * i].chromossome.Count()));
        //                cutoffPoints.Add(_random.Next(0, _parents[2 * i].chromossome.Count()));
        //            }
        //            cutoffPoints.Sort();

        //            parent1 = _parents[2 * i].chromossome;
        //            parent2 = _parents[2 * i + 1].chromossome;

        //            offspring1 = pmxProcedure(parent1, parent2, cutoffPoints);
        //            offspring2 = pmxProcedure(parent2, parent1, cutoffPoints);

        //            offsprings.Add(new Individual(offspring1));
        //            offsprings.Add(new Individual(offspring2));
        //        }
        //        else
        //        {
        //            offsprings.Add(_parents[2 * i]);
        //            offsprings.Add(_parents[2 * i + 1]);
        //        }
        //    }
        //    return offsprings;
        //}

        //static List<List<int>> pmxProcedure(List<List<int>> _parent1, List<List<int>> _parent2, List<int> _cutoff)
        //{
        //    List<List<int>> child = new List<List<int>>();
        //    List<List<int>> swath_p1;

        //    /*Step 1: Randomly select a swath of alleles from parent 1 
        //     * and copy them directly to the child. Note the indexes of the segment.*/
        //    swath_p1 = _parent1.GetRange(_cutoff[0], _cutoff[1] - _cutoff[0] + 1);

        //    /*Organizes child alleles. The ones that are out of the cutoff zone, receives 'null' */
        //    for (int i = 0; i < _cutoff[1]; i++)
        //        child.Add(null);
        //    child.AddRange(swath_p1);
        //    for (int i = _cutoff[2] + 1; i < _parent1.Count(); i++)
        //        child.Add(null);

        //    /*Step 2: Looking in the same segment positions in parent 2, 
        //     * select each value that hasn't already been copied to the child.*/
        //    for (int i = _cutoff[0]; i < _cutoff[1] + 1; i++)
        //    {
        //        List<int> v, valuetoinsert;
        //        int idx_at_p2;

        //        /*For each of these values*/
        //        if (isItemRepeated(_parent2[i], child) == false)
        //        {
        //            /*Note the index of this value (parent2[i]) in Parent 2. Locate the value, V, 
        //             * from parent 1 in this same position. Locate this same value in parent 2.*/
        //            valuetoinsert = _parent2[i];
        //            v = _parent1[i];
        //            idx_at_p2 = getIndex(v, _parent2);

        //            while (is_part_of_the_original_swath(idx_at_p2, _cutoff[0], _cutoff[1]) == true)
        //            {
        //                v = _parent1[idx_at_p2];
        //                idx_at_p2 = getIndex(v, _parent2);
        //            }

        //            child[idx_at_p2] = valuetoinsert;
        //            /*If the index of this value in Parent 2 is part of the original swath, 
        //             * go to step i. using this value.*/

        //            /*If the position isn't part of the original swath, 
        //             * insert Step A's value into the child in this position.*/
        //        }
        //    }

        //    /*6. Now the easy part, we've taken care of all swath values, 
        //     * so everything else from Parent 2 drops down to the child.*/
        //    for (int i = 0; i < child.Count(); i++)
        //    {
        //        if (Comparable.AreEqual(child[i], null))
        //            child[i] = _parent2[i];
        //    }

        //    return child;
        //}

        //public static bool isItemRepeated(List<int> item, List<List<int>> list)
        //{
        //    bool answer = false;
        //    foreach (List<int> i in list)
        //    {
        //        if (Comparable.AreEqual(i, item))
        //        {
        //            answer = true;
        //            break;
        //        }
        //    }
        //    return answer;
        //}

        //public static int getIndex(List<int> item, List<List<int>> list)
        //{
        //    int index = 0;
        //    for (int i = 0; i < list.Count(); i++)
        //    {
        //        if (Comparable.AreEqual(list[i],item))
        //        {
        //            index = i;
        //            break;
        //        }
        //    }
        //    return index;
        //}

        //public static bool is_part_of_the_original_swath(int index, int cutoff1, int cutoff2)
        //{
        //    bool answer;

        //    if (index >= cutoff1 && index <= cutoff2)
        //        answer = true;
        //    else
        //        answer = false;

        //    return answer;
        //}
    
    }
}
