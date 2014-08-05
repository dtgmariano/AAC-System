using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMXProcedure
{
    class Program
    {
        static Random _randomseed = new Random();

        static void Main(string[] args)
        {
            Chromossome parent1 = new Chromossome(new List<object>() { "8", "4", "7", "3", "6", "2", "5", "1", "9", "0" });
            Chromossome parent2 = new Chromossome(new List<object>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            
            List<object> garbage = new List<object>(){"*", "*", "*", "*", "*", "*", "*", "*", "*","*"};
            int aleleSize = parent1.aleles.Count;

            /*Randomly select a swath of alleles from parent 1 and copy them directly to the child. Note the indexes of the segment.*/
            List<int> cuttingPoint = new List<int>() { 3, 8 };
            List<object> swatch1 = parent1.aleles.GetRange(3, (8 - 3));
            List<object> swatch2 = parent2.aleles.GetRange(3, (8 - 3));

            List<object> child = new List<object>(garbage.GetRange(0, 3));
            child.AddRange(swatch1);
            child.AddRange(garbage.GetRange(8, (10-8)));

            /*Looking in the same segment positions in parent 2*/
            foreach (object o in swatch2)
            {
                /*select each value that hasn't already been copied to the child.*/
                if(!child.Contains(o))
                {
                    object temp = o;

                    while(true)
                    {
                        /*Note the index of this value in Parent 2.*/
                        int idx1 = parent2.aleles.FindIndex(a => a.Equals(temp));
                        /*Locate the value, V, from parent 1 in this same position.*/
                        object v = parent1.aleles[idx1];
                        /*Locate this same value in parent 2.*/
                        int idx2 = parent2.aleles.FindIndex(a => a.Equals(v));
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
                child[idx] = parent2.aleles[idx];
                idx = child.FindIndex(a => a.Equals("*"));
            }

            "".ToString();
        }
    }
    
    public class Chromossome
    {
        public List<object> aleles;
        
        public Chromossome(List<object> _aleles)
        {
            this.aleles = _aleles;
        }
    }
}
