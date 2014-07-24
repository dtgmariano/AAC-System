using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardAnalyzerWithGA
{
    public static class DatabaseExport
    {
        public static bool exportPerformanceTableTxtFile(Dictionary<string, string> tableNecessaryInput, Dictionary<string, int> tableNecessaryEffort, string outputFilePath)
        {
            bool hasSuccess;
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (KeyValuePair<string, int> kvp in tableNecessaryEffort)
                    {
                        writer.WriteLine(kvp.Key + "\t" + kvp.Value);
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
