using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAKeyboard.Language
{
    public class Dictionary
    {
        public List<Word> wordsList;
        int suggestionCriteriaNumber;

        public Dictionary(string _filePath, bool _rankIsConsidered)
        {
            this.wordsList = DictionaryStrategy.getDictionary(_filePath);
            this.suggestionCriteriaNumber = 0;

            if (!_rankIsConsidered) //case is false: set all word's rank to 1 -> no ranking difference between words
                wordsList.ForEach(delegate(Word w) { w.rank = 1; });
        }

        public Dictionary(string _filePath, bool _rankIsConsidered, int _suggestionCriteriaNumber)
        {
            this.wordsList = DictionaryStrategy.getDictionary(_filePath);
            this.suggestionCriteriaNumber = _suggestionCriteriaNumber;

            if (!_rankIsConsidered) //case is false: set all word's rank to 1 -> no ranking difference between words
                wordsList.ForEach(delegate(Word w) { w.rank = 1; });
        }
    }
}
