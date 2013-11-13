using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Believing
{
    public class Chapel
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get { return prop; }
        }
        public double SetFaith
        {
            get { return 4; }
        }
    }
}
