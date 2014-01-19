using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Virus
    {
        Villager selectedVillager;
        internal GodSpell.Epidemic Epidemic { get; set; }
        int _maxTimeBeforeDeath;
        int _lifeExpectencyReduced;
        /// <summary>
        /// life expectency reduced no matter if he gets healed.
        /// </summary>
        internal int LifeExpectencyReduced { get { return _lifeExpectencyReduced; } }
        /// <summary>
        /// Time before death if not healed.
        /// </summary>
        internal int MaxTimer{get { return _maxTimeBeforeDeath; }}
        public Virus( int maxTimeBeforeDeath=10, int lifeExpectencyReduced=1)
        {
            _maxTimeBeforeDeath = maxTimeBeforeDeath;
            _lifeExpectencyReduced = lifeExpectencyReduced;
            
            //SetVirusEffects(selectedVillager);
        }
        /*
        public void SetVirusEffects(Villager selectedVillager)
        {
            //selectedVillager.SetVirus();
            selectedVillager.ReduceLifeExpectancy(1);
        }
        */

    }
}
