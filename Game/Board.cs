﻿using Game.Buildings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Board
    {
        // Landscape
        public static readonly int EmptyInt = 0;
        public static readonly int ForestInt = 1;
        public static readonly int WaterInt = 2;
        public static readonly int RoadInt = 3;
        public static readonly int FarmFieldInt = 4;
        // Jobs Buildings
        public static readonly int JobHouseInt = 100;
        public static readonly int ApothecaryOfficeInt = 101;
        public static readonly int ForgeInt = 102;
        public static readonly int UnionOfCrafterInt = 103;
        public static readonly int RestaurantInt = 104;
        public static readonly int FarmInt = 105;
        public static readonly int MilitaryCampInt = 106;
        public static readonly int MillInt = 107;
        public static readonly int ClothesShopsInt = 108;
        // Hobbies Buildings
        public static readonly int HobbyInt = 200;
        public static readonly int BathsInt = 201;
        public static readonly int BrothelInt = 202;
        public static readonly int PartyRoomInt = 203;
        public static readonly int TavernInt = 204;
        public static readonly int TheaterInt = 205;
        // Specials Buildings
        public static readonly int SpecialsInt = 300;
        public static readonly int TableInt = 301;
        public static readonly int FamilyHouseInt = 302;
        public static readonly int ChapelInt = 303;
        public static readonly int OfferginsWarehouseInt = 304;

        // This two-dimensional array represents the squares on the grid.
        private int[,] squares;

        // Grid width & height
        public static readonly int GridMaxRow = 20;
        public static readonly int GridMaxCol = 32;

        // RandomPlace
        public Random randomNumber;

        // Create empty grid
        public Board()
        {
            squares = new int[GridMaxRow, GridMaxCol];
            randomNumber = new Random();

            // Empty all squares
            for (int i = 0; i < GridMaxRow; i++)
            {
                for (int j = 0; j < GridMaxCol; j++)
                {
                    squares[i, j] = EmptyInt;
                }
            }
        }
        public Board(Board board)
        {
            // Create the squares and map.
            squares = new int[GridMaxRow, GridMaxCol];
            randomNumber = new Random();

            // Copy the given board.
            for (int i = 0; i < GridMaxRow; i++)
            {
                for (int j = 0; j < GridMaxCol; j++)
                {
                    squares[i, j] = board.squares[i, j];
                }
            }
        }

        /// <summary>
        /// Set the differents box with basics buildings and map objects
        /// </summary>
        public void SetForNewGame(Game game)
        {
            // Fill all the grid with Empty color
            for (int i = 0; i < GridMaxRow; i++)
                for (int j = 0; j < GridMaxCol; j++)
                    squares[i, j] = EmptyInt;

            #region Place elements on map
            #region forest
            for (int i = 0; i < GridMaxRow; i++)
            {
                if (i == 0 || i == 1)
                    for (int j = 0; j < 11; j++)
                        squares[i, j] = ForestInt;
                else if (i == 2)
                    for (int j = 0; j < 10; j++)
                        squares[i, j] = ForestInt;
                else if (i == 3 || i == 17)
                    for (int j = 0; j < 9; j++)
                        squares[i, j] = ForestInt;
                else if (i == 4)
                    for (int j = 0; j < 7; j++)
                        squares[i, j] = ForestInt;
                else if (i == 10 || i == 11 || i == 16)
                    for (int j = 0; j < 6; j++)
                        squares[i, j] = ForestInt;
                else if (i == 5 || i == 9 || i == 12 || i == 13 || i == 14)
                    for (int j = 0; j < 5; j++)
                        squares[i, j] = ForestInt;
                else if (i == 6 || i == 7 || i == 8 || i == 15)
                    for (int j = 0; j < 4; j++)
                        squares[i, j] = ForestInt;
                else if (i == 18)
                    for (int j = 0; j < 12; j++)
                        squares[i, j] = ForestInt;
                else if (i == 19)
                    for (int j = 0; j < 15; j++)
                        squares[i, j] = ForestInt;
            }
            #endregion
            #region farms fields
            for (int i = 19; i > 9; i--)
            {
                if (i == 19)
                    for (int j = 31; j > 17; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 18)
                    for (int j = 31; j > 19; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 17 || i == 16)
                    for (int j = 31; j > 20; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 15)
                    for (int j = 31; j > 21; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 14)
                    for (int j = 31; j > 23; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 13 || i == 12)
                    for (int j = 31; j > 24; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 11 || i == 10)
                    for (int j = 31; j > 25; j--)
                        squares[i, j] = FarmFieldInt;
            }
            #endregion
            #region river
            for (int i = 0; i < GridMaxRow; i++)
            {
                if (i == 0)
                    for (int j = 31; j > 29; j--)
                        squares[i, j] = WaterInt;
                else if (i == 1)
                    for (int j = 31; j > 28; j--)
                        squares[i, j] = WaterInt;
                else if (i == 2)
                    for (int j = 28; j < 31; j++)
                        squares[i, j] = WaterInt;
                else if (i == 3)
                    for (int j = 28; j < 30; j++)
                        squares[i, j] = WaterInt;
                else if (i == 4)
                    for (int j = 27; j < 30; j++)
                        squares[i, j] = WaterInt;
                else if (i == 5 || i == 6)
                    for (int j = 27; j < 29; j++)
                        squares[i, j] = WaterInt;
                else if (i == 7)
                    for (int j = 26; j < 28; j++)
                        squares[i, j] = WaterInt;
                else if (i == 9)
                    for (int j = 24; j < 27; j++)
                        squares[i, j] = WaterInt;
                else if (i == 10)
                    for (int j = 24; j < 26; j++)
                        squares[i, j] = WaterInt;
                else if (i == 11)
                    for (int j = 23; j < 26; j++)
                        squares[i, j] = WaterInt;
                else if (i == 12)
                    for (int j = 21; j < 25; j++)
                        squares[i, j] = WaterInt;
                else if (i == 13)
                    for (int j = 20; j < 25; j++)
                        squares[i, j] = WaterInt;
                else if (i == 14)
                    for (int j = 19; j < 24; j++)
                        squares[i, j] = WaterInt;
                else if (i == 15)
                    for (int j = 18; j < 22; j++)
                        squares[i, j] = WaterInt;
                else if (i == 16)
                    for (int j = 17; j < 21; j++)
                        squares[i, j] = WaterInt;
                else if (i == 17)
                    for (int j = 15; j < 21; j++)
                        squares[i, j] = WaterInt;
                else if (i == 18)
                    for (int j = 14; j < 20; j++)
                        squares[i, j] = WaterInt;
                else if (i == 19)
                    for (int j = 15; j < 18; j++)
                        squares[i, j] = WaterInt;
            }
            #endregion
            #region roads
            /*for (int i = 0; i < GridWidth; i++)
                if (i == 4)
                    squares[i, 13] = Road;
                else if (i == 5)
                    squares[i, 13] = Road;
                else if (i == 6)
                {
                    for (int j = 11; j < 14; j++)
                        squares[i, j] = Road;
                    squares[i, 20] = Road;
                }
                else if (i == 7)
                {
                    for (int j = 13; j < 15; j++)
                        squares[i, j] = Road;
                    squares[i, 20] = Road;
                }
                else if (i == 8)
                {
                    for (int j = 11; j < 14; j++)
                        squares[i, j] = Road;
                    for (int j = 19; j < 32; j++)
                        squares[i, j] = Road;
                }
                else if (i == 9)
                    for (int j = 0; j < 20; j++)
                        squares[i, j] = Road;
                else if (i == 10)
                    squares[i, 13] = squares[i, 19] = Road;
                else if (i == 11)
                    squares[i, 13] = Road;
                else if (i == 12)
                    for (int j = 12; j < 14; j++)
                        squares[i, j] = Road;*/
            #endregion
            #region families houses
            foreach (House house in game.Villages[0].BuildingsList.HouseList)
                if(!house.IsBought)
                    PlaceRandomlyBuilding(house, FamilyHouseInt);
            #endregion
            #region jobs buildings
            foreach (Forge forge in game.Villages[0].BuildingsList.ForgeList)
                if (forge != null && !forge.IsBought)
                    PlaceRandomlyBuilding(forge, ForgeInt);
            foreach (Farm farm in game.Villages[0].BuildingsList.FarmList)
                if (farm != null && !farm.IsBought)
                    PlaceRandomlyBuilding(farm, FarmInt);
            foreach (UnionOfCrafter uoc in game.Villages[0].BuildingsList.UnionOfCrafterList)
                if (uoc != null && !uoc.IsBought)
                    PlaceRandomlyBuilding(uoc, UnionOfCrafterInt);
            #endregion
            #region table
            game.Villages[0].BuildingsList.TablePlaceList[0].SetCoordinates(4, 4);
            squares[4, 4] = TableInt;
            game.Villages[0].BuildingsList.TablePlaceList[0].IsBought = true;
            #endregion
            #endregion
        }
        /// <summary>
        /// Gets and sets grid from saved game
        /// </summary>
        /// <param name="game"></param>
        public void SetLoadGame(Game game)
        {
            // Fill all the grid with Empty color
            for (int i = 0; i < GridMaxRow; i++)
            {
                for (int j = 0; j < GridMaxCol; j++)
                {
                    squares[i, j] = EmptyInt;
                }
            }

            // Landscape
            #region forest
            for (int i = 0; i < GridMaxRow; i++)
            {
                if (i == 0 || i == 1)
                    for (int j = 0; j < 11; j++)
                        squares[i, j] = ForestInt;
                else if (i == 2)
                    for (int j = 0; j < 10; j++)
                        squares[i, j] = ForestInt;
                else if (i == 3 || i == 17)
                    for (int j = 0; j < 9; j++)
                        squares[i, j] = ForestInt;
                else if (i == 4)
                    for (int j = 0; j < 7; j++)
                        squares[i, j] = ForestInt;
                else if (i == 10 || i == 11 || i == 16)
                    for (int j = 0; j < 6; j++)
                        squares[i, j] = ForestInt;
                else if (i == 5 || i == 9 || i == 12 || i == 13 || i == 14)
                    for (int j = 0; j < 5; j++)
                        squares[i, j] = ForestInt;
                else if (i == 6 || i == 7 || i == 8 || i == 15)
                    for (int j = 0; j < 4; j++)
                        squares[i, j] = ForestInt;
                else if (i == 18)
                    for (int j = 0; j < 12; j++)
                        squares[i, j] = ForestInt;
                else if (i == 19)
                    for (int j = 0; j < 15; j++)
                        squares[i, j] = ForestInt;
            }
            #endregion
            #region farms fields
            for (int i = 19; i > 9; i--)
            {
                if (i == 19)
                    for (int j = 31; j > 17; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 18)
                    for (int j = 31; j > 19; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 17 || i == 16)
                    for (int j = 31; j > 20; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 15)
                    for (int j = 31; j > 21; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 14)
                    for (int j = 31; j > 23; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 13 || i == 12)
                    for (int j = 31; j > 24; j--)
                        squares[i, j] = FarmFieldInt;
                else if (i == 11 || i == 10)
                    for (int j = 31; j > 25; j--)
                        squares[i, j] = FarmFieldInt;
            }
            #endregion
            #region river
            for (int i = 0; i < GridMaxRow; i++)
            {
                if (i == 0)
                    for (int j = 31; j > 29; j--)
                        squares[i, j] = WaterInt;
                else if (i == 1)
                    for (int j = 31; j > 28; j--)
                        squares[i, j] = WaterInt;
                else if (i == 2)
                    for (int j = 28; j < 31; j++)
                        squares[i, j] = WaterInt;
                else if (i == 3)
                    for (int j = 28; j < 30; j++)
                        squares[i, j] = WaterInt;
                else if (i == 4)
                    for (int j = 27; j < 30; j++)
                        squares[i, j] = WaterInt;
                else if (i == 5 || i == 6)
                    for (int j = 27; j < 29; j++)
                        squares[i, j] = WaterInt;
                else if (i == 7)
                    for (int j = 26; j < 28; j++)
                        squares[i, j] = WaterInt;
                else if (i == 9)
                    for (int j = 24; j < 27; j++)
                        squares[i, j] = WaterInt;
                else if (i == 10)
                    for (int j = 24; j < 26; j++)
                        squares[i, j] = WaterInt;
                else if (i == 11)
                    for (int j = 23; j < 26; j++)
                        squares[i, j] = WaterInt;
                else if (i == 12)
                    for (int j = 21; j < 25; j++)
                        squares[i, j] = WaterInt;
                else if (i == 13)
                    for (int j = 20; j < 25; j++)
                        squares[i, j] = WaterInt;
                else if (i == 14)
                    for (int j = 19; j < 24; j++)
                        squares[i, j] = WaterInt;
                else if (i == 15)
                    for (int j = 18; j < 22; j++)
                        squares[i, j] = WaterInt;
                else if (i == 16)
                    for (int j = 17; j < 21; j++)
                        squares[i, j] = WaterInt;
                else if (i == 17)
                    for (int j = 15; j < 21; j++)
                        squares[i, j] = WaterInt;
                else if (i == 18)
                    for (int j = 14; j < 20; j++)
                        squares[i, j] = WaterInt;
                else if (i == 19)
                    for (int j = 15; j < 18; j++)
                        squares[i, j] = WaterInt;
            }
            #endregion
            #region roads
            /*for (int i = 0; i < GridWidth; i++)
                if (i == 4)
                    squares[i, 13] = Road;
                else if (i == 5)
                    squares[i, 13] = Road;
                else if (i == 6)
                {
                    for (int j = 11; j < 14; j++)
                        squares[i, j] = Road;
                    squares[i, 20] = Road;
                }
                else if (i == 7)
                {
                    for (int j = 13; j < 15; j++)
                        squares[i, j] = Road;
                    squares[i, 20] = Road;
                }
                else if (i == 8)
                {
                    for (int j = 11; j < 14; j++)
                        squares[i, j] = Road;
                    for (int j = 19; j < 32; j++)
                        squares[i, j] = Road;
                }
                else if (i == 9)
                    for (int j = 0; j < 20; j++)
                        squares[i, j] = Road;
                else if (i == 10)
                    squares[i, 13] = squares[i, 19] = Road;
                else if (i == 11)
                    squares[i, 13] = Road;
                else if (i == 12)
                    for (int j = 12; j < 14; j++)
                        squares[i, j] = Road;*/
            #endregion

            var buildings = game.Villages[0].BuildingsList;

            // Place building
            foreach (ApothecaryOffice build in buildings.ApothecaryOfficeList)
                squares[build.HorizontalPos, build.VerticalPos] = ApothecaryOfficeInt;
            foreach (Baths build in buildings.BathsList)
                squares[build.HorizontalPos, build.VerticalPos] = BathsInt;
            foreach (Brothel build in buildings.BrothelList)
                squares[build.HorizontalPos, build.VerticalPos] = BrothelInt;
            foreach (Chapel build in buildings.ChapelList)
                squares[build.HorizontalPos, build.VerticalPos] = ChapelInt;
            foreach (ClothesShop build in buildings.ClothesShopList)
                squares[build.HorizontalPos, build.VerticalPos] = ClothesShopsInt;
            foreach (Farm build in buildings.FarmList)
                squares[build.HorizontalPos, build.VerticalPos] = FarmInt;
            foreach (Forge build in buildings.ForgeList)
                squares[build.HorizontalPos, build.VerticalPos] = ForgeInt;
            foreach (House build in buildings.HouseList)
                squares[build.HorizontalPos, build.VerticalPos] = FamilyHouseInt;
            foreach (MilitaryCamp build in buildings.MilitaryCampList)
                squares[build.HorizontalPos, build.VerticalPos] = MilitaryCampInt;
            foreach (Mill build in buildings.MillList)
                squares[build.HorizontalPos, build.VerticalPos] = MillInt;
            foreach (OfferingWarehouse build in buildings.OfferingWarehouseList)
                squares[build.HorizontalPos, build.VerticalPos] = OfferginsWarehouseInt;
            foreach (PartyRoom build in buildings.PartyRoomList)
                squares[build.HorizontalPos, build.VerticalPos] = PartyRoomInt;
            foreach (Restaurant build in buildings.RestaurantList)
                squares[build.HorizontalPos, build.VerticalPos] = RestaurantInt;
            foreach (TablePlace build in buildings.TablePlaceList)
                squares[build.HorizontalPos, build.VerticalPos] = TableInt;
            foreach (Tavern build in buildings.TavernList)
                squares[build.HorizontalPos, build.VerticalPos] = TavernInt;
            foreach (Theater build in buildings.TheaterList)
                squares[build.HorizontalPos, build.VerticalPos] = TheaterInt;
            foreach (UnionOfCrafter build in buildings.UnionOfCrafterList)
                squares[build.HorizontalPos, build.VerticalPos] = UnionOfCrafterInt;
        }

        /// <summary>
        /// Gets the content of the grid box
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int GetSquareContents(int row, int col)
        {
            return squares[row, col];
        }
        /// <summary>
        /// Update the square content
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void UpdateSquares(int row, int col, int value)
        {
            squares[row, col] = value;
        }

        /// <summary>
        /// Check all the grid for empty place
        /// </summary>
        /// <returns></returns>
        public bool HasAnyEmptyPlace()
        {
            // Check all the grid
            for (int i = 0; i < GridMaxRow; i++)
                for (int j = 0; j < GridMaxCol; j++)
                    if (IsValidSquare(i, j))
                        return true;
            // No place
            return false;
        }
        /// <summary>
        /// Check if one square is empty
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsValidSquare(int row, int col)
        {
            if (squares[row, col] == EmptyInt)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Check if the square have a building
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsBuilding(int row, int col)
        {
            if (squares[row, col] >= 100)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get a number between 0 and the maxValue
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private int RandomPos(int maxValue)
        {
            int pos;
            if (maxValue == GridMaxRow || maxValue == GridMaxCol)
                pos = randomNumber.Next(0, maxValue);
            else
                throw new IndexOutOfRangeException(@"(board, RandomPos) RandomPos Error");
            return pos;
        }
        /// <summary>
        /// Place randomly a buidling
        /// </summary>
        /// <param name="building"></param>
        public void PlaceRandomlyBuilding(BuildingsModel building, int value)
        {
            if (!building.IsBought)
            {
                int hPos;
                int vPos;
                do
                {
                    hPos = RandomPos(GridMaxRow);
                    vPos = RandomPos(GridMaxCol);
                } while (!IsValidSquare(hPos, vPos));

                building.SetCoordinates(hPos, vPos);
                squares[hPos, vPos] = value;
                building.IsBought = true;
            }
        }
    }
}