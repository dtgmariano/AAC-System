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

        public KeyboardAnalyzer(string _currentDirectory, string _KLfilePath, string _DictfilePath)
        {
            myDict = new Dictionary((_currentDirectory + _DictfilePath), true);
            listKeyboards = KeyboardStrategy.loadKeyboardList((_currentDirectory + _KLfilePath), myDict);
            string saveTo = _currentDirectory + "\\KeyboardAnalyzer\\" + listKeyboards[0].name + "_windsize_4.txt";
            writeKeyboardAnalysis(listKeyboards[0], saveTo);
        }

        public void writeKeyboardAnalysis(Keyboard.Keyboard keyboard, string outputFilePath)
        {
            var a = DateTime.Now.ToString();
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(keyboard.name + "\t" + keyboard.fitness);

                    foreach (KeyValuePair<string, double> kvp in keyboard.tableOfKeys)
                        writer.WriteLine(kvp.Key + "\t" + kvp.Value);

                    foreach (KeyValuePair<Word, double> kvp in keyboard.TableOfEffortToWriteADictionary)
                        writer.WriteLine(kvp.Key.rank + "\t" + kvp.Key.content + "\t" + kvp.Key.prefix + "\t" + kvp.Value);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
