using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyboardPerformanceAnalyzer
{
    public class KeyboardModel
    {
        public List<string> keys;
        public List<int> weights;
        public Dictionary<string, int> keysWeightTable;
        public double score;

        /*Starts with a default configuration*/
        //public KeyboardModel()
        //{
        //    this.keys = KeyboardProcessor.generateListKeys();
        //}

        ///*Stars with a random configuration*/
        //public KeyboardModel(Random _random)
        //{
        //    this.keys = KeyboardProcessor.generateListKeys(_random);
        //}

        /*Loading list from a .txt File*/
        public KeyboardModel(string inputKeyFilePath)
        {
            keysWeightTable = ImportData.getKeyboardConfiguration(inputKeyFilePath);
            keys = keysWeightTable.Select(kvp => kvp.Key).ToList();
            weights = keysWeightTable.Select(kvp => kvp.Value).ToList();
            //this.keys = KeyboardProcessor.organizeDistributionOfKeys(ImportData.getKeysConfiguration(inputKeyFilePath));
        }

    }
}
