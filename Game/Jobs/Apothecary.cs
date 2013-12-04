using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Apothecary : JobsModel
    {
        public Apothecary(Game game, JobList list, string name)
            : base(game, list, name)
        {
            _job = Jobs.APOTHECARY;
            _coefficient = 15;
        }
        internal override bool AddPersonPrerequisites()
        {
            return true;
        }
    }
}
