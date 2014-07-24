using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace KeyboardAnalyzerWithGA
{
    public static class WordAnalyzer
    {

        /*Function to create a dictionary table where:
         * Key = Content or Word from a dictionary || Value = Input necessary to type the word*/
        public static Dictionary<string, string> getTableOfInputsForEachWord(Dictionary<string, int> dict, int suggestionPositionCriteria)
        {
            Dictionary<string, string> table = new Dictionary<string, string>();

            foreach (string s in dict.Keys)
            {
                table.Add(s, getNecessaryKeys(s, dict, suggestionPositionCriteria));
            }

            return table.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /*Fuction that retrieves the necessary input keystrokes to have the expected word in the suggestion words*/
        public static string getNecessaryKeys(string word, Dictionary<string, int> dict, int suggestionPositionCriteria)
        {
            Dictionary<string, int> suggestion;
            string input = "";

            for (int i = 0; i < word.Length; i++)
            {
                input += word[i];

                //retorna para suggestion os KeyValuePair do dict que possuem keys que começam com o valor de string input
                suggestion = dict.Where(p => p.Key.StartsWith(input)).ToDictionary(e => e.Key, e => e.Value);
                
                /*orderno a tabela suggestion pela frequencia da palavra (x.Value)*/
                suggestion = suggestion.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                /*se a palavra procurada está entre as n-primeiras sugestões do dicionário, então interrompe o processo 
                e retorna as únicas keystrokes necessárias para escrever a palavra*/
                if (suggestion.Take(suggestionPositionCriteria).ToDictionary(e => e.Key, e => e.Value).ContainsKey(word))
                    break;
            }

            return input;
        }

        /*Function to create a dictionary table where:
        * Key = Content or Word from a dictionary || Value = Necessary Mathematical effort to type the word*/
        public static Dictionary<string, int> getTableSumOfStepsToWriteEachInput(KeyboardModel km, Dictionary<string, string> tableOfInputs)
        {
            var a1 = tableOfInputs.Select(x => x.Key).ToList();
            var a2 = a1.Select((k, i) => new { k, i = getSumOfStepsToWriteTheInput(km, tableOfInputs[k]) });
            var a3 = a2.ToDictionary(x => x.k, x => x.i);
            return a3;
             
            //return tableOfInputs.Select(x => x.Key).ToList().Select((k, i) => new { k, i = getSumOfStepsToWriteTheInput(km, k)}).ToDictionary(x => x.k, x => x.i);
        }

        /*Calculates the mathematical effort based on the distribution of the characters throughout the matrix (keyboard layout)*/
        public static int getSumOfStepsToWriteTheInput(KeyboardModel km, string input)
        {
             var a1 = input.Select(x => x.ToString()).ToList();
             var a2 = a1.Select(k => km.tableCharWeight[k]).ToList();
             var a3 = a2.Sum();
             return a3;
             

            //return input.Select(x => x.ToString()).ToList().Select(k => km.tableCharWeight[k]).ToList().Sum();
        }

    }
}
