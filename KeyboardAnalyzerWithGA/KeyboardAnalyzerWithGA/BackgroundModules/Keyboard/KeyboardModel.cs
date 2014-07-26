using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardAnalyzerWithGA
{
    public class KeyboardModel
    {
        public Dictionary<string, int> tableCharWeight;


        public KeyboardModel(List<string> _keys, List<int> _scores)
        {
            if (validatesLists(_keys, _scores))
                tableCharWeight = populatesMatrixValues(_keys, _scores);
            else
                tableCharWeight = null;
        }

        
        //Method to validate if there is the exactly same number of items in both lists
        public bool validatesLists(List<string> _keys, List<int> _scores)
        {
            return _keys.Count == _scores.Count();
        }

        //Creates a dictionary with Keys from List<string> _keys  and Values from List<int> _scores
        public Dictionary<string, int> populatesMatrixValues(List<string> _keys, List<int> _scores)
        {
            return _keys.Zip(_scores, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
