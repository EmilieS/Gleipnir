using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Hobbies
{
    public class Baths
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProp
        {
            get { return prop; }
        }
        public double SetHappiness
        {
            get { return 3; }
        }
        private int SetEnterPrice
        {
            get { return 200; }
        }
        public int SetNewGoldStash(int _goldStash = 0)
        {
            //TODO : Define the formule of limit for spending
            if (_goldStash >= SetEnterPrice) { _goldStash -= SetEnterPrice; }
            else { _goldStash = 0; }
            return _goldStash;
        }
    }
}
