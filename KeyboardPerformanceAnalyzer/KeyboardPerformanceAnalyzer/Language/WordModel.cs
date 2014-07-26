using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public class WordModel
    {
        public string content;
        public int rank;
        public string abrev;

        public WordModel(string _content, int _rank, string _abrev)
        {
            content = _content;
            rank = _rank;
            abrev = _abrev;
        }
    }
}
