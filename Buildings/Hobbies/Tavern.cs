using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Hobbies
{
    class Tavern
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get{return prop;}
        }

        public void SetFaith()
        {
            prop.AddFaith = 4;
        }

        public void SetHappiness()
        {
            prop.AddHapiness = 6;
        }

        public void SetEnterPrice()
        {
            prop.EnterPrice = 2;
        }
    }
}
