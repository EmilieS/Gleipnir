using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Chapel : BuildingsModel
    {
        public Chapel(Village v)
            : base(v)
        {
            AddFaith = 5;
            AddHapiness = 0;
            EnterPrice = 0;
            Name = "Chapelle";
            Hp = MaxHp = 50;
            this.CostPrice = 450;
        }

        override internal void AddToList()
        {
            Village.BuildingsList.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.BuildingsList.Remove(this);
        }
    }
}
