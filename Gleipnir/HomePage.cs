using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GamePages
{
    public partial class HomePage : Form
    {
        HomepageUC Home = new HomepageUC();
        Game.Game _startedGame;
       
        public HomePage()
        {
            InitializeComponent();

            _startedGame = new Game.Game();
            Home.Launched += IsStarted_Changed;
            this.Controls.Add(Home);
            
            Home.Show();
        }
        public void IsStarted_Changed(object sender, PropertyChangedEventArgs e)
        {
            
                TabIndex ActionMenu = new TabIndex();
                InformationsUC Stats = new InformationsUC();
                InformationBox InfoBox = new InformationBox();

                this.Controls.Remove(Home);

                this.Controls.Add(ActionMenu);
                ActionMenu.Show();
                this.Controls.Add(Stats);
                Stats.Show();
                this.Controls.Add(InfoBox);
                InfoBox.Show();
        }
    }
}
