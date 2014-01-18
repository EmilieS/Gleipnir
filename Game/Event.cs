using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Game
{

    [Serializable]
    public class Event<T> : IEvent
        //where T : GameItem
    {
        public readonly T GameItem;

        protected Event(T item)
        {
            GameItem = item;
        }
        public virtual void Do(IWindow b)
        {
        }
        public virtual void PublishMessage(IWindow b)
        {
        }
    }
    [Serializable]
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
        public override void Do(IWindow b)
        {
            base.Do(b);
        }
    }
    [Serializable]
    public class BuildingNoHpEvent : Event<Buildings.BuildingsModel>
    {
        internal BuildingNoHpEvent(Buildings.BuildingsModel building)
            : base(building)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushAlert(String.Format("{0} s'est écroulé", GameItem.Name), "Bâtiment");
        }

    }
    [Serializable]
    public class BuildingDestroyedEvent : Event<Buildings.BuildingsModel>
    {
        internal BuildingDestroyedEvent(Buildings.BuildingsModel building)
            : base(building)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("{0} is Destroyed", GameItem.Name));
        }

    }
    [Serializable]
    public class BuildingCreatedEvent : Event<Buildings.BuildingsModel>
    {
        internal BuildingCreatedEvent(Buildings.BuildingsModel building)
            : base(building)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("{0} is created", GameItem.Name));
        }

    }
    [Serializable]
    public class GameEventProperty: EventProperty<Game>
    {
        internal GameEventProperty(Game item, string propName)
            : base(item, propName)
        {
        }
        public override void Do(IWindow b)
        {
            switch (ChangedProperty)
            {
                case "Offerings": b.PushGeneralCoins(GameItem.Offerings); break;
                case "TotalPop": b.PushPopulation(GameItem.TotalPop) ; break;
                case "TotalGold": b.PushGeneralGold(GameItem.TotalGold); break;
                case "AverageFaith": b.PushGeneralFaith(GameItem.AverageFaith); break;
                case "AverageHappiness": b.PushGeneralHappiness(GameItem.AverageHappiness); break;
            }
            //GameItem.GetType().GetProperty(ChangedProperty, typeof(string));
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Property {0} has changed...", ChangedProperty));
        }
    }
    [Serializable]
    public class VillageEventProperty : EventProperty<Village>
    {
        internal VillageEventProperty(Village item, string propName)
            : base(item, propName)
        {
        }
        public override void Do(IWindow b)
        {
            switch (ChangedProperty)
            {
                case "OfferingsPointsPerTick": b.PushOfferingsPointsPerTick(GameItem.OfferingsPointsPerTick); break;
            }

        }

    }
    [Serializable]
    public class VillagerDyingEvent : Event<Villager>
    {
        internal VillagerDyingEvent(Villager v, string familyName)
            : base(v)
        {
            _familyName = familyName;
        }
        string _familyName;
        override public void PublishMessage(IWindow b)
        {
            string toPush;
            if ((GameItem.Health & Healths.DEPRESSED) != 0)
            {
                toPush = String.Format("{0} {1} s'est suicidé", GameItem.FirstName, _familyName);
            }
            else if ((GameItem.Health & Healths.EARTHQUAKE_INJURED) != 0)
            {
                toPush = String.Format("{0} {1} est mort suite au tremblement de terre", GameItem.FirstName, _familyName);
            }
            else if ((GameItem.Health & Healths.SICK) != 0)
            {
                toPush = String.Format("{0} {1} est mort de sa maladie", GameItem.FirstName, _familyName);
            }
            else if (GameItem.Age > 60*12)
            {
                toPush = String.Format("{0} {1} est mort de viellesse", GameItem.FirstName, _familyName);
            }
            else
            {
                toPush = String.Format("{0} {1} est mort mystèrieusement", GameItem.FirstName, _familyName);
            }
            //Debug.Assert(toPush == "i");//va bien dedans!
            b.PushAlert(toPush,"Mort");
        }
    }
    [Serializable]
    public class VillagerCallForHelp : Event<Villager>
    {
        internal VillagerCallForHelp(Villager v)
            : base(v)
        {
        }
        override public void PublishMessage(IWindow b)
        {
            b.PushAlert(String.Format("{0} {1} prie que son malheur soit bientot terminé.", GameItem.FirstName, GameItem.ParentFamily.Name), "Prière");
        }
    }
    [Serializable]
    public class EpidemicDeclaredEvent : Event<GodSpell.Epidemic>
    {
        internal EpidemicDeclaredEvent(GodSpell.Epidemic e)
            : base(e)
        {
        }
        override public void PublishMessage(IWindow b)
        {
            b.PushAlert("Plusieurs vilageois sont malades, la population cherche votre aide.", "Epidémie");
        }

    }

    [Serializable]
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
    [Serializable]
    public class VillagerBirthEvent : Event<Villager>
    {
        internal VillagerBirthEvent(Villager v)
            : base(v)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace( String.Format("Un nouveau villageois est né ! Il a été nommé {0}.", GameItem.FirstName));
            if (GameItem.Job == null)
                b.PushAlert(String.Format("Le nouveau villageois {0} {1} ne sait pas quel métier prendre...", GameItem.FirstName, GameItem.ParentFamily.Name), "Demande d'attribution de métier");
        }
    }
    [Serializable]
    public class FamilyBirthEvent : Event<Family>
    {
        internal FamilyBirthEvent(Family v)
            : base(v)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Une nouvelle famille s'est consituée {0}.", GameItem.Name));
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
