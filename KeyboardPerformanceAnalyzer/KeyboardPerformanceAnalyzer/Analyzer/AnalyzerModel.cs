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
        string inputKeyboardFilePath = inputFolderPath + "chars_count.txt";
        bool rankIsConsidered = true;
        int suggestionCriteriaNumber = 4;

        DictionaryModel myDictionaryModel;
        KeyboardModel myKeyboardModel;
        Random random;
        
        public AnalyzerModel(Random _randomSeed)
        {
            this.random = _randomSeed;
            this.myDictionaryModel = new DictionaryModel(inputDictionaryFilePath, rankIsConsidered, suggestionCriteriaNumber);
            this.myKeyboardModel = new KeyboardModel(inputKeyboardFilePath);
            var a = ExportData.exportKeyboardModelPerformance("keyboardPerfomance1.txt", myKeyboardModel, myDictionaryModel);
            //ExportData.exportFrequencyOfCharsOfADictionary("freqChars.txt", myDictionaryModel);

        }
    }
}
