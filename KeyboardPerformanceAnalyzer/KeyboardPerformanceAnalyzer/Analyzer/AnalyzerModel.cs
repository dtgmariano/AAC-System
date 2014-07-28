using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public class AnalyzerModel
    {
        static string inputFolderPath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardPerformanceAnalyzer\\KeyboardPerformanceAnalyzer\\Data\\";
        string inputDictionaryFilePath = inputFolderPath + "word_rank_abrev.txt";
        string inputKeyboardFilePath = inputFolderPath + "keyboard_rand2_6x5.txt";
        bool rankIsConsidered = true;
        int suggestionCriteriaNumber = 4;

        DictionaryModel myDictionaryModel;
        KeyboardModel myKeyboardModel;
        Random random;
        
        public AnalyzerModel(Random _randomSeed)
        {
            this.random = _randomSeed;
            ExportData.exportRandomKeyboardConfiguration();
            this.myDictionaryModel = new DictionaryModel(inputDictionaryFilePath, rankIsConsidered, suggestionCriteriaNumber);
            this.myKeyboardModel = new KeyboardModel(inputKeyboardFilePath);
            var a = ExportData.exportKeyboardModelPerformance("keyboard_rand2_6x5_perfomance.txt", myKeyboardModel, myDictionaryModel);

        }
    }
}
