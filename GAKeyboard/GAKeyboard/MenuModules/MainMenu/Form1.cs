using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAKeyboard.Modules;
namespace GAKeyboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random randomseed = new Random();
            string KLfilePath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\GAKeyboard\\GAKeyboard\\Data\\list_of_keyboards.txt";
            string DfilePath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\GAKeyboard\\GAKeyboard\\Data\\portuguese_dictionary_of_frequency.txt";
            string Dinp4filePath = "C:\\Users\\Biolab\\GitHub\\AAC-System\\GAKeyboard\\GAKeyboard\\Data\\word_rank_abrev_all_wind4.txt";

            //GALayoutGenerator an = new GALayoutGenerator(randomseed, Dinp4filePath);
            //DictionaryAnalyzer da = new DictionaryAnalyzer();
            KeyboardAnalyzer ka = new KeyboardAnalyzer(KLfilePath, Dinp4filePath);
            
        }
    }
}
