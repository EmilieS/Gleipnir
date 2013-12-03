using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Chapel : BuildingsModel
    {
        public Chapel(Game g, BuildingsList List, string name)
            : base(g)
        {
            AddFaith = 5;
            AddHapiness = 0;
            EnterPrice = 0;
        }
        public void SetLocation(int HPosition, int VPosition)
        {
            HorizontalPos = HPosition;
            VerticalPos = VPosition;
        }
       
    }
}
