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

        public Family ActualConvocated
        {
            get { return actualConvocated; }
            set { actualConvocated = value; }

        }

        public void Convocate(Family family)
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

        public void ReleaseConvocated(Family family)
        {
            foreach (Villager villager in family.FamilyMembers)
            {
                villager.ActivityStatus = ActivityStatus.WORKING;
            }
        }

        public void AffectMissionToVillager(Villager villager, Missions expectedMission)
        {
            if (expectedMission != villager.Mission)
            {
                villager.Mission = expectedMission;

            }
        }
    }
}
