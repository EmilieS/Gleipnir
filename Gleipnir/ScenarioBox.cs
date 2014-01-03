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

        private void SetScenarionText()
        {
            gameWindow.LockEverything();
            string sentence;
            sentence = engine.ReadScenario();
            if (sentence == null)
            {
                gameWindow.UnLockEverything();
                TextLabel.Text = "Vous êtes à Ragnar";
            }
            else
                TextLabel.Text = sentence;
        }

        private void ScenarioBox_Click(object sender, EventArgs e)
        {
            SetScenarionText();
        }

        private void TextLabel_Click(object sender, EventArgs e)
        {
            SetScenarionText();
        }
    }
}