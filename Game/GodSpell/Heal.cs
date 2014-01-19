using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GodSpell
{
    [Serializable]
    public class Heal : GameItem
    {
        public Heal(Game g)
            : base(g)
        {   
        
        }

        internal override void ImpactHappiness()
        {
            List<Epidemic> tmpEList = new List<Epidemic>();
            List<Villager> tmpVLIst = new List<Villager>();
            tmpEList.AddRange(Game._currentEpidemicList);
            foreach (Epidemic e in tmpEList)
            {
                tmpVLIst.Clear();
                tmpVLIst.AddRange(e.SickVillagerList);
                foreach (Villager v in tmpVLIst)
                {      
                    v.SetHealed(10);
                }
            }
        }
        internal override void OnDestroy()
        {        }
        internal override void CloseStep(List<IEvent> eventList) { }

    }
}
