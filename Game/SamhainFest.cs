using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class SamhainFest
    {
        double _duration;
        
        // TODO : define the duration of  the villageFest, implement duration
        SamhainFest()
        {
            _duration = 15;
        }

        public double Duration
        {
            get
            {
                return _duration;
            }
        }
        public void ActOnvillagers(Village village)
        {
            foreach (Family family in village.FamiliesList)
            {
                foreach (Villager villager in family.FamilyMembers)
                {
                    if (!villager.IsHeretic())
                    {
                        villager.ActivityStatus = ActivityStatus.PUSHINGOUT;
                    }
                    villager.AddOrRemoveHappiness(15);
                    villager.AddOrRemoveFaith(15);
                }
            }
        }
       
    }
}
