using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardAnalyzerWithGA
{
    public static class DatabaseExport
    {
        public static bool exportPerformanceTableTxtFile(Dictionary<string, string> tableNecessaryInput, Dictionary<string, int> tableNecessaryEffort, Dictionary<string, int> tableFrequency, string outputFilePath)
        {
            bool hasSuccess;
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (KeyValuePair<string, int> kvp in tableNecessaryEffort)
                    {
                        writer.WriteLine(kvp.Key + "\t" + tableNecessaryInput[kvp.Key] + "\t" + kvp.Value + "\t" + tableFrequency[kvp.Key]);
                    }
                }

                hasSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
                hasSuccess = false;
            }
            
            return hasSuccess;
        }
    }
}
