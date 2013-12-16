using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Chapel : BuildingsModel
    {
        public Chapel(Village v, BuildingsList List, string name)
            : base(v)
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
        override internal void AddToList()
        {
            Village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }
       
    }
}
