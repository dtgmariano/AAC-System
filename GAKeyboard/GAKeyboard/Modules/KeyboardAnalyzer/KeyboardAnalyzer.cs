using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using GAKeyboard.Keyboard;
using GAKeyboard.Language;
using GAKeyboard.GeneticAlgorithm;

namespace GAKeyboard
{
    public class KeyboardAnalyzer
    {
        Dictionary myDict;
        List<Keyboard.Keyboard> listKeyboards;

        public KeyboardAnalyzer(string _KLfilePath, string _DictfilePath)
        {
            myDict = new Dictionary(_DictfilePath, true);
            listKeyboards = KeyboardStrategy.loadKeyboardList(_KLfilePath, myDict);
            
        }

    }
}
