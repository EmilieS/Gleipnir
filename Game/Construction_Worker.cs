using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Construction_Worker : JobsModel
    {
        public Construction_Worker(Game game, string name)
            : base(game, name)
        {
            _job = Jobs.CONSTRUCTION_WORKER;
            _coefficient = 10;
        }
    }
}
