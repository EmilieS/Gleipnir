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
    public partial class ScenarioBox : UserControl
    {
        ScenarioEngine engine = new ScenarioEngine();
        GeneralPage gameWindow;

        public ScenarioBox(GeneralPage actualGame)
        {
            gameWindow = actualGame;
            InitializeComponent();
        }

        private void SetScenarioText()
        {
            gameWindow.LockEverything();
            string sentence;
            sentence = engine.ReadScenario();
            if (sentence == null)
            {
                gameWindow.UnLockEverything();
                TextLabel.Text = "Vous êtes à Ragnar";
                this.pictureBox1.Visible = false;
                this.pictureBox1.Enabled = false;
            }
            else
                TextLabel.Text = sentence;
        }

        public void GameLostText()
        {
            TextLabel.Text = "Vous avez perdu !";
            this.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetScenarioText();
        }

      
    }
}