using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Farmer : JobsModel
    {
        public Farmer(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.FARMER;
            _coefficient = 10;
        }
        internal override bool AddPersonPrerequisites()
        {
            return true;
        }
    }
}
