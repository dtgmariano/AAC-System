using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AAC_Project.Language
{
    public static class LanguageStrategies
    {
        public static List<object> readDicionaryFile(string _dictionaryFilePath)
        {
            var lDictionary = new List<object>();

            using(StreamReader reader = new StreamReader(_dictionaryFilePath, Encoding.UTF8))
            {

            }

            return null;
        }
    }
}
