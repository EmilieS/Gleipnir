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
            int index = 0;


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
                    index++;
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
                List<Villager> FamilySelected  = new List<Villager>(); // How to access to one family specially ??????? 
                foreach(Villager villager in FamilySelected)
                {
                    villager.ActivityStatus = ActivityStatus.WORKING;
                }
            }
        }
    }
}
