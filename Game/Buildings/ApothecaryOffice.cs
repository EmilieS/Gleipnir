using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game.Buildings
{
    public class ApothecaryOffice : BuildingsModel, IBuildingsJobs
    {
        readonly string _name;

        public ApothecaryOffice(Village v, BuildingsList List, string name)
            : base(v)
        {
            _name = name;
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
