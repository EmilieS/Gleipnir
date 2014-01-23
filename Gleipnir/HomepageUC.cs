using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace GamePages
{
    public partial class HomepageUC : UserControl  
    {

        GeneralPage _page;

        public HomepageUC(GeneralPage page)
        {
            _page = page;
            InitializeComponent();

        }

        private void new_game(object sender, EventArgs e)
        {
            this.Visible = false;
            _page.StartGame();
        }
        private void loadGame_Click(object sender, EventArgs e)
        {
            if (Game.Serialize.Load() != null)
            {
                this.Visible = false;
                _page.LoadGame();
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void settings_Click(object sender, EventArgs e)
        {
            if (!_page.ParametersBox.IsOpen)
            {
                _page.ShowOrHideParametersBox();
                this.Enabled = false;
            }
        }
    }
}
