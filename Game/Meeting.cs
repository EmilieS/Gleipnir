using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Meeting
    {
        public static void ChangeVillagersStatus(Family family)
        {
            foreach (Villager villager in family.FamilyMembers)
            {
                villager.ActivityStatus = ActivityStatus.CONVOCATED;
            }
        }
    }
}
