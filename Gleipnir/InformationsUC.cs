using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace GamePages
{
    public partial class InformationsUC : UserControl
    {
        readonly GeneralPage _page;
        bool isPaused;

        public InformationsUC(GeneralPage p)
        {
            _page = p;
            InitializeComponent();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                pauseButton.BackgroundImage = GamePages.Properties.Resources.ButtonIcon_Pause;
                isPaused = false;
                _page.RestartTimer();
            }
            else
            {
                pauseButton.BackgroundImage = GamePages.Properties.Resources.ButtonIcon_start;
                isPaused = true;
                _page.PauseTimer();
            }
        }

        private void StepByStep_Click(object sender, EventArgs e)
        {
            _page.Step();
        }

        private void StepX50_Click(object sender, EventArgs e)
        {
            _page.StepX50();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            _page.OnClickMenu();
        }

        private void TaxAmount_ValueChanged(object sender, EventArgs e)
        {          
            _page.TheGame.Villages[0].SetOfferingsPoints(TaxAmount.Value);
            TaxAmountValue.Text = "Quantité : " + _page.TransformHighNumberToKnumbers(TaxAmount.Value);
        }
    }
}