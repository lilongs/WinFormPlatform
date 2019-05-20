using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.ChartManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arcScaleFiscalToData.Value = 50000;
            fiscalToData.Text = "50000";
            arcScalePrevYear.Value = 30000;
            fiscalYear.Text = "30000";
        }

    }
}
