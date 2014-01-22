using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game.Buildings
{
    [Serializable]
    public abstract class BuildingsModel : GameItem
    {
        int _verticalPos;
        int _horizontalPos;
        int _costPrice;
        double _addedHappiness;
        double _addedFaith;
        double _enterPrice;
        bool _isBought;
        string _name;
        readonly HistorizedValue<int, BuildingsModel> _hp;
        int _maxHp;
        int _destroyedTimer;
        bool _justCreated;
        

        internal Village _village;
        public Village Village { get { return _village; } }

        public BuildingsModel(Village v)
            :base(v.Game)
        {
            _hp = new HistorizedValue<int, BuildingsModel>(this, @"_hp", 20);
            _justCreated = true;
            _horizontalPos = 0;
            _verticalPos = 0;
            _addedHappiness = 0;
            _addedFaith = 0;
            _enterPrice = 0;
            _isBought = false;//old code
            _village = v;
            AddToList();
        }
        abstract internal void AddToList();

        public int Hp { get { return _hp.Current; } internal set { _hp.Current = value; } }
        public int MaxHp { get{ return _maxHp; } internal set{_maxHp=value; }}
        int _damageRepairTimer;
        /// <summary>
        /// must be positive.
        /// </summary>
        /// <param name="amount"></param>
        internal void Damage(int amount)
        {
            if (amount < 0) { throw new ArgumentException(); }
            if (amount == 0) { return; }
            OnDamage();
            if (_hp.Current - amount < 0)
            {
                _hp.Current = 0;
            }
            else
            {
                _hp.Current -= amount;
            }
            _damageRepairTimer++;
        }

        internal virtual void OnDamage() { }

        /// <summary>
        /// Repair. amount must be positive.
        /// </summary>
        /// <param name="amount"></param>
        internal void Repair(int amount)
        {
            if (amount < 0) { throw new ArgumentException(); }
            if (amount == 0)
                return;
            if (_hp + amount > _maxHp)
                _hp = _maxHp;
            else
            _hp += amount;

            Game.DamagedBuildingsNotRepairedOrRepairedFaithImpact(5);
            _damageRepairTimer = 0;
        }
        internal bool Repair2(int amount)
        {
            Debug.Assert(amount > 0, "(Repair2|BuildingsModel) amount is negative or null");
            if (_hp.Current < 1)
                return false;

            if (_hp.Current + amount >= _maxHp)
            {
                _hp.Current = _maxHp;
            }
            else
            {
                _hp.Current += amount;
            }

            Game.DamagedBuildingsNotRepairedOrRepairedFaithImpact(0.1);
            _damageRepairTimer = 0;

            if (_hp.Current >= MaxHp)
                return true;
            return false;
        }


        public int HorizontalPos
        {
            get { return _horizontalPos; }
            set { _horizontalPos = value; }
        }
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }
        public int VerticalPos
        {
            get { return _verticalPos; }
            set { _verticalPos = value; }
        }
        public int CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = value; }
        }
        internal double AddFaith
        {
            get { return _addedFaith; }
            set { _addedFaith = value; }
        }
        internal double AddHapiness
        {
            get { return _addedHappiness; }
            set { _addedHappiness = value; }
        }
        internal double EnterPrice
        {
            get { return _enterPrice; }
            set { _enterPrice = value; }
        }
        public bool IsBought
        {
            get { return _isBought; }
            set { _isBought = value; }
        }

        public void SetCoordinates(int x, int y)
        {
            /*if (x == null || y == null)
                throw new ArgumentNullException("(buildingModel, SetCoordinates) X or Y doesn't exist");*/
            if ((x < 0 || x > Board.GridMaxRow) ||  (y < 0 || y > Board.GridMaxCol))
                throw new IndexOutOfRangeException(@"(buildingModel, SetCoordinates) Must be in tab");
            this.HorizontalPos = x;
            this.VerticalPos = y;
        }

        override internal void OnDestroy()
        {
            OnOnDestroy();
            
            _village = null;
        }
        abstract internal void OnOnDestroy();

        internal override void ImpactHappiness()
        {
            if (_damageRepairTimer == 36)
            {
                _damageRepairTimer = 0;
                Game.DamagedBuildingsNotRepairedOrRepairedFaithImpact(-5);
            }
            else if (_damageRepairTimer > 0 && _hp.Current < _maxHp)
            {
                _damageRepairTimer++;
            }
        }
        internal override void Evolution()
        {
            //moved into ImpactHappiness because damage in earthquake happens in evolution, repair(constructionworker) happens in evolution to.
        }
        internal override void DieOrIsAlive(List<IEvent> eventList)
        {            
            if (_hp.Current == 0)
            {
                if (_destroyedTimer == 3)
                {
                    eventList.Add(new BuildingDestroyedEvent(this));
                    Destroy();
                }
                else
                {
                    if (_destroyedTimer == 1)
                    {
                        eventList.Add(new BuildingNoHpEvent(this));
                        JustCollapsed();
                    }
                }
                _destroyedTimer++;
            }
            else
            {
                _destroyedTimer = 0;
            }
        }

        virtual internal void JustCollapsed()
        {

        }

        internal override void CloseStep(List<IEvent> eventList)
        {//event fully repaired.
            if (_justCreated)
            {
                eventList.Add(new BuildingCreatedEvent(this));
                _justCreated = false;
            }
            if (_hp.Conclude()) { eventList.Add(new EventProperty<BuildingsModel>(this, @"HP")); }
        }
    }
}
