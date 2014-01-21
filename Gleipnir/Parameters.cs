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
        bool _isOpen;

        public Parameters(GeneralPage generalPage)
        {
            _generalPage = generalPage;
            _generalPage.PropertyChanged += timerValue_value;
            InitializeComponent();

            if (_generalPage.Interval == 0)
                timerValue.Text = "Aucun.";
            else
                timerValue.Text = _generalPage.Interval.ToString() + " ms";
        }

        public bool IsOpen { get { return _isOpen; } set { _isOpen = value; } }

        private void timerValue_value(object sender, EventArgs e)
        {
            if (_generalPage.Interval == 0)
                timerValue.Text = "Aucun.";
            else
                timerValue.Text = _generalPage.Interval.ToString()+" ms";
         }
        private void timerTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _generalPage.Interval = timerTrackBar.Value;
        }

        private void noTimerButton_Click(object sender, EventArgs e)
        {
            _generalPage.Interval = 0;
        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            if (_isOpen)
            {
                this.SendToBack();
                this.Hide();
                _isOpen = false;
            }
        }
    }
}
