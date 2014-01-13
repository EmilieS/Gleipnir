using Game;
using Game.Buildings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Apothecary : JobsModel
    {
        public Apothecary(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.APOTHECARY;
            _coefficient = 15;
        }

        internal override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.Buildings.ApothecaryOfficeList.Count > 0)
                return true;
            else
                return false;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.Buildings.ApothecaryOfficeList.Count <= 0)
                return false;
            int i=0;
            do
            {
                if (Owner.Owner.Buildings.ApothecaryOfficeList[i].Hp > 0)
                    return true;
                i++;
            } while (i < Owner.Owner.Buildings.ApothecaryOfficeList.Count);
            return false;
        }
    }
}
