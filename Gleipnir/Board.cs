using Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePages
{
    public class Board
    {
        // Differents value for the box
        public static readonly int Empty = 0;
        public static readonly int Forest = 1;
        public static readonly int Water = 2;
        public static readonly int Road = 3;
        public static readonly int Table = 4;
        public static readonly int Farm = 10;
        public static readonly int FamilyHouse = 20;
        public static readonly int JobHouse = 30;
        public static readonly int Hobby = 40;
        public static readonly int Specials = 50;

        // This two-dimensional array represents the squares on the grid.
        private int[,] squares;

        // Create empty grid
        public Board()
        {
            squares = new int[20, 32];

            // Empty all squares
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    squares[i, j] = Empty;
                }
            }
        }
        public Board(Board board)
        {
            // Create the squares and map.
            squares = new int[20, 32];

            // Copy the given board.
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    squares[i, j] = board.squares[i, j];
                }
            }
        }

        /// <summary>
        /// Set the differents box with basics buildings and map objects
        /// </summary>
        public void SetForNewGame(Game.Game game)
        {
            // Fill all the grid with Empty color
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    squares[i, j] = Empty;
                }
            }

            #region Place elements on map
            #region forest
            for (int i = 0; i < 20; i++)
            {
                if (i == 0 || i == 1)
                    for (int j = 0; j < 11; j++)
                        squares[i, j] = Forest;
                else if (i == 2)
                    for (int j = 0; j < 10; j++)
                        squares[i, j] = Forest;
                else if (i == 3 || i == 17)
                    for (int j = 0; j < 9; j++)
                        squares[i, j] = Forest;
                else if (i == 4)
                    for (int j = 0; j < 7; j++)
                        squares[i, j] = Forest;
                else if (i == 10 || i == 11 || i == 16)
                    for (int j = 0; j < 6; j++)
                        squares[i, j] = Forest;
                else if (i == 5 || i == 9 || i == 12 || i == 13 || i == 14)
                    for (int j = 0; j < 5; j++)
                        squares[i, j] = Forest;
                else if (i == 6 || i == 7 || i == 8 || i == 15)
                    for (int j = 0; j < 4; j++)
                        squares[i, j] = Forest;
                else if (i == 18)
                    for (int j = 0; j < 12; j++)
                        squares[i, j] = Forest;
                else if (i == 19)
                    for (int j = 0; j < 15; j++)
                        squares[i, j] = Forest;
            }
            #endregion
            #region farms fields
            for (int i = 19; i > 9; i--)
            {
                if (i == 19)
                    for (int j = 31; j > 17; j--)
                        squares[i, j] = Farm;
                else if (i == 18)
                    for (int j = 31; j > 19; j--)
                        squares[i, j] = Farm;
                else if (i == 17 || i == 16)
                    for (int j = 31; j > 20; j--)
                        squares[i, j] = Farm;
                else if (i == 15)
                    for (int j = 31; j > 21; j--)
                        squares[i, j] = Farm;
                else if (i == 14)
                    for (int j = 31; j > 23; j--)
                        squares[i, j] = Farm;
                else if (i == 13 || i == 12)
                    for (int j = 31; j > 24; j--)
                        squares[i, j] = Farm;
                else if (i == 11 || i == 10)
                    for (int j = 31; j > 25; j--)
                        squares[i, j] = Farm;
            }
            #endregion
            #region river
            for (int i = 0; i < 20; i++)
            {
                if (i == 0)
                    for (int j = 31; j > 29; j--)
                        squares[i, j] = Water;
                else if (i == 1)
                    for (int j = 31; j > 28; j--)
                        squares[i, j] = Water;
                else if (i == 2)
                    for (int j = 28; j < 31; j++)
                        squares[i, j] = Water;
                else if (i == 3)
                    for (int j = 28; j < 30; j++)
                        squares[i, j] = Water;
                else if (i == 4)
                    for (int j = 27; j < 30; j++)
                        squares[i, j] = Water;
                else if (i == 5 || i == 6)
                    for (int j = 27; j < 29; j++)
                        squares[i, j] = Water;
                else if (i == 7)
                    for (int j = 26; j < 28; j++)
                        squares[i, j] = Water;
                else if (i == 9)
                    for (int j = 24; j < 27; j++)
                        squares[i, j] = Water;
                else if (i == 10)
                    for (int j = 24; j < 26; j++)
                        squares[i, j] = Water;
                else if (i == 11)
                    for (int j = 23; j < 26; j++)
                        squares[i, j] = Water;
                else if (i == 12)
                    for (int j = 21; j < 25; j++)
                        squares[i, j] = Water;
                else if (i == 13)
                    for (int j = 20; j < 25; j++)
                        squares[i, j] = Water;
                else if (i == 14)
                    for (int j = 19; j < 24; j++)
                        squares[i, j] = Water;
                else if (i == 15)
                    for (int j = 18; j < 22; j++)
                        squares[i, j] = Water;
                else if (i == 16)
                    for (int j = 17; j < 21; j++)
                        squares[i, j] = Water;
                else if (i == 17)
                    for (int j = 15; j < 21; j++)
                        squares[i, j] = Water;
                else if (i == 18)
                    for (int j = 14; j < 20; j++)
                        squares[i, j] = Water;
                else if (i == 19)
                    for (int j = 15; j < 18; j++)
                        squares[i, j] = Water;
            }
            #endregion
            #region roads
            /*for (int i = 0; i < 20; i++)
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
            foreach (Game.Buildings.House house in game.Villages[0].Buildings.HouseList)
            {
                int hPos;
                int vPos;
                do
                {
                    hPos = RandomPos(20);
                    vPos = RandomPos(32);
                } while (!IsValidSquare(hPos, vPos));
                house.SetCoordinates(hPos, vPos);
                squares[hPos, vPos] = FamilyHouse;
            }
            #endregion
            #region jobs buildings
            squares[3, 13] = JobHouse;
            squares[6, 10] = JobHouse;
            squares[9, 31] = JobHouse;
            #endregion
            #region table
            squares[4, 4] = Table;
            #endregion
            #endregion
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
        /// Check all the grid for empty place
        /// </summary>
        /// <returns></returns>
        public bool HasAnyEmptyPlace()
        {
            // Check all the grid
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 32; j++)
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
            if (squares[row, col] == Empty)
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
            if (squares[row, col] == FamilyHouse ||
                squares[row, col] == JobHouse ||
                squares[row, col] == Hobby ||
                squares[row, col] == Specials ||
                squares[row, col] == Table)
                return true;
            else
                return false;
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

        public int RandomPos(int maxValue)
        {
            var randomNumber = new Random();
            int pos;
            if (maxValue == 20 || maxValue == 32)
            {
                pos = randomNumber.Next(0, maxValue);
            }
            else
                throw new IndexOutOfRangeException("RandomPos Error");
            return pos;
        }
    }
}