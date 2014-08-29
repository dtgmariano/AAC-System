using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GAKeyboard.Language;

namespace GAKeyboard.Keyboard
{
    public class Keyboard
    {
        public string name;
        List<List<string>> listOfKeys;
        public Dictionary<string, double> tableOfKeys;
        public Dictionary<Word, double> TableOfEffortToWriteADictionary;
        public double fitness;


        public Keyboard(string _name, List<List<string>> _listOfKeys, Dictionary _dict)
        {
            name = _name;
            listOfKeys = _listOfKeys;
            tableOfKeys = KeyboardStrategy.extractTableOfKeysAndWeights(listOfKeys).OrderBy(x => x.Key).ToDictionary(p => p.Key, p => p.Value);
            TableOfEffortToWriteADictionary = KeyboardStrategy.getTableOfEffortToWriteADictionary(this.tableOfKeys, _dict);
            fitness = KeyboardStrategy.getFitness(TableOfEffortToWriteADictionary);
        }

        
    }
}
