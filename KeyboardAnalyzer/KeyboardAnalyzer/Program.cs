using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyboardModel km = new KeyboardModel();
            km.loadKeysConfig("");
            KeyboardAnalyzer ka = new KeyboardAnalyzer();
            ka.calculateTimeToWrite(km, "accba");
        }
    }
}
