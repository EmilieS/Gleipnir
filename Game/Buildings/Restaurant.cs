using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
     public class Restaurant : BuildingsModel
    {
        public Restaurant(Village v, BuildingsList List, string name)
            : base (v)
        {
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
