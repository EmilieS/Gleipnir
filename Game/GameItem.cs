using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public abstract class GameItem
    {
        Game _game;

        protected GameItem(Game g)
        {
            if (g == null) throw new ArgumentNullException("g");
            _game = g;
            _game.GameItemCreated(this);
        }

        public Game Game { get { return _game; } }

        public bool IsDestroyed { get { return _game == null; } }


        internal virtual void ImpactHappiness() {}

        internal virtual void Evolution() {}

        internal virtual void Creation(List<IEvent> eventList) { }

        internal void Destroy()
        {
            Debug.Assert(_game != null, "Destroy must be called only once.");
            OnDestroy();
            _game.GameItemDestroyed(this);
            _game = null;
        }
        internal abstract void OnDestroy();
        internal virtual void DieOrIsAlive(List<IEvent> eventList){}

        internal abstract void CloseStep(List<IEvent> eventList);
    }
}
