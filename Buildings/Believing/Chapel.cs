﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Believing
{
    class Chapel
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get { return prop; }
        }
        public void SetFaith()
        {
            prop.AddFaith = 4;
        }
    }
}
