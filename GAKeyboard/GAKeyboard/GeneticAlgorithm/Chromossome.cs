using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAKeyboard.Language;

namespace GAKeyboard.GeneticAlgorithm
{
    public class Chromossome
    {
        public List<object> aleles;
        public static List<double> weights = new List<double>(){1, 2, 3, 4, 5, 
                                                                2, 3, 4, 5, 6, 
                                                                3, 4, 5, 6, 7, 
                                                                4, 5, 6, 7, 8, 
                                                                5, 6, 7, 8, 9, 
                                                                6, 7, 8, 9, 10 };

        public Dictionary<Word, double> TableOfEffortToWriteADictionary;
        public double fitness;

        public Chromossome(Dictionary _dictionary)
        {
            this.aleles = ChromossomeStrategy.genSequencyOfChars();
            this.TableOfEffortToWriteADictionary = ChromossomeStrategy.getTableOfEffortToWriteADictionary(this.aleles, weights, _dictionary);
            this.fitness = ChromossomeStrategy.getFitness(this.TableOfEffortToWriteADictionary);
        }

        public Chromossome(List<object> _aleles, Dictionary _dictionary)
        {
            this.aleles = _aleles;
            this.TableOfEffortToWriteADictionary = ChromossomeStrategy.getTableOfEffortToWriteADictionary(this.aleles, weights, _dictionary);
            this.fitness = ChromossomeStrategy.getFitness(this.TableOfEffortToWriteADictionary);
        }
    }
}
