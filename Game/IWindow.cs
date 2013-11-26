using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IWindow
    {

        void PushTrace(string message);
        void PushAlert(string message);
        void PushPopulation(int pop);
        void PushGeneralGold(int value);
        void PushGeneralCoins(int value);
        void PushGeneralFaith(double value);
        void PushGeneralHappiness(double value);
        void PushName(string name);

    }
}
