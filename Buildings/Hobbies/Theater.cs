using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Hobbies
{
    class Theater
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get { return prop; }
        }
        public void SetHappiness()
        {
            prop.AddHapiness = 5;
        }
        public void SetEnterPrice()
        {
            prop.EnterPrice = 50;
        }
    }
}
