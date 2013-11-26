using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Tests
{
    public class IWindowImplementationForTests : IWindow
    {
        public IWindowImplementationForTests() { }

        public void PushTrace(string message)
        {
            nb_pushTrace++;
        }
        public void PushAlert(string message, string title)
        {
            nb_pushAlert++;
        }

        public void PushGeneralCoins(int value) { }
        public void PushGeneralGold(int value) { }
        public void PushGeneralHappiness(double value) { }
        public void PushGeneralFaith(double value) { }
        public void PushName(string name) { }
        public int nb_pushTrace;
        public int nb_pushAlert;
        public void PushPopulation(int pop) { }
    }
}
