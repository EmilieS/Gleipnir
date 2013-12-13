using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Virus
    {
        Villager selectedVillager;
        int _timeBeforeDeath;

        internal int Timer
        {
            get { return _timeBeforeDeath; }
        }
        public Virus(Villager v)
        {
            selectedVillager = v;
            SetVirusEffects(selectedVillager);
        }

        public void SetVirusEffects(Villager selectedVillager)
        {
            selectedVillager.SetVirus();
            selectedVillager.ReduceLifeExpectancy(1);
        }


    }
}
