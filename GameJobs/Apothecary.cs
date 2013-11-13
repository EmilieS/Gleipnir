using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    public class Apothecary : JobsModel //: INotifyPropertyChanged
    {
        public Apothecary()
        {
            _job = Game.Jobs.APOTHECARY;
            jobName = "Apothicaire";
            _workers = new List<Villager>();
            coefficient = 15;
            _gold = ModifyGoldGeneration();
        }

        // public event PropertyChangedEventHandler PropertyChanged;
    }
}
