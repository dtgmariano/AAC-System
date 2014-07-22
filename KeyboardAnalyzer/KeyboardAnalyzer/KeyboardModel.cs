using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KeyboardAnalyzer
{
    public class KeyboardModel
    {
        //]public Dictionary<String, KeyboardCoordinates> keys;
        public List<Key> keys;
        public string header = "[header5498721]";
        public int nro_columns, nro_rows, nro_blocks;

        public KeyboardModel(string openFile)
        {
            //keys = new Dictionary<string, KeyboardCoordinates>();
            keys = new List<Key>();
            loadKeyboard(openFile);
        }

        public void loadKeyboard(string openFile)
        {
            using (StreamReader reader = new StreamReader(openFile, Encoding.Default))
            {
                string line;
                if (reader.ReadLine().Equals(header))
                {
                    nro_columns = Convert.ToInt16(reader.ReadLine());
                    nro_rows = Convert.ToInt16(reader.ReadLine());
                    nro_blocks = Convert.ToInt16(reader.ReadLine());
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] info = line.Split('\t');
                        keys.Add(new Key(info[0],Convert.ToInt16(info[1]),Convert.ToInt16(info[2]),Convert.ToInt16(info[3])));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input file, please check if the file is in a correct format!");
                }
                
            }
        }

        public void printKeyboard()
        {
            
        }
    }
}
