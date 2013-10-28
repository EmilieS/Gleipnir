using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    class Cement
    {
        bool _isBought;
        double _power;

        public Cement()
        {
            _isBought = false;
            _power = 1000;
        }
        public bool IsBought
        {
            get { return _isBought; }
            set { value = _isBought; }
        }
        public double PowerOfCement
        {
            get { return _power; }
        }
    }
}
