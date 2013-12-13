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
        Villager affectedVillager;
        Family ParentFamily;

        public Epidemic(Game g, Villager v)
            : base (g)
        {
            affectedVillager = v;
            game = g;
            LaunchEpidemic();
        }
        public void LaunchEpidemic()
        {
            affectedVillager.SetVirus();
        }
        public void AffectInWork()
        {
            foreach (Villager v in affectedVillager.Job.Workers)
            {
                if ((v.Health &  Healths.SICK)==0)
                {
                    v.SetVirus();
                }
            }
        }
        public void AffectInFamily()
        {
            foreach (Villager v in ParentFamily.FamilyMembers)
            {
                if ((v.Health & Healths.SICK) == 0)
                {
                    v.SetVirus();
                }
            }
        }
        internal override void Evolution()
        {
            AffectInWork();
            AffectInFamily();
        }
        internal override void OnDestroy()
        {
            
        }
        override internal void CloseStep(List<IEvent> eventlist)
        {

        }
    }
}
