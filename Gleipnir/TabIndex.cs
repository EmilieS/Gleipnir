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
    public partial class TabIndex : UserControl
    {
        readonly GeneralPage _page;

        public TabIndex(GeneralPage p)
        {
            _page = p;
            InitializeComponent();

            Tavern.Click += TavernButton_Click;
        }
        internal void ShowUnboughtBuildings()
        {

        }

        private void TavernButton_Click(object sender, EventArgs e)
        {
            _page.OnClickTavern();
            //TODO: check if player can pay
            //TODO: Check if unique
            //TODO: memorise the chosen building choice
            //TODO: display differently and make clikable the possible squares

            //THEN, once the played cliked on the map in a possible square
            //TODO: pay
            //TODO: create building whith correct location.

            //ELSE he cliked elsewhere
            //CANCEL <= delete the memorised building choice
        }

        private void ApothicaryOffice_Click(object sender, EventArgs e)
        {

        }

        private void Chapel_Click(object sender, EventArgs e)
        {

        }

        private void PartyRoom_Click(object sender, EventArgs e)
        {

        }

        private void Baths_Click(object sender, EventArgs e)
        {

        }

        private void Brothel_Click(object sender, EventArgs e)
        {

        }

        private void Theater_Click(object sender, EventArgs e)
        {

        }

        private void Restaurant_Click(object sender, EventArgs e)
        {

        }
    }
}
