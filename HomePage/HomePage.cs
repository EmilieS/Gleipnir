using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePages
{
    public partial class HomePage : Form
    {
        Game.Game _startedGame;
        public HomePage()
        {
            InitializeComponent();
            _startedGame = new Game.Game();
        }

        private void new_game(object sender, EventArgs e)
        {
            Form view = new GamePage(_startedGame);
            view.Show();
        }
    }
}
