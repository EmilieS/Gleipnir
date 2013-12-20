using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GodSpell
{
    public class Epidemic : GameItem
    {
        Game game = new Game();
        //Villager affectedVillager;
        //Family ParentFamily;
        Virus _virus;
        int _timeSinceCreation;
        public int TimeSinceCreation { get { return _timeSinceCreation; } }
        int _timeBeforeThePlayerIsWarned;//=1 => Event; =0 =>Already warned
        public readonly List<Villager> SickVillagerList;

        public Epidemic(Game g, Villager v)
            : base (g)
        {
            SickVillagerList = new List<Villager>();
            //affectedVillager = v;
            //game = g;
            //LaunchEpidemic();
            g.EpidemicCreated(this);
            _virus = new Virus();
            _virus.Epidemic = this;
            v.SetVirus(_virus);
            _timeBeforeThePlayerIsWarned = 5;
        }
        public void LaunchEpidemic()
        {
            //affectedVillager.SetVirus();
        }
        public void InfectWork()
        {
            /*foreach (Villager v in affectedVillager.Job.Workers)
            {
                if ((v.Health &  Healths.SICK)==0)
                {
                    v.SetVirus();
                }
            }*/

            int initialTotal = SickVillagerList.Count;
            for (int i = 0; i < initialTotal; i++)
            {
                if (SickVillagerList[i].Job != null)
                {
                    foreach (Villager v in SickVillagerList[i].Job.Workers)
                    {
                        if ((v.Health & Healths.SICK) == 0)
                        {
                            if(Game.Rand.Next(15)==1)
                                v.SetVirus(_virus);
                        }
                    }
                }
            }
        }
        public void InfectFamily()
        {
            int initialTotal = SickVillagerList.Count;
            for ( int i=0; i < initialTotal; i++)
            {
                foreach (Villager v in SickVillagerList[i].ParentFamily.FamilyMembers)
                {
                    if ((v.Health & Healths.SICK) == 0)
                    {
                        if (Game.Rand.Next(7) == 1)
                        v.SetVirus(_virus);
                    }
                }
            }
        }
        override internal void ImpactHappiness()
        {
            _timeSinceCreation++;
            InfectFamily();
            InfectWork();
        }
        internal override void Evolution()
        {

        }
        internal override void OnDestroy()
        {
            Game.EpidemicDestroyed(this);
        }
        internal override void DieOrIsAlive(List<IEvent> eventList)
        {
            if (SickVillagerList.Count == 0)
            {
                Destroy();
            }
        }
        override internal void CloseStep(List<IEvent> eventlist)
        {
            if(_timeBeforeThePlayerIsWarned> 1)
            {
                _timeBeforeThePlayerIsWarned--; 
            }
            else if (_timeBeforeThePlayerIsWarned == 1)
            {
                eventlist.Add(new EpidemicDeclaredEvent(this));
                _timeBeforeThePlayerIsWarned--; 
            }
        }
    }
}
