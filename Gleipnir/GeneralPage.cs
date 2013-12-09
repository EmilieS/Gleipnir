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

            // Generate grid
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
                    /*grid[i, j].MouseMove += new MouseEventHandler(SquareControl_MouseMove);
                    grid[i, j].MouseLeave += new EventHandler(SquareControl_MouseLeave);
                    grid[i, j].Click += new EventHandler(SquareControl_Click);*/
                }
            }
            board.SetForNewGame();
            UpdateGrid(board, grid);
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

        // Grid Events
        /*private void SquareControl_MouseMove(object sender, MouseEventArgs e)
        {
            SquareControl squareControl = (SquareControl)sender;

            // If the square is Empty
            if (board.IsValidSquare(squareControl.Row, squareControl.Col))
            {
                // If the square is selected and his last content is empty
                if (!squareControl.IsActive && squareControl.PreviewContents == Board.Empty)
                {
                    // If the show valid place option is active, mark the
                    // square.
                    if (options.ShowValidPlaces)
                    {
                        squareControl.IsActive = true;

                        // If the preview moves option is not active, update
                        // the square display now.
                        if (!options.PreviewSquares)
                            squareControl.Refresh();
                    }

                    // If the preview moves option is active, mark the
                    // appropriate squares.
                    if (options.PreviewSquares)
                    {
                        // Create a temporary board to make the move on.
                        Board board = new Board(this.board);
                        board.PlaceBuilding(squareControl.Row, squareControl.Col);

                        // Set up the move preview.
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                if (board.GetSquareContents(i, j) != this.board.GetSquareContents(i, j))
                                {
                                    // Set and update the square display.
                                    this.squareControls[i, j].PreviewContents = board.GetSquareContents(i, j);
                                    this.squareControls[i, j].Refresh();
                                }
                    }
                }

                // Change the cursor.
                squareControl.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }*/
        private void SquareControl_MouseLeave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void SquareControl_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}