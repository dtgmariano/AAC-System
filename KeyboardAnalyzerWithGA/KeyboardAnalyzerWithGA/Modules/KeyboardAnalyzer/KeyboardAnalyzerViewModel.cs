using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyboardAnalyzerWithGA
{
    public partial class KeyboardAnalyzerViewModel : Form
    {
        KeyboardAnalyzerModel ka;
        int criteria_number_suggestion = 4;
        bool hasFrequency = true;
        //string dictionaryFilePath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\KeyboardAnalyzerWithGA\\KeyboardAnalyzerWithGA\\Data\\dictionary_freq_pt_br.txt";
        string dictionaryFilePath = "C:\\Users\\Daniel\\GitHub\\AAC-System\\KeyboardAnalyzerWithGA\\KeyboardAnalyzerWithGA\\Data\\dictionary_freq_pt_br.txt";
        string outputFilePath = "data.txt";
        public KeyboardAnalyzerViewModel()
        {
            InitializeComponent();
            ka = new KeyboardAnalyzerModel(dictionaryFilePath, criteria_number_suggestion, hasFrequency);
            DatabaseExport.exportPerformanceTableTxtFile(ka.tableNecessaryInputs, ka.tableNecessaryEffort, outputFilePath);
        }
    }
}
