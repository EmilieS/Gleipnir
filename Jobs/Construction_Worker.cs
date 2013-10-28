using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    class Construction_Worker : INotifyPropertyChanged
    {
        List<object> _Persons;
        Jobs _job;

        public Construction_Worker()
        {
        }

        public void AddPerson()
        {
        }

        public void RemovePerson()
        {
        }

        public void GenerateGoldAndHappiness()
        {
        }

        public void ModifyGoldGeneration()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
