using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Baths : BuildingsModel
    {
        public Baths(Village v)
            : base(v)
        {
            Name = "Thermes";
            Hp = MaxHp = 50;
        }
        public double SetHappiness
        {
            get { return 3; }
        }
        private int SetEnterPrice
        {
            get { return 200; }
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
