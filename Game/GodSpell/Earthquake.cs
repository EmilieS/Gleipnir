using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GodSpell
{
    [Serializable]
    public class Earthquake : GameItem
    {
        Village _village;
        int _force;

        public Earthquake(Game g, Village v)
            : base (g)
        {
            _village = v;
            _force = 20;
        }

        internal override void OnDestroy(){}
        internal override void Evolution()
        {
            foreach (Buildings.BuildingsModel b in  _village.BuildingsList)
            {
                b.Damage(_force);
            }
            //TODO in buildings : check how long since last repairs and impact faith of family members or workers.
        }

        override internal void DieOrIsAlive(List<IEvent> eventlist)
        {
            Destroy();
        }
        internal override void CloseStep(List<IEvent> eventList){ }              
   }


}
