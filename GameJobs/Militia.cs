using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    public class Militia : JobsModel //: INotifyPropertyChanged
    {
        public Militia()
        {
            _job = Jobs.MILITIA;
            jobName = "Milice";
            _workers = new List<Villager>();
            coefficient = 8;
            _gold = ModifyGoldGeneration();
        }

        // public event PropertyChangedEventHandler PropertyChanged;
    }
}