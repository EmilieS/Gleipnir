using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        HomepageUC Home;
        InGameMenu MenuGame;
        TabIndex ActionMenu;
        InformationsUC Stats;
        InformationBox InfoBox;
        EventFluxUC eventFlux;
        ScenarioBox _scenarioBox;
        Game.Game _startedGame;
        traceBox trace;

        string traceMessages;

        public GeneralPage()
        {
            Home = new HomepageUC();
            MenuGame = new InGameMenu();
            ActionMenu = new TabIndex();
            Stats = new InformationsUC(this);
            InfoBox = new InformationBox();
            eventFlux = new EventFluxUC();
            _scenarioBox = new ScenarioBox(this);
            InitializeComponent();
            _startedGame = new Game.Game();
            Home.Launched += IsStarted_Changed;
            this.Controls.Add(Home);
            Home.Show();
            PushAlert("coucou1", "coucoudfghjkjhgfd");
            PushAlert("coucou2", "coucou2546");
            PushAlert("coucou3", "coucou4543");
            PushAlert("coucou4", "coucou44545");
            PushAlert("coucou5", "coucou54545");
            PushAlert("coucou6", "coucou65454");
            PushAlert("coucou7", "coucou75454");
            PushAlert("coucou8", "coucou85454");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            MenuGame.ExpectGoBackToMenu += GoBackToMenu;
        }
        public void IsStarted_Changed(object sender, PropertyChangedEventArgs e)
        {
            this.Controls.Remove(Home);
            this.Controls.Add(ActionMenu);
            ActionMenu.Show();
            this.Controls.Add(_scenarioBox);
            _scenarioBox.Show();
            this.Controls.Add(Stats);
            Stats.Show();
            Stats.Anchor = AnchorStyles.Right;
            Stats.Anchor = AnchorStyles.Left;
            //TODO : Create InfoBox
            this.Controls.Add(InfoBox);
            InfoBox.Show();
            this.Controls.Add(eventFlux);
            eventFlux.Show();
            eventFlux.Anchor = AnchorStyles.Right;
            Stats.StepByStep.Visible = true;

            trace = new traceBox();
            trace.Show();
            Step();

        }
        internal void LockEverything()
        {
            ActionMenu.Enabled = false;
            Stats.Enabled = false;
            InfoBox.Enabled = false;
            eventFlux.Enabled = false;
        }
        internal void UnLockEverything()
        {
            ActionMenu.Enabled = true;
            Stats.Enabled = true;
            InfoBox.Enabled = true;
            eventFlux.Enabled = true;
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
        public void PushAlert(string message, string title)
        {
            eventFlux.CreateNewEventAndShow(message, title);
        }
        public void PushTrace(string message)
        {
            traceMessages = traceMessages + message + @"
";
            trace.traceBoxViewer.Text = traceMessages;
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

        internal void Step()
        {
            _startedGame.NextStep();
            foreach (IEvent events in _startedGame.EventList)
            {
                events.Do(this);
                events.PublishMessage(this);
            }
        }



    }
}