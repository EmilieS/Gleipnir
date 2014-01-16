using Game;
using Game.Buildings;
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
        LoadingUC _loading;
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
        private BuildingsModel buildingSelected;
        private ActionState actionState;
        string traceMessages;

        /// <summary>
        /// Gets the game object
        /// </summary>
        internal Game.Game Game { get { return _game; } }

        /// <summary>
        /// Player state
        /// </summary>
        private enum ActionState
        {
            None = 0,
            InPlace = 1
        }

        public GeneralPage()
        {
            // Create windows objects
            _loading = new LoadingUC();
            _home = new HomepageUC();
            InitializeComponent();

            // Show Logo
            this.Controls.Add(gleipnir_logo);
            gleipnir_logo.SendToBack();
            gleipnir_logo.Show();

            // Hide loading
            this.Controls.Add(_loading);
            _loading.Hide();

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

            // Show loading effects
            _loading.BringToFront();
            _loading.Show();

            // Create the game
            _game = new Game.Game();

            // Create objects
            _gameMenu = new InGameMenu(this);
            _actionMenu = new TabIndex(this);
            _stats = new InformationsUC(this);
            _eventFlux = new EventFluxUC();
            _scenarioBox = new ScenarioBox(this);
            _infoBox = new InformationBox(this);

            #region grid generation
            options = new Options();
            _board = new Board();
            _grid = new SquareControl[20, 32];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    // Create
                    _grid[i, j] = new SquareControl(i, j);
                    // Locate
                    _grid[i, j].Left = 220 + (j * _grid[i, j].Width);
                    _grid[i, j].Top = 40 + (i * _grid[i, j].Height);
                    // Add
                    this.Controls.Add(_grid[i, j]);
                    _grid[i, j].SendToBack();
                    _grid[i, j].Show();

                    // Add events
                    _grid[i, j].MouseMove += new MouseEventHandler(SquareControl_MouseMove);
                    _grid[i, j].MouseLeave += new EventHandler(SquareControl_MouseLeave);
                    _grid[i, j].Click += new EventHandler(SquareControl_Click);
                }
            }
            // Set the grid
            _board.SetForNewGame(_game);
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
            _infoBox.SetNothingSelected();
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

            #region EventBox tests
            /*PushAlert("coucoudfghjkjhgfd", "coucou1");
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
            PushAlert("coucou12", "coucou");
            PushAlert("coucou", "coucou");
            PushAlert("coucou", "coucou");
            PushAlert("coucou", "coucou");*/
            #endregion

            #region Trace Window
            trace = new traceBox();
            //trace.Show();
            #endregion

            // Hide loading effects
            gleipnir_logo.Hide();
            _loading.SendToBack();
            _loading.Hide();

            // Wait the scenario's end
            // LockEverything();

            // Do 1 step
            Step();

        }

        internal TabIndex ActionMenu
        {
            get { return _actionMenu; }
        }

        // Window Methods
        internal void LockEverything()
        {
            _actionMenu.Enabled = false;
            _stats.Enabled = false;
            _eventFlux.Enabled = false;
            _infoBox.Enabled = false;
        }
        internal void UnLockEverything()
        {
            _actionMenu.Enabled = true;
            _stats.Enabled = true;
            _infoBox.Enabled = true;
            _eventFlux.Enabled = true;
        }

        // InGameMenu Events
        public void GoBackToMenu(object sender, PropertyChangedEventArgs e)
        {
            LockEverything();

            // Set double-buffering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            // Remove gameMenu
            this.Controls.Remove(_gameMenu);

            // Remove grid
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 32; j++)
                    this.Controls.Remove(_grid[i, j]);

            // Remove window elements
            this.Controls.Remove(_actionMenu);
            this.Controls.Remove(_infoBox);
            this.Controls.Remove(_scenarioBox);
            this.Controls.Remove(_stats);
            this.Controls.Remove(_eventFlux);

            // Show HomePage
            _home.Show();
            gleipnir_logo.Show();
        }

        // Stats Methods
        public void PushGeneralCoins(int value)
        {
            _stats.offeringsPoints.Text = TransformHighNumberToKnumbers(value);
        }
        public void PushGeneralGold(int value)
        {
            _stats.goldVillage.Text = TransformHighNumberToKnumbers(value);
        }
        public void PushOfferingsPointsPerTick(int value)
        {
            _stats.TaxAmount.Value = value;
            _stats.TaxAmountValue.Text = string.Concat("Quantité : ", value.ToString());
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
            _stats.population.Text = TransformHighNumberToKnumbers(pop);
        }
        public string TransformHighNumberToKnumbers(int value)
        {
            string text = "";
            string nb = value.ToString();

            if (value < 1000)
                text = nb;
            else if (value > 999 && value <= 999999)
            {
                for (int i = 0; i < nb.Count<char>() - 3; i++)
                    text += nb[i];
                text += "K";
            }
            else if (value > 999999 && value <= 999999999)
            {
                for (int i = 0; i < nb.Count<char>() - 6; i++)
                    text += nb[i];
                text += "M";
            }
            else
                text += "+999M";
            return text;
        }

        // TraceWindow Methods
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
        private bool CheckIfFamilyHouseIsPlaced(House house)
        {
            if (house.IsBought == true && house.HorizontalPos >= 0 && house.VerticalPos >= 0 && house.Family != null)
                return true;
            else
                return false;
        }
        public void AddNewFamilyHouse(House house)
        {
            // Check if new family is created
            _board.PlaceRandomlyBuilding(house, Board.FamilyHouseInt);
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
        #region Jobs Buildings Placement
        private void PlaceApothecaryOffice(int row, int col, ApothecaryOffice apo)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Apothecary;

            // Setting the building
            apo.SetCoordinates(row, col);
            apo.IsBought = true;
            village.BuildingsList.Add(apo);
            job.Building = (ApothecaryOffice)apo;
            _board.UpdateSquares(row, col, Board.ApothecaryOfficeInt);
        }
        private void PlaceForge(int row, int col, Forge forge)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Blacksmith;

            // Setting the building
            forge.SetCoordinates(row, col);
            forge.IsBought = true;
            village.BuildingsList.Add(forge);
            job.Building = (Forge)forge;
            _board.UpdateSquares(row, col, Board.ForgeInt);
        }
        private void PlaceUnionOfCrafter(int row, int col, UnionOfCrafter uoc)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Construction_Worker;

            // Setting the building
            uoc.SetCoordinates(row, col);
            uoc.IsBought = true;
            village.BuildingsList.Add(uoc);
            job.Building = (UnionOfCrafter)uoc;
            _board.UpdateSquares(row, col, Board.UnionOfCrafterInt);
        }
        private void PlaceFarm(int row, int col, Farm farm)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Farmer;

            // Setting the building
            farm.SetCoordinates(row, col);
            farm.IsBought = true;
            village.BuildingsList.Add(farm);
            job.Building = (Farm)farm;
            _board.UpdateSquares(row, col, Board.FarmInt);
        }
        private void PlaceRestaurant(int row, int col, Restaurant resto)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Cooker;

            // Setting the building
            resto.SetCoordinates(row, col);
            resto.IsBought = true;
            village.BuildingsList.Add(resto);
            job.Building = (Restaurant)resto;
            _board.UpdateSquares(row, col, Board.RestaurantInt);
        }
        private void PlaceGQ(int row, int col, MilitaryCamp gq)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Militia;

            // Setting the building
            gq.SetCoordinates(row, col);
            gq.IsBought = true;
            village.BuildingsList.Add(gq);
            job.Building = (MilitaryCamp)gq;
            _board.UpdateSquares(row, col, Board.MilitaryCampInt);
        }
        private void PlaceMill(int row, int col, Mill mill)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Miller;

            // Setting the building
            mill.SetCoordinates(row, col);
            mill.IsBought = true;
            village.BuildingsList.Add(mill);
            job.Building = (Mill)mill;
            _board.UpdateSquares(row, col, Board.MillInt);
        }
        private void PlaceClothesShop(int row, int col, ClothesShop shop)
        {
            var village = _game.Villages[0];
            var job = village.JobsList.Tailor;

            // Setting the building
            shop.SetCoordinates(row, col);
            shop.IsBought = true;
            village.BuildingsList.Add(shop);
            job.Building = (ClothesShop)shop;
            _board.UpdateSquares(row, col, Board.ClothesShopsInt);
        }
        #endregion
        #region Hobby Buildings Placement
        private void PlaceBaths(int row, int col, Baths baths)
        {
            var village = _game.Villages[0];

            // Setting the building
            baths.SetCoordinates(row, col);
            baths.IsBought = true;
            village.BuildingsList.Add(baths);
            _board.UpdateSquares(row, col, Board.BathsInt);
        }
        private void PlaceBrothel(int row, int col, Brothel brothel)
        {
            var village = _game.Villages[0];

            // Setting the building
            brothel.SetCoordinates(row, col);
            brothel.IsBought = true;
            village.BuildingsList.Add(brothel);
            _board.UpdateSquares(row, col, Board.BrothelInt);
        }
        private void PlacePartyRoom(int row, int col, PartyRoom party)
        {
            var village = _game.Villages[0];

            // Setting the building
            party.SetCoordinates(row, col);
            party.IsBought = true;
            village.BuildingsList.Add(party);
            _board.UpdateSquares(row, col, Board.PartyRoomInt);
        }
        private void PlaceTavern(int row, int col, Tavern tavern)
        {
            var village = _game.Villages[0];

            // Setting the building
            tavern.SetCoordinates(row, col);
            tavern.IsBought = true;
            village.BuildingsList.Add(tavern);
            _board.UpdateSquares(row, col, Board.TavernInt);
        }
        private void PlaceTheater(int row, int col, Theater theater)
        {
            var village = _game.Villages[0];

            // Setting the building
            theater.SetCoordinates(row, col);
            theater.IsBought = true;
            village.BuildingsList.Add(theater);
            _board.UpdateSquares(row, col, Board.TheaterInt);
        }
        #endregion
        #region Specials Buildings Placement
        private void PlaceSpecial(int row, int col)
        {
            int buildingValue = Board.SpecialsInt;
            _board.UpdateSquares(row, col, buildingValue);
        }
        private void PlaceFamilyHouse(int row, int col, House house)
        {
            var village = _game.Villages[0];

            // Setting the building
            house.SetCoordinates(row, col);
            house.IsBought = true;
            village.AddEmptyHouse(house);
            _board.UpdateSquares(row, col, Board.FamilyHouseInt);
        }
        private void PlaceChapel(int row, int col, Chapel chapel)
        {
            var village = _game.Villages[0];

            // Setting the building
            chapel.SetCoordinates(row, col);
            chapel.IsBought = true;
            village.BuildingsList.Add(chapel);
            _board.UpdateSquares(row, col, Board.ChapelInt);
        }
        private void PlaceOfferingsWarehouse(int row, int col, OfferingWarehouse warehouse)
        {
            var village = _game.Villages[0];

            // Setting the building
            warehouse.SetCoordinates(row, col);
            warehouse.IsBought = true;
            village.BuildingsList.Add(warehouse);
            _board.UpdateSquares(row, col, Board.OfferginsWarehouseInt);
        }
        #endregion
        public void SetEmptySquare(int row, int col)
        {
            _grid[row, col].Contents = Board.EmptyInt;
            _board.UpdateSquares(row, col, Board.EmptyInt);
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
                if (!squareControl.IsActive && squareControl.PreviewContents == Board.EmptyInt)
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
            else if (_board.IsBuilding(squareControl.Row, squareControl.Col)
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
            if (squareControl.PreviewContents != Board.EmptyInt)
            {
                // Clear the move preview
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if (_grid[i, j].PreviewContents != Board.EmptyInt)
                        {
                            _grid[i, j].PreviewContents = Board.EmptyInt;
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
            #region Building placement
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
                    squareControl.Cursor = Cursors.Default;

                    // Place Building
                    if (buildingSelected != null)
                    {
                        // Jobs Buildings
                        if (buildingSelected.GetType() == typeof(ApothecaryOffice))
                            PlaceApothecaryOffice(squareControl.Row, squareControl.Col, (ApothecaryOffice)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Forge))
                            PlaceForge(squareControl.Row, squareControl.Col, (Forge)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(UnionOfCrafter))
                            PlaceUnionOfCrafter(squareControl.Row, squareControl.Col, (UnionOfCrafter)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Restaurant))
                            PlaceRestaurant(squareControl.Row, squareControl.Col, (Restaurant)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Farm))
                            PlaceFarm(squareControl.Row, squareControl.Col, (Farm)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(MilitaryCamp))
                            PlaceGQ(squareControl.Row, squareControl.Col, (MilitaryCamp)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Mill))
                            PlaceMill(squareControl.Row, squareControl.Col, (Mill)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(ClothesShop))
                            PlaceClothesShop(squareControl.Row, squareControl.Col, (ClothesShop)buildingSelected);
                        // Hobby Buildings
                        else if (buildingSelected.GetType() == typeof(Baths))
                            PlaceBaths(squareControl.Row, squareControl.Col, (Baths)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Brothel))
                            PlaceBrothel(squareControl.Row, squareControl.Col, (Brothel)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(PartyRoom))
                            PlacePartyRoom(squareControl.Row, squareControl.Col, (PartyRoom)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Tavern))
                            PlaceTavern(squareControl.Row, squareControl.Col, (Tavern)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Theater))
                            PlaceTheater(squareControl.Row, squareControl.Col, (Theater)buildingSelected);
                        // Specials Buildings
                        else if (buildingSelected.GetType() == typeof(House))
                            PlaceFamilyHouse(squareControl.Row, squareControl.Col, (House)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(Chapel))
                            PlaceChapel(squareControl.Row, squareControl.Col, (Chapel)buildingSelected);
                        else if (buildingSelected.GetType() == typeof(OfferingWarehouse))
                            PlaceOfferingsWarehouse(squareControl.Row, squareControl.Col, (OfferingWarehouse)buildingSelected);
                    }

                    // Take Offerings Points
                    _game.AddOrTakeFromOfferings(-buildingSelected.CostPrice);

                    // Update grid
                    UpdateGrid(_board, _grid);

                    // End Placement
                    actionState = ActionState.None;
                    _actionMenu.IsOnBought = false;
                    buildingSelected = null;
                }
            }
            #endregion
            #region Building Click
            else
            {
                SquareControl squareControl = (SquareControl)sender;

                switch (_grid[squareControl.Row, squareControl.Col].Contents)
                {
                    #region ApothecaryOffices 101
                    case 101: // ApothecaryOffices
                        {
                            foreach (ApothecaryOffice apo in _game.Villages[0].BuildingsList.ApothecaryOfficeList)
                            {
                                int hPos = apo.HorizontalPos;
                                int vPos = apo.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (apo.Job != null && apo.Hp > 0)
                                        _infoBox.SetJobInfo((Apothecary)apo.Job, GamePages.Properties.Resources.Building_ApothecaryOffice);
                                    else
                                        _infoBox.SetDestroyedBuilding(apo);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Forges 102
                    case 102: // Forges
                        {
                            foreach (Forge forge in _game.Villages[0].BuildingsList.ForgeList)
                            {
                                int hPos = forge.HorizontalPos;
                                int vPos = forge.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (forge.Job != null && forge.Hp > 0)
                                        _infoBox.SetJobInfo((Blacksmith)forge.Job, GamePages.Properties.Resources.Building_Forge);
                                    else
                                        _infoBox.SetDestroyedBuilding(forge);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region UnionOfCrafters 103
                    case 103: // Union of Crafter
                        {
                            foreach (UnionOfCrafter uoc in _game.Villages[0].BuildingsList.UnionOfCrafterList)
                            {
                                int hPos = uoc.HorizontalPos;
                                int vPos = uoc.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (uoc.Job != null && uoc.Hp > 0)
                                        _infoBox.SetJobInfo((Construction_Worker)uoc.Job, GamePages.Properties.Resources.Building_UnionOfCrafter);
                                    else
                                        _infoBox.SetDestroyedBuilding(uoc);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Restaurents 104
                    case 104: // Restaurent
                        {
                            foreach (Restaurant resto in _game.Villages[0].BuildingsList.RestaurantList)
                            {
                                int hPos = resto.HorizontalPos;
                                int vPos = resto.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (resto.Job != null && resto.Hp > 0)
                                        _infoBox.SetJobInfo((Cooker)resto.Job, GamePages.Properties.Resources.Building_Restaurant);
                                    else
                                        _infoBox.SetDestroyedBuilding(resto);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Farms 105
                    case 105: // Farms
                        {
                            foreach (Farm farm in _game.Villages[0].BuildingsList.FarmList)
                            {
                                int hPos = farm.HorizontalPos;
                                int vPos = farm.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (farm.Job != null && farm.Hp > 0)
                                        _infoBox.SetJobInfo((Farmer)farm.Job, GamePages.Properties.Resources.Building_Farm);
                                    else
                                        _infoBox.SetDestroyedBuilding(farm);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region MilitaryCamps 106
                    case 106: // MilitaryCamps
                        {
                            foreach (MilitaryCamp gq in _game.Villages[0].BuildingsList.MilitaryCampList)
                            {
                                int hPos = gq.HorizontalPos;
                                int vPos = gq.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (gq.Job != null && gq.Hp > 0)
                                        _infoBox.SetJobInfo((Militia)gq.Job, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(gq);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Mills 107
                    case 107: // Mills
                        {
                            foreach (Mill mill in _game.Villages[0].BuildingsList.MillList)
                            {
                                int hPos = mill.HorizontalPos;
                                int vPos = mill.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (mill.Job != null && mill.Hp > 0)
                                        _infoBox.SetJobInfo((Miller)mill.Job, GamePages.Properties.Resources.Building_Mill);
                                    else
                                        _infoBox.SetDestroyedBuilding(mill);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region ClothesShops 108
                    case 108: // Forges
                        {
                            foreach (ClothesShop shop in _game.Villages[0].BuildingsList.ClothesShopList)
                            {
                                int hPos = shop.HorizontalPos;
                                int vPos = shop.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (shop.Job != null && shop.Hp > 0)
                                        _infoBox.SetJobInfo((Tailor)shop.Job, GamePages.Properties.Resources.Building_ClothesShop);
                                    else
                                        _infoBox.SetDestroyedBuilding(shop);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Baths 201
                    case 201:
                        {
                            foreach (Baths bath in _game.Villages[0].BuildingsList.BathsList)
                            {
                                int hPos = bath.HorizontalPos;
                                int vPos = bath.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (bath.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(bath, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(bath);
                            }
                            break;
                        }
                    #endregion
                    #region Brothel 202
                    case 202:
                        {
                            foreach (Brothel brothel in _game.Villages[0].BuildingsList.BrothelList)
                            {
                                int hPos = brothel.HorizontalPos;
                                int vPos = brothel.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (brothel.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(brothel, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(brothel);
                            }
                            break;
                        }
                    #endregion
                    #region PartyRoom 203
                    case 203:
                        {
                            foreach (PartyRoom party in _game.Villages[0].BuildingsList.PartyRoomList)
                            {
                                int hPos = party.HorizontalPos;
                                int vPos = party.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (party.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(party, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(party);
                            }
                            break;
                        }
                    #endregion
                    #region Tavern 204
                    case 204:
                        {
                            foreach (Tavern tavern in _game.Villages[0].BuildingsList.TavernList)
                            {
                                int hPos = tavern.HorizontalPos;
                                int vPos = tavern.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (tavern.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(tavern, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(tavern);
                            }
                            break;
                        }
                    #endregion
                    #region Theater 205
                    case 205:
                        {
                            foreach (Theater theater in _game.Villages[0].BuildingsList.TheaterList)
                            {
                                int hPos = theater.HorizontalPos;
                                int vPos = theater.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (theater.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(theater, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(theater);
                            }
                            break;
                        }
                    #endregion
                    #region Table 301
                    case 301:
                        {
                            foreach (TablePlace table in _game.Villages[0].BuildingsList.TablePlaceList)
                            {
                                int hPos = table.HorizontalPos;
                                int vPos = table.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (table != null && table.Hp > 0)
                                        _infoBox.SetTableInfo(table);
                                    else
                                        _infoBox.SetDestroyedBuilding(table);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Houses 302
                    case 302:
                        {
                            foreach (House house in _game.Villages[0].BuildingsList.HouseList)
                            {
                                int hPos = house.HorizontalPos;
                                int vPos = house.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (house.Hp > 0)
                                    {
                                        if (house.Family != null)
                                            _infoBox.SetFamilyHouseInfo(house.Family);
                                        else
                                            _infoBox.SetEmptyHouseInfo(house);
                                    }
                                    else
                                        _infoBox.SetDestroyedBuilding(house);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Chapel 303
                    case 303:
                        {
                            foreach (Chapel chapel in _game.Villages[0].BuildingsList.ChapelList)
                            {
                                int hPos = chapel.HorizontalPos;
                                int vPos = chapel.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (chapel.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(chapel, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(chapel);
                            }
                            break;
                        }
                    #endregion
                    #region OfferingWarehouse 304
                    case 304:
                        {
                            foreach (OfferingWarehouse warehouse in _game.Villages[0].BuildingsList.OfferingWarehouseList)
                            {
                                int hPos = warehouse.HorizontalPos;
                                int vPos = warehouse.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                    if (warehouse.Hp > 0)
                                        _infoBox.SetOtherBuildingsInfo(warehouse, GamePages.Properties.Resources.Error);
                                    else
                                        _infoBox.SetDestroyedBuilding(warehouse);
                            }
                            break;
                        }
                    #endregion
                    default:
                        {
                            _infoBox.SetNothingSelected();
                            break;
                        }
                }
            }
            #endregion
        }

        // ActionTab Buildings Methods
        public void OnBoughtBuilding_Click(BuildingsModel building)
        {
            int playerOfferings = _game.Offerings;
            int buildingPrice = building.CostPrice;

            if (!_actionMenu.IsOnBought && buildingPrice <= playerOfferings && actionState == ActionState.None)
            {
                _actionMenu.IsOnBought = true;
                actionState = ActionState.InPlace;
                ShowValidPlaces();
                UpdateGrid(_board, _grid);
                buildingSelected = building;
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
                UnLockEverything();
                _gameMenu.IsOpen = false;
            }
            else
            {
                _gameMenu.Show();
                LockEverything();
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
            UpdateGrid(_board, _grid);
        }
        private void StepWithoutGridUpdate()
        {
            _game.NextStep();
            foreach (IEvent events in _game.EventList)
            {
                events.Do(this);
                events.PublishMessage(this);
            }
        }
        internal void StepX50()
        {
            for (int i = 0; i < 50; i++)
            {
                StepWithoutGridUpdate();
            }
            UpdateGrid(_board, _grid);
        }
    }
}