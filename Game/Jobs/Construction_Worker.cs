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
    public class Construction_Worker : JobsModel
    {
        public Construction_Worker(Game game, JobList list, string name)
            : base(game,list, name)
        {
            _job = Jobs.CONSTRUCTION_WORKER;
            _coefficient = 10;
        }
        internal override bool AddPersonPrerequisites()
        {
            return true;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.BuildingsList.UnionOfCrafterList.Count <= 0)
                return false;
            int i = 0;
            do
            {
                if (Owner.Owner.BuildingsList.UnionOfCrafterList[i].Hp > 0)
                {
                    return true;
                }
                i++;
            } while (i < Owner.Owner.BuildingsList.UnionOfCrafterList.Count);
            return false;
        }
    }
}
