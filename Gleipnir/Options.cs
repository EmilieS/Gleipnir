using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePages
{
    public class Options
    {
        // Define the game options.
        public bool ShowValidPlaces;
        public bool PreviewSquares;
        public Color BoardColor;
        public Color ValidPlaceColor;
        public Color ActiveSquareColor;

        public Options()
        {
            RestoreDefaults();
        }

        public Options(Options options)
        {
            ShowValidPlaces = options.ShowValidPlaces;
            PreviewSquares = options.PreviewSquares;
            BoardColor = options.BoardColor;
            ValidPlaceColor = options.ValidPlaceColor;
            ActiveSquareColor = options.ActiveSquareColor;
        }

        public void RestoreDefaults()
        {
            ShowValidPlaces = true;
            PreviewSquares = false;
            BoardColor = SquareControl.EmptyBackColorDefault;
            ValidPlaceColor = SquareControl.ValidPlaceBackColorDefault;
            ActiveSquareColor = SquareControl.ActiveSquareBackColorDefault;
        }
    }
}