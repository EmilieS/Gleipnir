using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    class MaterialsProperties
    {
        bool _isBought;
        double _power;

        internal MaterialsProperties()
        {
            _isBought = false;
            _power = 1;
        }

        public bool IsBought
        {
            get { return _isBought; }
        }

        public double Power
        {
            get { return _power; }
        }
    }
}
