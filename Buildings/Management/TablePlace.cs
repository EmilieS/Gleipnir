using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings.Management
{
    class TablePlace
    {
        BuildingsProperties prop = new BuildingsProperties();

        public BuildingsProperties BuildingsProperties
        {
            get { return prop; }
        }
        public void SetTablePosition()
        {
            //TODO : Define the Table position 
            prop.HorizontalPos = 3;
            prop.VerticalPos = 4;
        }
        public void SetFaith()
        {
            prop.AddFaith = 1;
        }
    }
}
