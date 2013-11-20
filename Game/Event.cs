using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{


    public class Event<T> : IEvent
        //where T : GameItem
    {
        public readonly T GameItem;

        protected Event(T item)
        {
            GameItem = item;
        }

        public virtual void PublishMessage(IWindow b)
        {
        }
    }

    public class EventProperty<T> : Event<T>
    {
        public readonly string ChangedProperty;

        internal EventProperty(T item, string propName)
            : base(item)
        {
            ChangedProperty = propName;
        }

        override public  void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Property {0} has changed...", ChangedProperty));
        }
    }

    public class VillagerDyingEvent : Event<Villager>
    {
        internal VillagerDyingEvent(Villager v)
            : base(v)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            string toPush;
            if ((GameItem.Health & Healths.DEPRESSED) != 0)
            {
                toPush = String.Format("{0} s'est suicidé", GameItem.Name);
            }
            else if ((GameItem.Health & Healths.SICK) != 0)
            {
                toPush = String.Format("{0} est mort de sa maladie", GameItem.Name);
            }
            else if (GameItem.Age > 80)
            {
                toPush = String.Format("{0} est mort de viellesse", GameItem.Name);
            }
            else
            {
                toPush = String.Format("{0} est mort mystèrieusement", GameItem.Name);
            }

            b.PushAlert(toPush);
        }
    }
    public class FamilyEndEvent : Event<Family>
    {
        internal FamilyEndEvent(Family v)
            : base(v)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("La famille {0} est terminée.", GameItem.Name));
        }
    }
}
/*
// Two good ways to challenge types!
if (GameItem is Villager)
{
    Villager v1 = (Villager)GameItem;
}

Villager v2 = GameItem as Villager;
if (v2 != null)
{
    if (ChangedProperty == "Happiness")
    {
        _happinessLabel.Text = v2.Happiness.ToString();
    }
}
// The horrible way todo it:
// Violation of the Lyskov Substitution Principle. 
if (GameItem.GetType() == typeof(Villager))
{
    Villager v3 = (Villager)GameItem;
}
*/
