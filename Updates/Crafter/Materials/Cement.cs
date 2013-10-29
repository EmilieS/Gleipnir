using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    public class Cement
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
            set { _isBought = value; }
        }
        public double PowerOfCement
        {
            get { return _power; }
        }
    }
}
