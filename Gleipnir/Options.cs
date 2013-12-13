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
        public bool showValidPlaces;
        public bool previewSquares;
        public Color boardColor;
        public Color validPlaceColor;
        public Color activeSquareColor;

        public Options()
        {
            RestoreDefaults();
        }

        public Options(Options options)
        {
            showValidPlaces = options.showValidPlaces;
            previewSquares = options.previewSquares;
            boardColor = options.boardColor;
            validPlaceColor = options.validPlaceColor;
            activeSquareColor = options.activeSquareColor;
        }

        public void RestoreDefaults()
        {
            showValidPlaces = true;
            previewSquares = false;
            boardColor = SquareControl.EmptyBackColorDefault;
            validPlaceColor = SquareControl.ValidPlaceBackColorDefault;
            activeSquareColor = SquareControl.ActiveSquareBackColorDefault;
        }
    }
}