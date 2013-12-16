using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Blacksmith : JobsModel
    {
        public Blacksmith(Game game, JobList list, string name)
            : base(game,list, name)
        {
            _job = Jobs.CONSTRUCTION_WORKER;
            _coefficient = 10;
        }
        internal override bool AddPersonPrerequisites()
        {
            return true;
        }
    }
}
