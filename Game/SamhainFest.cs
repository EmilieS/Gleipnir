using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SamhainFest 
    {
        double _duration;

        // TODO : define the duration of  the villageFest, implement duration
        public SamhainFest()
            
        {
            _duration = 15;
        }
        /// <summary>
        /// This is the duration of Samhain
        /// For the moment at 24/11/13 I don't know how to implement this.
        /// </summary>
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
                        villager.AddOrRemoveHappiness(15.0);
                        villager.AddOrRemoveFaith(15.0);
                    }
                }
            }
        }

    }
}
