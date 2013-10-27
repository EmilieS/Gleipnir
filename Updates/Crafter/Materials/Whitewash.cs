using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    class Whitewash
    {
        MaterialsProperties _prop;

        internal Whitewash()
        {
            _prop = new MaterialsProperties();

        }
        public MaterialsProperties MaterialProperties
        {
            get { return _prop; }
        }
        public void SetPowerOfWhitewash()
        {
            if (_prop.IsBought == true)
            {
                _prop.Power = 300.0;
            }
        }

    }
}
