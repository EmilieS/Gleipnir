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
    public class Militia : JobsModel
    {
        public Militia(Game game, JobList list, string name)
            : base(game,list, name)
        {
            _job = Jobs.MILITIA;
            _coefficient = 8;
        }
        internal override bool AddPersonPrerequisites()
        {
            return true;
        }
    }
}