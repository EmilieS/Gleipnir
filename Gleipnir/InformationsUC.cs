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
    public partial class InformationsUC : UserControl
    {
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
