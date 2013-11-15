using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    class BuyConditions
    {
        bool _couldBeBought;

        internal BuyConditions()
        {
            _couldBeBought = false;
        }
        internal bool CouldBeBought
        {
            get { return _couldBeBought; }
            set { _couldBeBought = value; }
        }
        public bool VerifyBuyCondition()
        {
            // TODO : look at here 
            return CouldBeBought;

        }
    }
}
