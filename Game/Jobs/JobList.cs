using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public class JobList : IReadOnlyList<JobsModel>
    {
        readonly Apothecary _apothecary;
        readonly Blacksmith _blacksmith;
        readonly Construction_Worker _construction_worker;
        readonly Cooker _cooker;
        readonly Farmer _farmer;
        readonly Militia _militia;
        readonly Miller _miller;
        readonly Tailor _tailor;

        public JobsModel Apothecary { get { return _apothecary; } }
        public JobsModel Blacksmith { get { return _blacksmith; } }
        public JobsModel Construction_worker { get { return _construction_worker; } }
        public JobsModel Cooker { get { return _cooker; } }
        public JobsModel Farmer { get { return _farmer; } }
        public JobsModel Militia { get { return _militia; } }
        public JobsModel Miller { get { return _miller; } }
        public JobsModel Tailor { get { return _tailor; } }

        readonly List<JobsModel> _jobList;
        readonly List<JobsModel> _happinessJobList;

        internal IReadOnlyList<JobsModel> HappinessJobList { get { return _happinessJobList; } }
        //public IReadOnlyList<JobsModel> List { get { return _jobList; } }
        internal readonly Village _owner;

        public JobList(Village village)
        {
            Game game = village.Game;
            Debug.Assert(game != null, "Game doesn't exist!");
            _jobList = new List<JobsModel>();
            _happinessJobList = new List<JobsModel>();
            _apothecary = new Apothecary(game, this, "Apoticaire");
            _blacksmith = new Blacksmith(game, this, "Forgeron");
            _construction_worker = new Construction_Worker(game, this, "Ouvrier");
            _cooker = new Cooker(game, this, "Cuisinier");
            _farmer = new Farmer(game, this, "Fermier");
            _militia = new Militia(game, this, "Milice");
            _miller = new Miller(game, this, "Meunier");
            _tailor = new Tailor(game, this, "Tailleur");
            _jobList.Add(_apothecary);
            _jobList.Add(_blacksmith);
            _jobList.Add(_construction_worker);
            _jobList.Add(_cooker);
            _jobList.Add(_farmer);
            _jobList.Add(_militia);
            _jobList.Add(_miller);
            _jobList.Add(_tailor);
            _happinessJobList.Add(_cooker);
            _happinessJobList.Add(_miller);
            _happinessJobList.Add(_tailor);
            _owner = village;
        }
        public JobsModel this[int index]
        {
            get { return _jobList[index]; }
        }

        public int Count
        {
            get { return _jobList.Count; }
        }

        public IEnumerator<JobsModel> GetEnumerator()
        {
            return _jobList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
