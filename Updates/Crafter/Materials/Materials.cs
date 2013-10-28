using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Updates.Crafter.Materials
{
    // Materials get the power added to origin buildings
    public class Materials
    {
        Whitewash w = new Whitewash();
        Cement c = new Cement();
        Reinforced r = new Reinforced();

        double _totalPower;

        internal Materials()
        {
            _totalPower = 0;
        }

        // Inspect if the material has been bought 
        // Add his power
        public double SetTotalPower()
        {
            if (w.IsBought == true)
            {
                _totalPower += w.PowerOfWhitewash;
            }
            if (c.IsBought == true)
            {
                _totalPower += c.PowerOfCement;
            }
            if (r.IsBought == true)
            {
                _totalPower += r.PowerOfReinforced;
            }
            return _totalPower;
        }

        public double TotalPower
        {
            get { return _totalPower; }
        }

    }
}
