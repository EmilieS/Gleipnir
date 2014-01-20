using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class SamhainFest : GameItem
    {
        int _duration;
        int _timer;
        Village _village;

        // TODO : define the duration of  the villageFest, implement duration
        internal SamhainFest(Village v)
            : base(v.Game)
        {
            _duration = 15;
            _timer = _duration;
            _village = v;
            ActOnvillagers(v);
        }

        public int Duration
        {
            get
            {
                return _duration;
            }
        }
        public void ActOnvillagers(Village village)
        {
            foreach (Family family in village.FamiliesList)
                foreach (Villager villager in family.FamilyMembers)
                {
                    if (!villager.IsHeretic())
                        villager.ActivityStatus = ActivityStatus.PARTYING;
                    villager.AddOrRemoveHappiness(3);
                    villager.AddOrRemoveFaith(2);
                }
        }
        internal override void ImpactHappiness()
        {
            _timer--;
        }
        internal override void Creation(List<IEvent> eventList)
        {
            foreach (Family family in _village.FamiliesList)
            {
                if (family.Mother != null && family.Father != null)
                {
                    if (!family.Mother.IsDead() && !family.Father.IsDead() && family.Mother.Age < 420)
                    {
                        if (Game.Rand.Next(3) == 2)
                        {
                            eventList.Add(new VillagerBirthEvent(family.NewFamilyMember()));
                        }
                    }

                }
            }

        }
        internal override void OnDestroy()
        {
            _village.FestEnded();
        }
        internal override void DieOrIsAlive(List<IEvent> eventList)
        {
            //TODO : create event : samham fest is over.
            if (_timer <= 0)
            {
                foreach (Family family in _village.FamiliesList)
                {
                    foreach (Villager villager in family.FamilyMembers)
                    {
                        if (!villager.IsHeretic())
                        {
                            villager.ActivityStatus = ActivityStatus.NONE;
                        }
                    }
                }
                Destroy();
            }
        }
        internal override void CloseStep(List<IEvent> eventList)
        {
            //TODO : create event : samham fest has started.
        }
    }
}
