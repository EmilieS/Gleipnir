using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Militia : JobsModel
    {
        public Militia(Game game, string name)
            : base(game, name)
        {
            _job = Jobs.MILITIA;
            _coefficient = 8;
        }
    }
}