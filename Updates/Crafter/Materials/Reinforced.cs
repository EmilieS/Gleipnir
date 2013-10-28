using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    class Reinforced
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
        }
        public double PowerOfWhitewash
        {
            get { return _power; }
        }
    }
}
