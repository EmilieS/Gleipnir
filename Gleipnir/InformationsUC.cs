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
        // TODO : Complete the Transitions, Create ingame menu, go back to a Main menu
        InGameMenu Menu;
        public InformationsUC()
        {
            Menu = new InGameMenu();
            InitializeComponent();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            this.Controls.Add(Menu);
            Menu.Show();
        }

    }
}
