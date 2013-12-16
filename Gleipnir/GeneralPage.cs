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
        Game.Game _game;
        traceBox trace;

        private ActionState actionState;
        private BuildingTypeSelected buildingSelected;
        int buildingIndex;
        string traceMessages;
        
        private enum ActionState
        {
            None = 0,
            InPlace = 1
        }
        private enum BuildingTypeSelected
        {
            None = 0,
            Job = 1,
            Family = 2,
            Hobby = 3,
            Specials = 4
        }

        public GeneralPage()
        {
            // Create windows objects
            _home = new HomepageUC();
            _gameMenu = new InGameMenu();
            _actionMenu = new TabIndex(this);
            _stats = new InformationsUC(this);
            _infoBox = new InformationBox();
            _eventFlux = new EventFluxUC();
            _scenarioBox = new ScenarioBox(this);
            InitializeComponent();

            // Show home page
            _home.Launched += IsStarted_Changed;
            _home.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            this.Controls.Add(_home);
            _home.Show();
        }
        
        public void IsStarted_Changed(object sender, PropertyChangedEventArgs e)
        {
            // Hide home page
            _home.Hide();
            //this.Controls.Remove(_home);

            // Create the game
            _game = new Game.Game();

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
                    this.Controls.Add(_grid[i, j]);
                    _grid[i, j].SendToBack();

                    // Set up event handling for it.
                    _grid[i, j].MouseMove += new MouseEventHandler(SquareControl_MouseMove);
                    _grid[i, j].MouseLeave += new EventHandler(SquareControl_MouseLeave);
                    _grid[i, j].Click += new EventHandler(SquareControl_Click);
                }
            }
            // Set the grid
            _board.SetForNewGame();
            UpdateGrid(_board, _grid);
            #endregion

            #region Window elements
            #region Add all elements
            this.Controls.Add(_actionMenu);
            this.Controls.Add(_scenarioBox);
            this.Controls.Add(_stats);
            this.Controls.Add(_infoBox);
            this.Controls.Add(_eventFlux);
            this.Controls.Add(_gameMenu);
            #endregion
            #region Configure all elements
            // ActionMenu
            _actionMenu.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
            _actionMenu.SendToBack();
            _actionMenu.Show();

            // ScenarioBox
            _scenarioBox.Anchor = AnchorStyles.Bottom;
            _scenarioBox.SendToBack();
            _scenarioBox.Show();

            // Stats
            _stats.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            _stats.SendToBack();
            _stats.Show();
            _stats.StepByStep.Visible = true;

            // InfoBox
            _infoBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            _infoBox.SendToBack();
            _infoBox.Show();

            // GameMenu
            _gameMenu.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            _gameMenu.BringToFront();
            _gameMenu.Hide();
            _gameMenu.ExpectGoBackToMenu += GoBackToMenu;

            // EventFluw
            _eventFlux.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            _eventFlux.SendToBack();
            _eventFlux.Show();
            #endregion
            #endregion

            #region Infobox tests
            PushAlert("coucoudfghjkjhgfd", "coucou1");
            PushAlert("coucou2546", "coucou2");
            PushAlert("coucou4543", "coucou3");
            PushAlert("coucou44545", "coucou4");
            PushAlert("coucou54545", "coucou5");
            PushAlert("coucou65454", "coucou6");
            PushAlert("coucou75454", "coucou7");
            PushAlert("coucou8888", "coucou8");
            PushAlert("coucou9", "coucou");
            PushAlert("coucou10", "coucou");
            PushAlert("coucou11", "coucou");
            //PushAlert("coucou12", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            //PushAlert("coucou", "coucou");
            #endregion

            #region Trace Window
            trace = new traceBox();
            trace.Show();
            #endregion
            
            Step();
        }

        internal void LockEverything()
        {
            _actionMenu.Enabled = false;
            _stats.Enabled = false;
            _infoBox.Enabled = false;
            _eventFlux.Enabled = false;
            _scenarioBox.Enabled = false;
        }
        internal void UnLockEverything()
        {
            _actionMenu.Enabled = true;
            _stats.Enabled = true;
            _infoBox.Enabled = true;
            _eventFlux.Enabled = true;
            _scenarioBox.Enabled = true;
        }
        public void GoBackToMenu(object sender, PropertyChangedEventArgs e)
        {
            LockEverything();
            _actionMenu.Hide();
            this.Controls.Remove(_actionMenu);
            _infoBox.Hide();
            this.Controls.Remove(_infoBox);
            _scenarioBox.Hide();
            this.Controls.Remove(_scenarioBox);
            _stats.Hide();
            this.Controls.Remove(_stats);
            _eventFlux.Hide();
            this.Controls.Remove(_eventFlux);

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
        private void PlaceJobHouse(int row, int col)
        {
            _board.UpdateSquares(row, col, Board.JobHouse);
        }
        private void PlaceFamilyHouse(int row, int col)
        {
            int buildingValue = Board.FamilyHouse;
            _board.UpdateSquares(row, col, buildingValue);
        }
        private void PlaceHobby(int row, int col)
        {
            int buildingValue = Board.Hobby;
            _board.UpdateSquares(row, col, buildingValue);
        }
        private void PlaceSpecial(int row, int col)
        {
            int buildingValue = Board.Specials;
            _board.UpdateSquares(row, col, buildingValue);
        }
        private void ShowValidPlaces()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (_board.IsValidSquare(i, j))
                        _grid[i, j].IsValid = true;
                    else
                        _grid[i, j].IsValid = false;
                }
            }
        }
        private void HideValidPlaces()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (_board.IsValidSquare(i, j))
                        _grid[i, j].IsValid = false;
                }
            }
        }

        // Grid Events
        private void SquareControl_MouseMove(object sender, MouseEventArgs e)
        {
            SquareControl squareControl = (SquareControl)sender;

            // If the square is Empty and the player wants place a building
            #region Select Empty
            if (_board.IsValidSquare(squareControl.Row, squareControl.Col) 
                && actionState == ActionState.InPlace)
            {
                // If the square is selected and his last content is empty
                if (!squareControl.IsActive && squareControl.PreviewContents == Board.Empty)
                {
                    // If the show valid place option is active, mark the square
                    if (options.showValidPlaces)
                    {
                        squareControl.IsActive = true;

                        // If the preview place option is not active, update the square display now
                        if (!options.previewSquares)
                            squareControl.Refresh();
                    }

                    // If the preview place option is active, mark the appropriate squares
                    if (options.previewSquares)
                    {
                        // Create a temporary board to make the move on
                        Board copy_board = new Board(_board);

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
            #endregion

            // If the square is a building
            #region Select Building
            else if(_board.IsBuilding(squareControl.Row, squareControl.Col) 
                && actionState == ActionState.None)
            {
                // If the square is selected
                if (!squareControl.IsActive)
                {
                    // If the show valid place option is active, mark the square
                    if (options.showValidPlaces)
                    {
                        squareControl.IsActive = true;

                        // If the preview place option is not active, update the square display now
                        if (!options.previewSquares)
                            squareControl.Refresh();
                    }

                    // If the preview place option is active, mark the appropriate squares
                    if (options.previewSquares)
                    {
                        // Create a temporary board
                        Board copy_board = new Board(_board);

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
            #endregion
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
            if (actionState == ActionState.InPlace)
            {
                SquareControl squareControl = (SquareControl)sender;

                // Hide Valid places and refresh grid
                HideValidPlaces();
                UpdateGrid(_board, _grid);
                
                // If the place is valid, make it
                if (_board.IsValidSquare(squareControl.Row, squareControl.Col))
                {
                    // Restore the cursor
                    squareControl.Cursor = System.Windows.Forms.Cursors.Default;

                    // Place Building
                    if (buildingSelected == BuildingTypeSelected.Job)
                        PlaceJobHouse(squareControl.Row, squareControl.Col);
                    else if (buildingSelected == BuildingTypeSelected.Family)
                        PlaceFamilyHouse(squareControl.Row, squareControl.Col);
                    else if (buildingSelected == BuildingTypeSelected.Hobby)
                        PlaceHobby(squareControl.Row, squareControl.Col);
                    else if (buildingSelected == BuildingTypeSelected.Specials)
                        PlaceSpecial(squareControl.Row, squareControl.Col);

                    // Take Offerings Points
                    //_game.AddOrTakeFromOfferings(-(_game.GetBuilding(buildingIndex).GetPrice));

                    // End Placement
                    actionState = ActionState.None;
                    buildingSelected = BuildingTypeSelected.None;
                    _actionMenu.IsOnBought = false;

                    // Update grid
                    UpdateGrid(_board, _grid);
                }
            }
            else
            {
                return;
            }
        }

        // ActionTab Buildings Methods
        private void FindBuildingSelected(int i)
        {
            if (i >= 0 & i <= 7)
                buildingSelected = BuildingTypeSelected.Job;
            else if (i >= 8 && i <= 12)
                buildingSelected = BuildingTypeSelected.Hobby;
            else if (i == 13 || i == 14)
                buildingSelected = BuildingTypeSelected.Specials;
            else if (i == 15)
                buildingSelected = BuildingTypeSelected.Family;
            else
                buildingSelected = BuildingTypeSelected.None;
        }
        public void OnBoughtBuilding_Click(int index)
        {
            buildingIndex = index;
            int playerOfferings = _game.Offerings;
            var buildng = _game.GetBuildingPrices(index);

            if (!_actionMenu.IsOnBought 
                && buildng.GetPrice <= playerOfferings 
                && actionState == ActionState.None)
            {
                _actionMenu.IsOnBought = true;
                actionState = ActionState.InPlace;
                ShowValidPlaces();
                UpdateGrid(_board, _grid);
                FindBuildingSelected(index);
            }
            else
            {
                HideValidPlaces();
                UpdateGrid(_board, _grid);
                _actionMenu.IsOnBought = false;
                actionState = ActionState.None;
            }
        }

        // InGameButton Method
        public void OnClickMenu()
        {
            if (_gameMenu.IsOpen)
            {
                _gameMenu.Hide();
                _gameMenu.IsOpen = false;
            }
            else
            {
                _gameMenu.Show();
                _gameMenu.IsOpen = true;
            }
        }

        // Game next Step
        internal void Step()
        {
            _game.NextStep();
            foreach (IEvent events in _game.EventList)
            {
                events.Do(this);
                events.PublishMessage(this);
            }

            #region Go FASTER
            /*for (int i = 0; i < 50; i++)
            {
                _game.NextStep();
                foreach (IEvent events in _game.EventList)
                {
                   events.Do(this);
                    events.PublishMessage(this);
                }

            }*/
            #endregion
        }
    }
}