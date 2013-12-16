using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
     public class UnionOfCrafter : BuildingsModel
    {
        public UnionOfCrafter(Village v, BuildingsList List, string name)
            : base(v)
        {

        }
        // Syndicat des ouvriers 
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
