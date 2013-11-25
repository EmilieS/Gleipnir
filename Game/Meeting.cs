using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Meeting
    {

        public void ChangeVillagersStatus(Family family, Village village)
        {
            bool _convocatedYet = false;
            int i = 0;

            foreach (Family f in village.FamiliesList)
            {
                if (!_convocatedYet)
                {
                    foreach (Villager villager in f.FamilyMembers)
                    {
                        if (villager.ActivityStatus == ActivityStatus.CONVOCATED)
                        {
                            _convocatedYet = true;
                        }
                    }
                    i++;
                }
            }

            if (!_convocatedYet)
            {
                foreach (Villager villager in family.FamilyMembers)
                {
                    villager.ActivityStatus = ActivityStatus.CONVOCATED;
                }
            }
            else
            {
                foreach (Villager villager in village.FamiliesList[i].FamilyMembers)
                {
                    villager.ActivityStatus = ActivityStatus.WORKING;
                }
                foreach (Villager villager in family.FamilyMembers)
                {
                    villager.ActivityStatus = ActivityStatus.CONVOCATED;
                }
            }
        }


    }
}
