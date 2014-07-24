using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzerWithGA
{
    public class KeyboardAnalyzerModel
    {
        public string dictionaryFilePath;
        public DictionaryModel myDictionary;
        public KeyboardModel myKM;
        public Dictionary<string, string> tableNecessaryInputs;
        public Dictionary<string, int> tableNecessaryEffort;

        List<string> keys = new List<string>() { "a","b","c","d","e",
                                                  "f","g","h","i","j",
                                                  "k","l","m","n","o",
                                                  "p","q","r","s","t",
                                                  "u","v","x","-",
                                                  "y","w","z"};

        List<int> scores = new List<int>() { 1, 2, 3, 4, 5, 
                                             2, 3, 4, 5, 6, 
                                             3, 4, 5, 6, 7, 
                                             4, 5, 6, 7, 8,
                                             5, 6, 7, 8,
                                             6, 7, 8};
        

        public KeyboardAnalyzerModel(string _dictionaryFilePath, int criteria_number_suggestion, bool hasFrequency)
	    {
            myDictionary = new DictionaryModel(_dictionaryFilePath, hasFrequency);
            myKM = new KeyboardModel(keys,scores);
            tableNecessaryInputs = WordAnalyzer.getTableOfInputsForEachWord(this.myDictionary.dict, criteria_number_suggestion);
            tableNecessaryEffort = WordAnalyzer.getTableSumOfStepsToWriteEachInput(this.myKM, this.tableNecessaryInputs);
	    }
     
    }
}
