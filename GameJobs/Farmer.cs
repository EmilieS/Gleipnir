using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    public class Farmer : JobsModel //: INotifyPropertyChanged
    {
        public Farmer()
        {
            _job = Jobs.FARMER;
            jobName = "Fermier";
            _workers = new List<Villager>();
            coefficient = 10;
            _gold = ModifyGoldGeneration();
        }
        
        // public event PropertyChangedEventHandler PropertyChanged;
    }
}
