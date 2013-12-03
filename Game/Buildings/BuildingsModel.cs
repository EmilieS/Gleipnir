using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public abstract class BuildingsModel
    {
        int _verticalPos;
        int _horizontalPos;
        double _addedHappiness;
        double _addedFaith;
        double _enterPrice;
        //double _robustness;
        double _addedRobustness;
        bool _isBought;
        string _name;
        Game actualGame;
        // this a provisory solution : using a new "materials"  to implement robustness

        internal BuildingsModel(Game g)
            : base()
        {
            _horizontalPos = 0;
            _verticalPos = 0;
            _addedHappiness = 0;
            _addedFaith = 0;
            _enterPrice = 0;
            //_robustness = 0;
            _isBought = false;
            g.AddBuildingIntheList(this);
        }
        public int HorizontalPos
        {
            get { return _horizontalPos; }
            set { _horizontalPos = value; }
        }
        public string Name
        {
            get{return _name;}
            set { _name = value; }
        }
        public int VerticalPos
        {
            get { return _verticalPos; }
            set { _verticalPos = value; }
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
        internal bool IsBought
        {
            get { return _isBought; }
            set { _isBought = value; }
        }

    }
}
