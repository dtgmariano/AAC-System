using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    public static class UpdateStrategy
    {
        public static List<Individual> updateGeneration(List<Individual> _elite, List<Individual> _children)
        {
            List<Individual> population = new List<Individual>(_elite);
            population.AddRange(_children);
            return population;
        }
    }
}
