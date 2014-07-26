using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyboardPerformanceAnalyzer
{
    public partial class AnalyzerViewModel : Form
    {
        AnalyzerModel am;
        Random randomSeed;

        public AnalyzerViewModel()
        {
            InitializeComponent();
            am = new AnalyzerModel(randomSeed);
        }
    }
}
