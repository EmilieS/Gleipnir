using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Miller : JobsModel
    {
        public Miller(Game game, JobList list, string name)
            : base(game, list,name)
        {
            _job = Jobs.MILLER;
            _coefficient = 13;
        }
        
        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public override void AddHappiness()
        {
            //TODO: Add happiness to all villager not in workers
        }
    }
}
