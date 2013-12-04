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
        GeneralPage actualPage;
        public ScenarioBox(GeneralPage actualGame)
        {
            actualPage = actualGame;
            InitializeComponent();
        }

        private void ScenarioBox_Click(object sender, EventArgs e)
        {
            actualPage.LockEverything();
            string sentence;
            sentence = engine.ReadScenario();
            if (sentence == null)
            {
                this.TextLabel.Text = "Vous êtes à Ragnar";
            }
            else
            {
                this.TextLabel.Text = sentence;
            }
        }

        private void TextLabel_Click(object sender, EventArgs e)
        {
            string sentence ;
            sentence = engine.ReadScenario();
            if (sentence == null)
            {
                this.TextLabel.Text = "Vous êtes à Ragnar";
            }
            else
            {
                this.TextLabel.Text = sentence;
            }
        }


    }
}
