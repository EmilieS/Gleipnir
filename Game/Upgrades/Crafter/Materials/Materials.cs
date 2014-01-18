using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    // Materials get the power added to origin buildings
    public class Materials
    {
        public Whitewash w = new Whitewash();
        public Cement c = new Cement();
        public Reinforced r = new Reinforced();

        double _totalPower;

        public Materials()
        {
            _totalPower = 0;
        }

        // Inspect if the material has been bought 
        // Add his power
        public double SetTotalPower()
        {
            _totalPower = 0;
            if (w.IsBought == true)
            {
                _totalPower += w.PowerOfWhitewash;
            }
            if (w.IsBought == true && c.IsBought == true)
            {
                _totalPower += c.PowerOfCement;
            }
            if (w.IsBought == true && c.IsBought == true && r.IsBought == true)
            {
                _totalPower += r.PowerOfReinforced;
            }
            return _totalPower;
        }

    }
}
