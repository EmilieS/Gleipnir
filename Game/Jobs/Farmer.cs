using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Farmer : JobsModel
    {
        bool EnoughFarms; // Just for the event

        public Farmer(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.FARMER;
            _coefficient = 10;
        }

        public override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.BuildingsList.FarmList.Count * 10 > Workers.Count)
                return true;
            else
                return false;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.BuildingsList.FarmList.Count <= 0)
                return false;
            int i = 0;
            do
            {
                if (Owner.Owner.BuildingsList.FarmList[i].Hp > 0)
                {
                    return true;
                }
                i++;
            } while (i < Owner.Owner.BuildingsList.FarmList.Count);
            return false;
        }
        internal override void CloseStep(List<IEvent> eventList)
        {
            base.CloseStep(eventList);//do not remove.
            if (Owner.Owner.BuildingsList.FarmList.Count * 10 <= _workers.Count && EnoughFarms)
            {
                EnoughFarms = false;
                eventList.Add(new NotEnoughFarmsEvent(this));
            }
            else if (Owner.Owner.BuildingsList.FarmList.Count * 10 > _workers.Count)
            {
                EnoughFarms = true;
            }
        }
    }
}
