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

        public Meeting(Family f)
        {
            actualConvocated = f;
        }

        public Family ActualConvocated
        {
            get { return actualConvocated; }
            set { actualConvocated = value; }

        }

        public void Convocate()
        {
            if (actualConvocated != null)
            {
                foreach (Family f in actualConvocated.OwnerVillage.FamiliesList)
                {
                    foreach (Villager villager in f.FamilyMembers)
                    {
                        villager.MeetingEnded();
                    }
                }
            }
            foreach (Villager villager in actualConvocated.FamilyMembers)
            {
                villager.MeetingStarted();

            }
        }

        public void ReleaseConvocated(Family family)
        {
            foreach (Villager villager in family.FamilyMembers)
            {
                villager.MeetingEnded();
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
