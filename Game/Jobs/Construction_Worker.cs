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

        public string Repair(Buildings.BuildingsModel building)
        {
            if (Workers.Count == 0)
                return "Il n'y a pas d'ouvriers.";
            if (Owner.Owner.BuildingsList.UnionOfCrafterList.Count == 0)
                return "Sans syndicat, les ouvriers refusent de réparer.";
            if (building == null)
                return "Veillez choisir un bâtiment";
            if (building.Hp > 1)
                return "Un bâtiment détruit ne peut être réparé.";
            ToRepair.Add(building);
            return "Le bâtiment a bien été ajouté à la liste des bâtiments à réparer";
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
                    if (ToRepair[j].Repair2(1)|| ToRepair[j].Hp<1)
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
        public override bool AddPersonPrerequisites()
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
