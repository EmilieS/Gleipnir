using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game.Buildings
{
    public class ApothecaryOffice : BuildingsModel
    {
        internal string _name;

        public ApothecaryOffice(Village v)
            : base(v)
        {
            Name = "Clinique";
            _name = Name;
            Hp = MaxHp = 50;
        }
        public void SetGoodHealth(Villager sickVillager)
        {
            sickVillager.Heal();
        }

        override internal void AddToList()
        {
            Village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }
        override internal void OnDamage()
        {
            foreach (Villager v in Village.Jobs.Apothecary.Workers)
            {
                if (Game.Rand.Next(100) == 1)
                {
                    v.EarthquakeInjure();
                }
            }
        }

        public void SetCoordinates(int x, int y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("X or Y doesn't exist");
            if ((x < 0 || x > 20) || (y < 0 || y > 32))
                throw new IndexOutOfRangeException("Must be in tab");
            this.HorizontalPos = x;
            this.VerticalPos = y;
        }

        public string BuildingName { get { return _name; } }
    }
}
