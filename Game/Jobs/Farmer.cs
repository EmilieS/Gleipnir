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
        public Farmer(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.FARMER;
            _coefficient = 10;
        }
        internal override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.BuildingsList.FarmList.Count > 0)
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
    }
}
