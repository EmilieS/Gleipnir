using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs
{
    class Crafter
    {
        int _creationLifeLevel;

        public Crafter()
        {
            materials = new Crafter.Materials.CrafterMaterials();
        }
        
        public int CreationLifeLevel
        {
            get{return _creationLifeLevel;}
        }
        public double Effectiveness
        {
            
        }
    }
}
