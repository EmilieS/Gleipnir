using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    class Whitewash
    {
        public double _power;
        public bool _isBought;

        internal Whitewash()
        {

            _power = 300;
            _isBought = false;
        }

        public bool IsBought
        {
            get { return _isBought; }
            set { value = _isBought; }
        }
        public double PowerOfWhitewash
        {
            get { return _power; }
        }

    }
}
