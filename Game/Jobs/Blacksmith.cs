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
    public class Blacksmith : JobsModel
    {
        public Blacksmith(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.BLACKSMITH;
            _coefficient = 10;
        }

        internal override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.Buildings.ForgeList.Count > 0)
                return true;
            else
                return false;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.Buildings.ForgeList.Count <= 0)
                return false;
            int i = 0;
            do
            {
                if (Owner.Owner.Buildings.ForgeList[i].Hp > 0)
                {
                    return true;
                }
                i++;
            } while (i < Owner.Owner.Buildings.ForgeList.Count);
            return false;
        }
    }
}
