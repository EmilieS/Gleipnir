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

    }
}
