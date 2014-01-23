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
    public class Miller : JobsModel
    {
        public Miller(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.MILLER;
            _coefficient = 13;
            _happinessAddition = 1;
        }
        double _happinessAddition;
        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public override void AddHappiness(Villager villager)
        {
            if (_workers.Count == 0)
                return;
            if (villager.Job != null)
            {
                if (villager.Job == this)
                    return;
            }
            double happinessToAdd;
            happinessToAdd = _happinessAddition + _workers.Count * 0.5;
            villager.AddOrRemoveHappiness(happinessToAdd);
        }
        public override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.BuildingsList.MillList.Count > 0)
                return true;
            else
                return false;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.BuildingsList.MillList.Count <= 0)
                return false;
            int i = 0;
            do
            {
                if (Owner.Owner.BuildingsList.MillList[i].Hp > 0)
                {
                    return true;
                }
                i++;
            } while (i < Owner.Owner.BuildingsList.MillList.Count);
            return false;
        }
    }
}
