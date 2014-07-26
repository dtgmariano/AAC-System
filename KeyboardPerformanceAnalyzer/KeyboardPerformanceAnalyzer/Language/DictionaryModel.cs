using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public class DictionaryModel
    {
        public List<WordModel> wordsList;

        /*//Processed already and saved, no need to repeated procedure
        public List<string> wordsInput;*/

        int suggestionCriteriaNumber;

        public DictionaryModel(string _filePath, bool _rankIsConsidered, int _suggestionCriteriaNumber)
        {
            this.wordsList = ImportData.getListofWords(_filePath);
            this.suggestionCriteriaNumber = _suggestionCriteriaNumber;

            if (!_rankIsConsidered) //case is false: set all word's rank to 1 -> no ranking difference between words
                wordsList.ForEach(delegate(WordModel w) { w.rank = 1; });

            /*//Processed already and saved, no need to repeated procedure
            this.wordsInput = DictionaryProcessor.getListOfInputsForEachWord(wordsList, suggestionCriteriaNumber);*/
        }

        
    }
}
