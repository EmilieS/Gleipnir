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
        public void PushAlert(string message)
        {
            nb_pushAlert++;
        }


        public int nb_pushTrace;
        public int nb_pushAlert;
    }
}
