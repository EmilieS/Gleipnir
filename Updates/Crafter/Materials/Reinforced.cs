using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    public class Reinforced
    {
        bool _isBought;
        double _power;

        public Reinforced()
        {
            _isBought = false;
            _power = 10000;
        }
        public bool IsBought
        {
            get { return _isBought; }
            set { _isBought = value; }
        }
        public double PowerOfReinforced
        {
            get { return _power; }
        }
    }
}
