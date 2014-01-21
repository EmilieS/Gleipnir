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
    [Serializable]
    public class Apothecary : JobsModel
    {
        public Apothecary(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.APOTHECARY;
            _coefficient = 15;
        }

        public override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.BuildingsList.ApothecaryOfficeList.Count > 0)
                return true;
            else
                return false;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.BuildingsList.ApothecaryOfficeList.Count <= 0)
                return false;
            int i=0;
            do
            {
                if (Owner.Owner.BuildingsList.ApothecaryOfficeList[i].Hp > 0)
                    return true;
                i++;
            } while (i < Owner.Owner.BuildingsList.ApothecaryOfficeList.Count);
            return false;
        }
    }
}
