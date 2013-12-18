﻿using System;
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
        // Background when cursor is on a right place
        public static readonly Color ActiveSquareBackColorDefault = Color.FromArgb(65, 175, 25);

        // Background for right zone to place a building
        public static readonly Color ValidPlaceBackColorDefault = Color.FromArgb(75, 200, 30);

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
        public static Color ActiveSquareBackColor = ActiveSquareBackColorDefault;
        public static Color ValidMoveBackColor = ValidPlaceBackColorDefault;
        public static Color NormalBackColor = EmptyBackColorDefault;
        #endregion

        // This represents the contents of the square, see the values defined in the Grid class
        public int Contents;
        public int PreviewContents;

        // These are used to set the right color
        internal readonly int IsForest = 1;
        internal readonly int IsWater = 2;
        internal readonly int IsRoad = 3;
        internal readonly int IsTable = 4;
        internal readonly int IsFarmField = 10;
        internal readonly int IsFamilyHouse = 20;
        internal readonly int IsJobBuilding = 30;
        internal readonly int IsHobbyPlace = 40;
        internal readonly int IsSpecialBuiding = 50;

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

        public SquareControl(int row, int col)
        {
            InitializeComponent();

            this.Contents = Board.Empty;
            this.row = row;
            this.col = col;

            // Prevent TAB control
            this.TabStop = false;

            // Color all the grid with "Empty" color
            this.BackColor = NormalBackColor;

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
            Color backColor = NormalBackColor;
            if (Contents == IsForest)
                backColor = ForestBackColorDefault;
            if (Contents == IsWater)
                backColor = WaterBackColorDefault;
            if (Contents == IsRoad)
                backColor = RoadBackColorDefault;
            if (Contents == IsTable)
                backColor = TableBackColorDefault;
            if (Contents == IsFarmField)
                backColor = FarmFieldBackColorDefault;
            if (Contents == IsFamilyHouse)
                backColor = HouseBackColorDefault;
            if (Contents == IsJobBuilding)
                backColor = JobsBackColorDefault;
            if (Contents == IsHobbyPlace)
                backColor = HobbyBackColorDefault;
            if (Contents == IsSpecialBuiding)
                backColor = SpecialsBackColorDefault;
            if (IsValid)
                backColor = ValidMoveBackColor;
            if (IsActive)
                backColor = ActiveSquareBackColor;

            ActiveSquareBackColor = Color.FromArgb(128, backColor.R, backColor.G, backColor.B);

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