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
        public void SetEnterPrice()
        {
            prop.EnterPrice = 200;
        }
    }
}
