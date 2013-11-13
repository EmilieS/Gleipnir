using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Hobbies
{
    public class Tavern
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get{return prop;}
        }

        public double SetFaith
        {
            get { return 4; }
        }

        public double SetHappiness
        {
            get { return 6; }
        }

        public void SetEnterPrice()
        {
            prop.EnterPrice = 2;
        }
    }
}
