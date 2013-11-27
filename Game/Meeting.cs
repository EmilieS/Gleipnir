using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Meeting
    {

        Family actualConvocated;

        public Meeting()
        {

        }

        public void ChangeVillagersStatus(Family family)
        {
            if (actualConvocated != null)
            {
                foreach (Villager villager in actualConvocated.FamilyMembers)
                {
                    villager.ActivityStatus = ActivityStatus.WORKING;
                }
            }
            foreach (Villager villager in family.FamilyMembers)
            {
                villager.ActivityStatus = ActivityStatus.CONVOCATED;

            }
            actualConvocated = family;
        }


    }
}
