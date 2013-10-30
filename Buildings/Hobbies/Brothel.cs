using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Hobbies
{
    public class Brothel
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get { return prop; }
        }

        public double SetHappiness
        {
            get { return 8; }
        }

        public void SetEnterPrice()
        {
            prop.EnterPrice = 20;
        }
    }
}
