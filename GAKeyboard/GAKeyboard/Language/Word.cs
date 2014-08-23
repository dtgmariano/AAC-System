using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAKeyboard.Language
{
    public class Word
    {
        public string content;
        public int rank;
        public string prefix;

        public Word(string _content, int _rank, string _prefix)
        {
            content = _content;
            rank = _rank;
            prefix = _prefix;
        }

        public Word(string _content, int _rank)
        {
            content = _content;
            rank = _rank;
            prefix = null;
        }
    }
}
