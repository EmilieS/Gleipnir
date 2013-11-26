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
    public partial class GeneralPage : Form, IWindow
    {
        HomepageUC Home = new HomepageUC();
        InGameMenu MenuGame = new InGameMenu();
        TabIndex ActionMenu = new TabIndex();
        InformationsUC Stats = new InformationsUC();
        InformationBox InfoBox = new InformationBox();
        EventFluxUC eventFlux = new EventFluxUC();
        Game.Game _startedGame;

        public GeneralPage()
        {
            InitializeComponent();

            _startedGame = new Game.Game();
            Home.Launched += IsStarted_Changed;
            this.Controls.Add(Home);

            Home.Show();

            MenuGame.ExpectGoBackToMenu += GoBackToMenu;
        }
        public void IsStarted_Changed(object sender, PropertyChangedEventArgs e)
        {
            this.Controls.Remove(Home);
            this.Controls.Add(ActionMenu);
            ActionMenu.Show();
            this.Controls.Add(Stats);
            Stats.Show();
            //TODO : Create InfoBox
            this.Controls.Add(InfoBox);
            InfoBox.Show();
            this.Controls.Add(eventFlux);
            eventFlux.Show();
        }

        public void GoBackToMenu(object sender, PropertyChangedEventArgs e)
        {
            ActionMenu.Visible = InfoBox.Visible = Stats.Visible = false;

            this.Controls.Add(Home);
            Home.Show();
        }
        public void PushGeneralCoins(int value)
        {
            Stats.offeringsPoints.Text = value.ToString();
        }
        public void PushGeneralGold(int value)
        {
            Stats.goldVillage.Text = value.ToString();
        }
        public void PushAlert(string message)
        {
            eventFlux.CreateNewEventAndShow(message, null);
        }
        public void PushTrace(string message)
        {

        }
        public void PushGeneralHappiness(double value)
        {
            Stats.happinessVillage.Text = value.ToString();
        }
        public void PushGeneralFaith(double value)
        {
            Stats.faithVillage.Text = value.ToString();
        }
        public void PushName(string name)
        {
            Stats.villageName.Text = name;
        }
        public void PushPopulation(int pop)
        {
            Stats.population.Text = pop.ToString();
        }
    }
}