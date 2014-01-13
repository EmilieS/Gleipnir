using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class TablePlace : BuildingsModel
    {
        public TablePlace(Village v)
            : base(v)
        {
            Name = "Autel sacré";
            Hp = MaxHp = 100000;
            this.CostPrice = 0;
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
