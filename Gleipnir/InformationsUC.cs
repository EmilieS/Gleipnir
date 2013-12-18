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
    public partial class InformationsUC : UserControl // create an interface to engine advance
    {
        readonly GeneralPage _page;

        // TODO : Complete the Transitions, Create ingame menu, go back to a Main menu
        public InformationsUC(GeneralPage p)
        {
            _page = p;
            InitializeComponent();

            menuButton.Click += menuButton_Click;
        }

        private void StepByStep_Click(object sender, EventArgs e)
        {
            _page.Step();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            _page.OnClickMenu();
        }

        private void changeGoldOfferings_Click(object sender, EventArgs e)
        {
           
        }

        private void TaxAmount_ValueChanged(object sender, EventArgs e)
        {          
            _page.StartedGame.Villages[0].SetOfferingsPoints(TaxAmount.Value);
        }

        private void TaxAmountValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
