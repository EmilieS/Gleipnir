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
        public Farmer(Game game, string name)
            : base(game, name)
        {
            _job = Jobs.FARMER;
            _coefficient = 10;
        }
    }
}
