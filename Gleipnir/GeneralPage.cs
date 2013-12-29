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
            _home = new HomepageUC();
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

            // Create the game
            _game = new Game.Game();

            // Create objects
            _gameMenu = new InGameMenu();
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
            trace.Show();
            #endregion

            // Wait the scenario's end
            // LockEverything();

            // Do 1 step
            Step();
        }

        internal TabIndex ActionMenu
        {
            get { return _actionMenu; }
        }
        internal void ShowListOfVillager(Family family)
        {

        }

        // Window Methods
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
            _infoBox.Enabled = true;
            _eventFlux.Enabled = true;
            _scenarioBox.Enabled = true;
        }

        // InGameMenu Events
        public void GoBackToMenu(object sender, PropertyChangedEventArgs e)
        {
            _actionMenu.Visible = _stats.Visible = false;
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
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    _grid[i, j].Hide();
                    this.Controls.Remove(_grid[i, j]);
                }
            }
            _gameMenu.Hide();
            this.Controls.Remove(_gameMenu);

            this.Controls.Add(_home);
            _home.Show();
        }

        // TraceWindow Methods
        public void PushGeneralCoins(int value)
        {
            _stats.offeringsPoints.Text = value.ToString();
        }
        public void PushGeneralGold(int value)
        {
            _stats.goldVillage.Text = value.ToString();
        }
        public void PushOfferingsPointsPerTick(int value)
        {
            _stats.TaxAmount.Value = value;
            _stats.TaxAmountValue.Text = string.Concat("Qtité demandée : ", value.ToString());
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
            // Check if new family is created
            foreach (House house in _game.Villages[0].Buildings.HouseList)
                if (!CheckIfFamilyHouseIsPlaced(house))
                    board.PlaceBuilding(house, Board.FamilyHouseInt);

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
            if (house.IsBought == true && house.HorizontalPos >= 0 && house.VerticalPos >= 0)
                return true;
            else
                return false;
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
        #region Place buildings
        #region Jobs Buildings
        private void PlaceApothecaryOffice(int row, int col, ApothecaryOffice apo)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Apothecary;

            // Setting the building
            apo.SetCoordinates(row, col);
            apo.IsBought = true;
            village.Buildings.Add(apo);
            job.Building = (ApothecaryOffice)apo;
            _board.UpdateSquares(row, col, Board.ApothecaryOfficeInt);
        }
        private void PlaceForge(int row, int col, Forge forge)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Blacksmith;

            // Setting the building
            forge.SetCoordinates(row, col);
            forge.IsBought = true;
            village.Buildings.Add(forge);
            job.Building = (Forge)forge;
            _board.UpdateSquares(row, col, Board.ForgeInt);
        }
        private void PlaceUnionOfCrafter(int row, int col, UnionOfCrafter uoc)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Construction_Worker;

            // Setting the building
            uoc.SetCoordinates(row, col);
            uoc.IsBought = true;
            village.Buildings.Add(uoc);
            job.Building = (UnionOfCrafter)uoc;
            _board.UpdateSquares(row, col, Board.UnionOfCrafterInt);
        }
        private void PlaceFarm(int row, int col, Farm farm)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Farmer;

            // Setting the building
            farm.SetCoordinates(row, col);
            farm.IsBought = true;
            village.Buildings.Add(farm);
            job.Building = (Farm)farm;
            _board.UpdateSquares(row, col, Board.FarmInt);
        }
        private void PlaceRestaurant(int row, int col, Restaurant resto)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Cooker;

            // Setting the building
            resto.SetCoordinates(row, col);
            resto.IsBought = true;
            village.Buildings.Add(resto);
            job.Building = (Restaurant)resto;
            _board.UpdateSquares(row, col, Board.RestaurantInt);
        }
        private void PlaceGQ(int row, int col, MilitaryCamp gq)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Militia;

            // Setting the building
            gq.SetCoordinates(row, col);
            gq.IsBought = true;
            village.Buildings.Add(gq);
            job.Building = (MilitaryCamp)gq;
            _board.UpdateSquares(row, col, Board.MilitaryCampInt);
        }
        private void PlaceMill(int row, int col, Mill mill)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Miller;

            // Setting the building
            mill.SetCoordinates(row, col);
            mill.IsBought = true;
            village.Buildings.Add(mill);
            job.Building = (Mill)mill;
            _board.UpdateSquares(row, col, Board.MillInt);
        }
        private void PlaceClothesShop(int row, int col, ClothesShop shop)
        {
            var village = _game.Villages[0];
            var job = village.Jobs.Tailor;

            // Setting the building
            shop.SetCoordinates(row, col);
            shop.IsBought = true;
            village.Buildings.Add(shop);
            job.Building = (ClothesShop)shop;
            _board.UpdateSquares(row, col, Board.ClothesShopsInt);
        }
        #endregion
        #region Hobby Buildings
        private void PlaceHobby(int row, int col)
        {
            int buildingValue = Board.HobbyInt;
            _board.UpdateSquares(row, col, buildingValue);
        }
        #endregion
        #region Specials Buildings
        private void PlaceSpecial(int row, int col)
        {
            int buildingValue = Board.SpecialsInt;
            _board.UpdateSquares(row, col, buildingValue);
        }
        #endregion
        private void PlaceFamilyHouse(int row, int col, House house)
        {
            house.SetCoordinates(row, col);
            house.IsBought = true;
            _game.Villages[0].AddEmptyHouse(house);
            _board.UpdateSquares(row, col, Board.FamilyHouseInt);
        }
        #endregion

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

                        // Family House
                        else if (buildingSelected.GetType() == typeof(House))
                            PlaceFamilyHouse(squareControl.Row, squareControl.Col, (House)buildingSelected);

                        // Hobby Buildings
                        /*else if (buildingSelected == BuildingTypeSelected.Hobby)
                            PlaceHobby(squareControl.Row, squareControl.Col);*/

                        // Specials Buildings
                        /*else if (buildingSelected == BuildingTypeSelected.Specials)
                            PlaceSpecial(squareControl.Row, squareControl.Col);*/
                    }

                    // Take Offerings Points
                    _game.AddOrTakeFromOfferings(-buildingSelected.CostPrice);

                    // End Placement
                    actionState = ActionState.None;
                    buildingSelected = null;
                    _actionMenu.IsOnBought = false;

                    // Update grid
                    UpdateGrid(_board, _grid);
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
                            foreach (ApothecaryOffice apo in _game.Villages[0].Buildings.ApothecaryOfficeList)
                            {
                                int hPos = apo.HorizontalPos;
                                int vPos = apo.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (apo.Job != null)
                                        _infoBox.SetJobInfo((Apothecary)apo.Job);
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
                            foreach (Forge forge in _game.Villages[0].Buildings.ForgeList)
                            {
                                int hPos = forge.HorizontalPos;
                                int vPos = forge.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (forge.Job != null)
                                        _infoBox.SetJobInfo((Blacksmith)forge.Job);
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
                            foreach (UnionOfCrafter uoc in _game.Villages[0].Buildings.UnionOfCrafterList)
                            {
                                int hPos = uoc.HorizontalPos;
                                int vPos = uoc.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (uoc.Job != null)
                                        _infoBox.SetJobInfo((Construction_Worker)uoc.Job);
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
                            foreach (Restaurant resto in _game.Villages[0].Buildings.RestaurantList)
                            {
                                int hPos = resto.HorizontalPos;
                                int vPos = resto.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (resto.Job != null)
                                        _infoBox.SetJobInfo((Cooker)resto.Job);
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
                            foreach (Farm farm in _game.Villages[0].Buildings.FarmList)
                            {
                                int hPos = farm.HorizontalPos;
                                int vPos = farm.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (farm.Job != null)
                                        _infoBox.SetJobInfo((Farmer)farm.Job);
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
                            foreach (MilitaryCamp gq in _game.Villages[0].Buildings.MilitaryCampList)
                            {
                                int hPos = gq.HorizontalPos;
                                int vPos = gq.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (gq.Job != null)
                                        _infoBox.SetJobInfo((Militia)gq.Job);
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
                            foreach (Mill mill in _game.Villages[0].Buildings.MillList)
                            {
                                int hPos = mill.HorizontalPos;
                                int vPos = mill.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (mill.Job != null)
                                        _infoBox.SetJobInfo((Miller)mill.Job);
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
                            foreach (ClothesShop shop in _game.Villages[0].Buildings.ClothesShopList)
                            {
                                int hPos = shop.HorizontalPos;
                                int vPos = shop.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (shop.Job != null)
                                        _infoBox.SetJobInfo((Tailor)shop.Job);
                                    else
                                        _infoBox.SetDestroyedBuilding(shop);
                                }
                            }
                            break;
                        }
                    #endregion
                    #region Table 301
                    case 301:
                        {
                            foreach (TablePlace table in _game.Villages[0].Buildings.TablePlaceList)
                            {
                                int hPos = table.HorizontalPos;
                                int vPos = table.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (table != null)
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
                            foreach (House house in _game.Villages[0].Buildings.HouseList)
                            {
                                int hPos = house.HorizontalPos;
                                int vPos = house.VerticalPos;
                                if (hPos == squareControl.Row && vPos == squareControl.Col)
                                {
                                    if (house.Family != null)
                                        _infoBox.SetFamilyHouseInfo(house.Family);
                                    else
                                        _infoBox.SetEmptyHouseInfo(house);
                                }
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
            // buildingIndex = index;
            int playerOfferings = _game.Offerings;
            int buildingPrice = building.CostPrice;

            if (!_actionMenu.IsOnBought
                && buildingPrice <= playerOfferings
                && actionState == ActionState.None)
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
            UpdateGrid(_board, _grid);
        }
        internal void StepX50()
        {
            for (int i = 0; i < 50; i++)
            {
                Step();
            }
        }
    }
}