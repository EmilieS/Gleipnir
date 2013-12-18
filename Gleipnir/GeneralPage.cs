using Game;
using System;
using System.Collections;
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
        HomepageUC _home;
        InGameMenu _gameMenu;
        TabIndex _actionMenu;
        InformationsUC _stats;
        InformationBox _infoBox;
        EventFluxUC _eventFlux;
        ScenarioBox _scenarioBox;
        Board _board;
        SquareControl[,] _grid;
        Options options;
        Game.Game _startedGame;
        traceBox trace;
        private ActionState actionState;
        string traceMessages;
        
        public enum ActionState
        {
            None = 0,
            InPlace = 1,
            PlacementFinish = 2,
        }

        public GeneralPage()
        {
            _home = new HomepageUC();
            _gameMenu = new InGameMenu();
            _actionMenu = new TabIndex();

            _stats = new InformationsUC(this);
            _eventFlux = new EventFluxUC();
            _scenarioBox = new ScenarioBox(this);
            InitializeComponent();
            _startedGame = new Game.Game();
            _home.Launched += IsStarted_Changed;
            _home.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            this.Controls.Add(_home);
            _home.Show();

            _gameMenu.ExpectGoBackToMenu += GoBackToMenu;
        }
        
        public void IsStarted_Changed(object sender, PropertyChangedEventArgs e)
        {

            Family _family = _startedGame.Villages[0].FamiliesList[0];
            _infoBox = new InformationBox(this, _family);

            this.Controls.Remove(_home);
            _actionMenu.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
            //ActionMenu.Bottom = 3;
            this.Controls.Add(_actionMenu);
            _actionMenu.Show();
            this.Controls.Add(_scenarioBox);
            _scenarioBox.Show();
            this.Controls.Add(_infoBox);
            _infoBox.Show();
            _stats.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.Controls.Add(_stats);
            _stats.Show();
            _eventFlux.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.Controls.Add(_eventFlux);
            _eventFlux.Show();
            _stats.StepByStep.Visible = true;

            trace = new traceBox();
            trace.Show();
            Step();

            // Generate grid & add it
            #region grid generation
            options = new Options();
            _board = new Board();
            _grid = new SquareControl[20, 32];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    // Create it
                    _grid[i, j] = new SquareControl(i, j);
                    // Position it
                    _grid[i, j].Left = 220 + (j * _grid[i, j].Width);
                    _grid[i, j].Top = 40 + (i * _grid[i, j].Height);
                    // Add it
                    Controls.Add(_grid[i, j]);

                    // Set up event handling for it.
                    _grid[i, j].MouseMove += new MouseEventHandler(SquareControl_MouseMove);
                    _grid[i, j].MouseLeave += new EventHandler(SquareControl_MouseLeave);
                    _grid[i, j].Click += new EventHandler(SquareControl_Click);
                }
            }
            _board.SetForNewGame();
            UpdateGrid(_board, _grid);
            #endregion

        }
        internal TabIndex ActionMenu
        {
            get { return _actionMenu; }
        }
        internal void LockEverything()
        {
            _actionMenu.Enabled = false;
            _stats.Enabled = false;
            _eventFlux.Enabled = false;
        }
        internal void UnLockEverything()
        {
            _actionMenu.Enabled = true;
            _stats.Enabled = true;
            _eventFlux.Enabled = true;
        }
        public void GoBackToMenu(object sender, PropertyChangedEventArgs e)
        {
            _actionMenu.Visible = _stats.Visible = false;

            this.Controls.Add(_home);
            _home.Show();
        }
        public void PushGeneralCoins(int value)
        {
            _stats.offeringsPoints.Text = value.ToString();
        }
        public void PushGeneralGold(int value)
        {
            _stats.goldVillage.Text = value.ToString();
        }
        public void PushAlert(string message, string title)
        {
            _eventFlux.CreateNewEventAndShow(message, title);
        }
        public void PushTrace(string message)
        {
            traceMessages = traceMessages + message + @"
";
            trace.traceBoxViewer.Text = traceMessages;
            //PushAlert(message, "PUSHTRACE");//MARCHE
        }
        public void PushGeneralHappiness(double value)
        {
            _stats.happinessVillage.Text = value.ToString("F");
        }
        public void PushGeneralFaith(double value)
        {
            _stats.faithVillage.Text = value.ToString("F");
        }
        public void PushName(string name)
        {
            _stats.villageName.Text = name;
        }
        public void PushPopulation(int pop)
        {
            _stats.population.Text = pop.ToString();
        }

        // Grid Methods
        private void UpdateGrid(Board board, SquareControl[,] grid)
        {
            // Map the current game board to the square controls.
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    grid[i, j].Contents = board.GetSquareContents(i, j);
                    grid[i, j].Refresh();
                }
            }
        }
        private void MakePlacement(int row, int col)
        {
            int buildingValue = Board.JobHouse;
            _board.UpdateSquares(row, col, buildingValue);
            actionState = ActionState.PlacementFinish;
        }

        // Grid Events
        private void SquareControl_MouseMove(object sender, MouseEventArgs e)
        {
            SquareControl squareControl = (SquareControl)sender;

            // If the square is Empty and the player wants place a building
            if (_board.IsValidSquare(squareControl.Row, squareControl.Col) && actionState == ActionState.InPlace)
            {
                // If the square is selected and his last content is empty
                if (!squareControl.IsActive && squareControl.PreviewContents == Board.Empty)
                {
                    // If the show valid place option is active, mark the square
                    if (options.ShowValidPlaces)
                    {
                        squareControl.IsActive = true;

                        // If the preview place option is not active, update the square display now
                        if (!options.PreviewSquares)
                            squareControl.Refresh();
                    }

                    // If the preview place option is active, mark the appropriate squares
                    if (options.PreviewSquares)
                    {
                        // Create a temporary board to make the move on
                        Board copy_board = new Board(_board);
                        copy_board.PlaceBuilding(squareControl.Row, squareControl.Col);

                        // Set up the move preview
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (copy_board.GetSquareContents(i, j) != _board.GetSquareContents(i, j))
                                {
                                    // Set and update the square display
                                    _grid[i, j].PreviewContents = copy_board.GetSquareContents(i, j);
                                    _grid[i, j].Refresh();
                                }
                            }
                        }
                    }
                }

                // Change the cursor
                squareControl.Cursor = Cursors.Hand;
            }
            // If the square is a building
            else if(_board.IsBuilding(squareControl.Row, squareControl.Col))
            {
                // If the square is selected
                if (!squareControl.IsActive)
                {
                    // If the show valid place option is active, mark the square
                    if (options.ShowValidPlaces)
                    {
                        squareControl.IsActive = true;

                        // If the preview place option is not active, update the square display now
                        if (!options.PreviewSquares)
                            squareControl.Refresh();
                    }

                    // If the preview place option is active, mark the appropriate squares
                    if (options.PreviewSquares)
                    {
                        // Create a temporary board
                        Board copy_board = new Board(_board);
                        copy_board.PlaceBuilding(squareControl.Row, squareControl.Col);

                        // Set up the move preview
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (copy_board.GetSquareContents(i, j) != _board.GetSquareContents(i, j))
                                {
                                    // Set and update the square display
                                    _grid[i, j].PreviewContents = copy_board.GetSquareContents(i, j);
                                    _grid[i, j].Refresh();
                                }
                            }
                        }
                    }
                }

                // Change the cursor
                squareControl.Cursor = Cursors.Hand;
            }
        }
        internal void ShowListOfVillager(Family family)
        {
            
        }
        private void SquareControl_MouseLeave(object sender, EventArgs e)
        {
            SquareControl squareControl = (SquareControl)sender;

            // If the square is currently active, deactivate it
            if (squareControl.IsActive)
            {
                squareControl.IsActive = false;
                squareControl.Refresh();
            }

            // If the place is being previewed, clear all affected squares
            if (squareControl.PreviewContents != Board.Empty)
            {
                // Clear the move preview
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (_grid[i, j].PreviewContents != Board.Empty)
                        {
                            _grid[i, j].PreviewContents = Board.Empty;
                            _grid[i, j].Refresh();
                        }
                    }
                }
            }

            // Restore the cursor
            squareControl.Cursor = Cursors.Default;
        }
        private void SquareControl_Click(object sender, EventArgs e)
        {
            // Check the game state to ensure it's the user's turn
            if (actionState != ActionState.InPlace)
                return;

            SquareControl squareControl = (SquareControl)sender;

            // If the place is valid, make it
            if (_board.IsValidSquare(squareControl.Row, squareControl.Col))
            {
                // Restore the cursor
                squareControl.Cursor = System.Windows.Forms.Cursors.Default;

                // Make the move
                MakePlacement(squareControl.Row, squareControl.Col);
            }
        }

        internal void Step()
        {
            _startedGame.NextStep();
            foreach (IEvent events in _startedGame.EventList)
            {
                events.Do(this);
                events.PublishMessage(this);
            }
            //to go faster...
            for (int i = 0; i < 3; i++)
            {
                _startedGame.NextStep();
                foreach (IEvent events in _startedGame.EventList)
                {
                   events.Do(this);
                    events.PublishMessage(this);
                }

            }
            //-----------------
        }
        


    }
}