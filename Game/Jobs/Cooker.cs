using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Cooker : JobsModel
    {
        public Cooker(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.COOKER;
            _coefficient = 13;
            _happinessAddition = 1.3;
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
        internal override bool AddPersonPrerequisites()
        {
            return true;
        }
    }
}
