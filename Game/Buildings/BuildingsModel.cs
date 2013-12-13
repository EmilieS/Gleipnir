﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public abstract class BuildingsModel : GameItem
    {
        int _verticalPos;
        int _horizontalPos;
        int _costPrice;
        double _addedHappiness;
        double _addedFaith;
        double _enterPrice;
        //double _robustness;
        double _addedRobustness;
        bool _isBought;
        string _name;
        //Game actualGame;
        //private Game g;
        // this a provisory solution : using a new "materials"  to implement robustness

        Village _village;
        public Village Village { get { return _village; } }

        public BuildingsModel(Village v)
            :base(v.Game)
        {
            _horizontalPos = 0;
            _verticalPos = 0;
            _addedHappiness = 0;
            _addedFaith = 0;
            _enterPrice = 0;
            //_robustness = 0;
            _isBought = false;//old code
            //actualGame = g;            
            //TODO: Complete member initialization
            //this.g = g;
            _village = v;
            AddToList();
        }
        abstract internal void AddToList();

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
        override internal void OnDestroy()
        {
            OnOnDestroy();
            
            _village = null;
        }
        abstract internal void OnOnDestroy();
        internal override void CloseStep(List<IEvent> eventList)
        {
            throw new NotImplementedException();
        }
    }
}
