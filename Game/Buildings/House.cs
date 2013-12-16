using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class House: BuildingsModel
    {
        Family _family;
                public House(Village v, BuildingsList List, string name)
            : base(v)
        {
            Name = name;
        }
        override internal void AddToList()
        {
            Village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }


        internal override void JustDestroyed()
        {
            if (Hp == 0 && _family != null)
            {
                foreach (Villager v in _family.FamilyMembers)
                {
                    v.Kill();
                }
                _family = null;
            }
        }        
    }
    
}
