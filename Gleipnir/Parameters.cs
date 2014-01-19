using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePages
{
    public partial class Parameters : UserControl
    {
        GeneralPage _generalPage;
        public Parameters(GeneralPage generalPage)
        {
            _generalPage = generalPage;
            _generalPage.PropertyChanged += label2_value;
            InitializeComponent();
            label2.Text = _generalPage.Interval.ToString();
        }
        private void label2_value(object sender, EventArgs e)
        {
            label2.Text = _generalPage.Interval.ToString();
         }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //label2.Text = trackBar1.Value.ToString();
            _generalPage.Interval = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _generalPage.Interval = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //quitter!
        }
    }
}
