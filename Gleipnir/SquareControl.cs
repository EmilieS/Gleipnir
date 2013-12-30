using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GamePages
{
    public partial class SquareControl : UserControl
    {
        #region Background Colors
        // Background for right zone to place a building
        public static readonly Color ValidPlaceBackColorDefault = Color.FromArgb(75, 200, 30);
        public static readonly Color ActivePlaceBackColorDefault = Color.FromArgb(50, 130, 20);

        // Default backgrounds
        public static readonly Color EmptyBackColorDefault = Color.FromArgb(50, 130, 20);
        public static readonly Color ForestBackColorDefault = Color.FromArgb(20, 130, 75);
        public static readonly Color WaterBackColorDefault = Color.FromArgb(30, 170, 200);
        public static readonly Color RoadBackColorDefault = Color.FromArgb(70, 70, 70);
        public static readonly Color TableBackColorDefault = Color.FromArgb(175, 70, 0);
        public static readonly Color FarmFieldBackColorDefault = Color.FromArgb(255, 213, 20);
        public static readonly Color HouseBackColorDefault = Color.FromArgb(175, 0, 0);
        public static readonly Color JobsBackColorDefault = Color.FromArgb(200, 200, 200);
        public static readonly Color HobbyBackColorDefault = Color.FromArgb(255, 150, 150);
        public static readonly Color SpecialsBackColorDefault = Color.FromArgb(140, 90, 30);

        // Colors used in rendering the control.
        public static Color ActiveSquareBackColor;
        #endregion

        // This represents the contents of the square, see the values defined in the Grid class
        public int Contents;
        public int PreviewContents;

        // These are used to set highlighting.
        public bool IsValid = false;
        public bool IsActive = false;
        public bool IsNew = false;

        // These reflect the public row and column properties.
        private int row;
        private int col;
        public int Row { get { return row; } }
        public int Col { get { return col; } }

        // Drawing tools.
        private static Pen pen = new Pen(Color.Black);
        private static SolidBrush solidBrush = new SolidBrush(Color.Black);
        private static GraphicsPath path = new GraphicsPath();

        public SquareControl(int squareRow, int squareCol)
        {
            InitializeComponent();

            this.Contents = Board.EmptyInt;
            row = squareRow;
            col = squareCol;

            // Prevent TAB control
            this.TabStop = false;

            // Color all the grid with "Empty" color
            this.BackColor = EmptyBackColorDefault;

            // If resized -> Redraw
            this.ResizeRedraw = true;

            // Square size
            this.Width = 20;
            this.Height = 20;

            // Set double-buffering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void Grid_paint(object sender, PaintEventArgs e)
        {
            // Clear the square, filling with the appropriate background color.
            Color backColor;
            switch (Contents)
            {
                #region LandScape Colors
                case 1:     // Forest
                    {
                        backColor = ForestBackColorDefault;
                        break;
                    }
                case 2:     // Water
                    {
                        backColor = WaterBackColorDefault;
                        break;
                    }
                case 3:     // Roads
                    {
                        backColor = RoadBackColorDefault;
                        break;
                    }
                case 4:     // FarmField
                    {
                        backColor = FarmFieldBackColorDefault;
                        break;
                    }
                #endregion
                #region Jobs Buildings Colors
                case 100:
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 101:   // ApothecaryOffice
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 102:   // Forge
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 103:   // UnionOfCrafter
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 104:   // Restaurant
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 105:   // Farm
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 106:   // MiliratyCamp
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 107:   // Mill
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                case 108:   // ClothesShop
                    {
                        backColor = JobsBackColorDefault;
                        break;
                    }
                #endregion
                #region Hobbies Buildings Colors
                case 200:
                    {
                        backColor = HobbyBackColorDefault;
                        break;
                    }
                case 201:   // Baths
                    {
                        backColor = HobbyBackColorDefault;
                        break;
                    }
                case 202:   // Brothel
                    {
                        backColor = HobbyBackColorDefault;
                        break;
                    }
                case 203:   // PartyRoom
                    {
                        backColor = HobbyBackColorDefault;
                        break;
                    }
                case 204:   // Tarvern
                    {
                        backColor = HobbyBackColorDefault;
                        break;
                    }
                case 205:   // Theater
                    {
                        backColor = HobbyBackColorDefault;
                        break;
                    }
                #endregion
                #region Specials Buildings Colors
                case 300:
                    {
                        backColor = SpecialsBackColorDefault;
                        break;
                    }
                case 301:   // Table
                    {
                        backColor = TableBackColorDefault;
                        break;
                    }
                case 302:   // House
                    {
                        backColor = HouseBackColorDefault;
                        break;
                    }
                case 303:   // Chapel
                    {
                        backColor = SpecialsBackColorDefault;
                        break;
                    }
                case 304:   // OfferingsWarehouse
                    {
                        backColor = SpecialsBackColorDefault;
                        break;
                    }
                #endregion
                default:
                    {
                        backColor = EmptyBackColorDefault;
                        break;
                    }
            }
            ActiveSquareBackColor = Color.FromArgb(128, backColor.R, backColor.G, backColor.B);
            if (IsValid)
                backColor = ValidPlaceBackColorDefault;
            if (IsActive)
                backColor = ActiveSquareBackColor;

            e.Graphics.Clear(backColor);

            // Set drawing options.
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the border.
            Point topLeft = new Point(0, 0);
            Point topRight = new Point(this.Width - 1, 0);
            Point bottomLeft = new Point(0, this.Height - 1);
            Point bottomRight = new Point(this.Width - 1, this.Height - 1);
            SquareControl.pen.Width = 1;
            e.Graphics.DrawLine(SquareControl.pen, bottomLeft, topLeft);
            e.Graphics.DrawLine(SquareControl.pen, topLeft, topRight);
            e.Graphics.DrawLine(SquareControl.pen, bottomLeft, bottomRight);
            e.Graphics.DrawLine(SquareControl.pen, bottomRight, topRight);
        }
    }
}