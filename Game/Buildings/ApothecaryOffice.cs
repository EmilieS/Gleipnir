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
        internal JobsModel _job;

        public ApothecaryOffice(Village v, JobsModel job)
            : base(v)
        {
            Name = "Pharmacie";
            _name = Name;
            Hp = MaxHp = 50;
            _job = job;
            this.CostPrice = 200;
        }

        public void SetGoodHealth(Villager sickVillager)
        {
            sickVillager.SetHealed();
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

        public string BuildingName { get { return _name; } }
        public JobsModel Job { get { return _job; } }
    }
}
