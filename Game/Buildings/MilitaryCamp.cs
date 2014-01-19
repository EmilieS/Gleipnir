using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class MilitaryCamp : BuildingsModel
    {
        internal string _name;
        internal JobsModel _job;

        public MilitaryCamp(Village v, JobsModel job)
            : base(v)
        {
            Name = "QG";
            _name = Name;
            Hp = MaxHp = 50;
            _job = job;
            this.CostPrice = 800;
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
            foreach (Villager v in Village.Jobs.Militia.Workers)
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
