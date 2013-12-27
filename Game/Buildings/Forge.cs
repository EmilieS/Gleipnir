using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Forge : BuildingsModel
    {
        internal string _name;

        public Forge(Village v)
            : base(v)
        {
            Name = "Forge";
            _name = Name;
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
        override internal void OnDamage()
        {

            foreach (Villager v in Village.Jobs.Blacksmith.Workers)
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
