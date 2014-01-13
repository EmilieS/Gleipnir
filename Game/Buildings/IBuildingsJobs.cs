using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public interface IBuildingsJobs
    {
        void SetCoordinates(int x, int y);

        string BuildingName();
    }
}
