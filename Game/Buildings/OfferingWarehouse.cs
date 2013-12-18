using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
     public class OfferingWarehouse : BuildingsModel
    {
        public OfferingWarehouse(Village v)
            : base(v)
        {
            Name = "Sanctuaire";
            Hp = MaxHp = 50;
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
