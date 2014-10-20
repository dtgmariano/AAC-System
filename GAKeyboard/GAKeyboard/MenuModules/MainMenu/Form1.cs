using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using GAKeyboard.Modules;

namespace GAKeyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random randomseed = new Random();

            string fileLOK = Environment.CurrentDirectory + "\\Load\\list_of_keyboards.txt";
            string filePDF = Environment.CurrentDirectory + "\\Load\\portuguese_dictionary_of_frequency.txt";
            string filePDF4 = Environment.CurrentDirectory + "\\Load\\word_rank_abrev_all_wind4.txt";

            //string fullDirectory = directory.FullName;
            //string fullFile = file.FullName;

            //if (!fullFile.StartsWith(fullDirectory))
            //{
            //    Console.WriteLine("Unable to make relative path");
            //}
            //else
            //{
            //    // The +1 is to avoid the directory separator
            //    Console.WriteLine("Relative path: {0}",
            //                      fullFile.Substring(fullDirectory.Length + 1));
            //}


            //GALayoutGenerator an = new GALayoutGenerator(randomseed, Dinp4filePath);
            //DictionaryAnalyzer da = new DictionaryAnalyzer();
            KeyboardAnalyzer ka = new KeyboardAnalyzer(fileLOK, filePDF4);
            
        }
    }
}
