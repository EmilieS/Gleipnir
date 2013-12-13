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
        InGameMenu menu;
        public InformationsUC(GeneralPage p)
        {
            _page = p;
            menu = new InGameMenu();
            InitializeComponent();

            menuButton.Click += menuButton_Click;
        }

        private void StepByStep_Click(object sender, EventArgs e)
        {
            _page.Step();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            if (menu.IsOpen)
            {
                menu.Hide();
                _page.Controls.Remove(menu);
                menu.IsOpen = false;
            }
            else
            {
                _page.Controls.Add(menu);
                menu.Show();
                menu.IsOpen = true;
            }
        }
    }
}
