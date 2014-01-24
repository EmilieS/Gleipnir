using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Meeting : GameItem
    {
        Family _family;
        public Family Family { get { return _family; } }
        Village _village;
        bool _endMeeting;
        bool _justStarted;

        public Meeting(Family f)
            : base(f.Game)
        {
            _family = f;
            _village = f.OwnerVillage;
            _justStarted = true;
            Convocate();
        }

        public Family ActualConvocated { get { return _family; } }
        public bool IsEnded { get { return _endMeeting; } }

        public void Convocate()
        {
            foreach (Villager villager in _family.FamilyMembers)
                villager.MeetingStarted();
        }
        internal void EndMeeting()
        {
            _endMeeting = true;
            //_family = null;
        }

        //public void AffectMissionToVillager(Villager villager, Missions expectedMission)
        //{
        //    if (expectedMission != villager.Mission)
        //    {
        //        villager.Mission = expectedMission;
        //    }
        //}
        internal override void OnDestroy()
        {
            _village.MeetingEnded();
            _village = null;
            _family = null;
        }
        internal override void DieOrIsAlive(List<IEvent> eventList)
        {
            if (_endMeeting == true)
            {
                eventList.Add(new MeetingDestroyedEvent(this, _family.Name));
                foreach (Villager villager in _family.FamilyMembers)
                {
                    villager.MeetingEnded();
                }
                Destroy();
            }
        }
        internal override void CloseStep(List<IEvent> eventList)
        {
            if (_justStarted == true)
            {
                eventList.Add(new MeetingCreatedEvent(this));
                _justStarted = false;
            }
        }
    }
}
