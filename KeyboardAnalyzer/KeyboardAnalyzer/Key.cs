using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzer
{
    public class Key
    {
        public string content;
        public int col, row, block;

        public Key(string _content, int _col, int _row, int _block)
        {
            content = _content;
            col = _col;
            row = _row;
            block = _block;
        }
    }
}
