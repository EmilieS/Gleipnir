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
    public class Cooker : JobsModel
    {
        public Cooker(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.COOKER;
            _coefficient = 13;
            HappinessToAdd = 1.3;
        }
        //public double HappinessToAdd
        //{
        //    get { return _happinessAddition; }
        //    set { _happinessAddition = value; }
        //}
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
            happinessToAdd = HappinessToAdd + _workers.Count * 0.5;
            villager.AddOrRemoveHappiness(happinessToAdd);
        }
        internal override bool AddPersonPrerequisites()
        {
            if (Owner.Owner.Buildings.RestaurantList.Count > 0)
                return true;
            else
                return false;
        }
        internal override bool GenerateGoldPrerequisites()
        {
            if (Owner.Owner.Buildings.RestaurantList.Count <= 0)
                return false;
            int i = 0;
            do
            {
                if (Owner.Owner.Buildings.RestaurantList[i].Hp > 0)
                {
                    return true;
                }
                i++;
            } while (i < Owner.Owner.Buildings.RestaurantList.Count);
            return false;
        }
    }
}
