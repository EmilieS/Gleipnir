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
        HomepageUC Home = new HomepageUC();
        InGameMenu MenuGame = new InGameMenu();
        TabIndex ActionMenu = new TabIndex();
        InformationsUC Stats = new InformationsUC();
        InformationBox InfoBox = new InformationBox();
        EventFluxUC eventFlux = new EventFluxUC();
        Board board;
        SquareControl[,] grid;
        Options options;
        Game.Game _startedGame;
        private ActionState actionState;

        public enum ActionState
        {
            None = 0,
            InPlace = 1,
            PlacementFinish = 2,
        }

        public GeneralPage()
        {
            InitializeComponent();

            _startedGame = new Game.Game();
            Home.Launched += IsStarted_Changed;
            Home.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            this.Controls.Add(Home);

            Home.Show();

            MenuGame.ExpectGoBackToMenu += GoBackToMenu;
        }
        
        public void IsStarted_Changed(object sender, PropertyChangedEventArgs e)
        {
            this.Controls.Remove(Home);
            ActionMenu.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
            //ActionMenu.Bottom = 3;
            this.Controls.Add(ActionMenu);
            ActionMenu.Show();
            Stats.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            this.Controls.Add(Stats);
            Stats.Show();
            //TODO : Create InfoBox
            InfoBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.Controls.Add(InfoBox);
            InfoBox.Show();
            eventFlux.Anchor = (AnchorStyles.Right);
            this.Controls.Add(eventFlux);
            eventFlux.Show();

            // Generate grid & add it
            #region grid generation
            options = new Options();
            board = new Board();
            grid = new SquareControl[20, 32];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    // Create it
                    grid[i, j] = new SquareControl(i, j);
                    // Position it
                    grid[i, j].Left = 220 + (j * grid[i, j].Width);
                    grid[i, j].Top = 40 + (i * grid[i, j].Height);
                    // Add it
                    Controls.Add(grid[i, j]);

                    // Set up event handling for it.
                    grid[i, j].MouseMove += new MouseEventHandler(SquareControl_MouseMove);
                    grid[i, j].MouseLeave += new EventHandler(SquareControl_MouseLeave);
                    grid[i, j].Click += new EventHandler(SquareControl_Click);
                }
            }
            board.SetForNewGame();
            UpdateGrid(board, grid);
            #endregion
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
            board.UpdateSquares(row, col, buildingValue);
            actionState = ActionState.PlacementFinish;
        }

        // Grid Events
        private void SquareControl_MouseMove(object sender, MouseEventArgs e)
        {
            SquareControl squareControl = (SquareControl)sender;

            // If the square is Empty and the player wants place a building
            if (board.IsValidSquare(squareControl.Row, squareControl.Col) && actionState == ActionState.InPlace)
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
                        Board copy_board = new Board(board);
                        copy_board.PlaceBuilding(squareControl.Row, squareControl.Col);

                        // Set up the move preview
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (copy_board.GetSquareContents(i, j) != board.GetSquareContents(i, j))
                                {
                                    // Set and update the square display
                                    grid[i, j].PreviewContents = copy_board.GetSquareContents(i, j);
                                    grid[i, j].Refresh();
                                }
                            }
                        }
                    }
                }

                // Change the cursor
                squareControl.Cursor = Cursors.Hand;
            }
            // If the square is a building
            else if(board.IsBuilding(squareControl.Row, squareControl.Col))
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
                        Board copy_board = new Board(board);
                        copy_board.PlaceBuilding(squareControl.Row, squareControl.Col);

                        // Set up the move preview
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (copy_board.GetSquareContents(i, j) != board.GetSquareContents(i, j))
                                {
                                    // Set and update the square display
                                    grid[i, j].PreviewContents = copy_board.GetSquareContents(i, j);
                                    grid[i, j].Refresh();
                                }
                            }
                        }
                    }
                }

                // Change the cursor
                squareControl.Cursor = Cursors.Hand;
            }
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
                        if (grid[i, j].PreviewContents != Board.Empty)
                        {
                            grid[i, j].PreviewContents = Board.Empty;
                            grid[i, j].Refresh();
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
            if (board.IsValidSquare(squareControl.Row, squareControl.Col))
            {
                // Restore the cursor
                squareControl.Cursor = System.Windows.Forms.Cursors.Default;

                // Make the move
                MakePlacement(squareControl.Row, squareControl.Col);
            }
        }
    }
}