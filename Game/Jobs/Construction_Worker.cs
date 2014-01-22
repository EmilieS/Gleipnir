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
        public readonly List<Buildings.BuildingsModel> ToRepair;
        public Construction_Worker(Game game, JobList list, string name)
            : base(game,list, name)
        {
            ToRepair = new List<Buildings.BuildingsModel>();
            _job = Jobs.CONSTRUCTION_WORKER;
            _coefficient = 10;
        }
        public bool Repair(Buildings.BuildingsModel building)
        {
            if (Workers.Count == 0 || Owner.Owner.BuildingsList.UnionOfCrafterList.Count==0)
                return false;
            ToRepair.Add(building);
            return true;
        }
        internal override void Evolution()
        {
            if (ToRepair.Count != 0 && Workers.Count !=0)
            {
                int toRepairNb = ToRepair.Count;
                int nbWorkers = Workers.Count;
                int j = 0;
                for (int i = 0; i < nbWorkers; i++)
                {
                    if (i >= toRepairNb)
                    {
                        j = 0;                        
                    }
                    if (ToRepair[j].Repair2(1))
                    {
                        ToRepair.RemoveAt(j);
                        toRepairNb--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
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
