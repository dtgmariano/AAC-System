using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzer
{
    class KeyboardCoordinates
    {
        public int column, row, block;
        
        public KeyboardCoordinates(int x, int y, int z)
        {
            row = x;
            column = y;
            block = z;
        }
    }
}
