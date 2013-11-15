﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updates.Crafter.Materials;

namespace Buildings
{
    public class BuildingsProperties
    {
        int _verticalPos;
        int _horizontalPos;
        
        double _addedHappiness;
        double _addedFaith;
        double _enterPrice;
        //double _robustness;
        double _addedRobustness;

        // this a provisory solution : using a new "materials"  to implement robustness
        Materials mat = new Materials();

        public BuildingsProperties()
        {
            _horizontalPos = 0;
            _verticalPos = 0;
            _addedHappiness = 0;
            _addedFaith = 0;
            _enterPrice = 0;
            //_robustness = 0;
            _addedRobustness = mat.SetTotalPower();
        }

        public int HorizontalPos
        {
            get { return _horizontalPos; }
            set { _horizontalPos = value; }
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

        
    }
}
