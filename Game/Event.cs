using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Game
{

    [Serializable]
    public class Event<T> : IEvent //where T : GameItem
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

        override public void PublishMessage(IWindow b)
        {
            Debug.Assert(ChangedProperty != null, "public class EventProperty<T> : Event<T>, PublishMessage [Event] ChangedProperty is null !");
            Debug.Assert(b != null, "public class EventProperty<T> : Event<T>, PublishMessage [Event] IWindow b is null !");
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
            b.PushTrace(String.Format("{0} collapsed", GameItem.Name));
        }

    }
    [Serializable]
    public class BuildingDestroyedEvent : Event<Buildings.BuildingsModel>
    {
        Buildings.BuildingsModel _building;

        internal BuildingDestroyedEvent(Buildings.BuildingsModel building)
            : base(building)
        {
            _building = building;
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("{0} is Destroyed", GameItem.Name));
        }

        public override void Do(IWindow b)
        {
            base.Do(b);
            b.SetEmptySquare(_building.HorizontalPos, _building.VerticalPos);
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
    public class GameEventProperty : EventProperty<Game>
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
                case "TotalPop": b.PushPopulation(GameItem.TotalPop); if (GameItem.TotalPop == 0) { b.GameLost(); } break;
                case "TotalGold": b.PushGeneralGold(GameItem.TotalGold); break;
                case "AverageFaith": b.PushGeneralFaith(GameItem.AverageFaith); if (GameItem.AverageFaith == 0) { b.GameLost(); } break;
                case "AverageHappiness": b.PushGeneralHappiness(GameItem.AverageHappiness); break;
            }
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
            else if (GameItem.Age > 60 * 12)
            {
                toPush = String.Format("{0} {1} est mort de viellesse", GameItem.FirstName, _familyName);
            }
            else if ((GameItem.Health & Healths.HUNGRY) != 0)
            {
                toPush = String.Format("{0} {1} est mort de malnutrition", GameItem.FirstName, _familyName);
            }
            else
            {
                toPush = String.Format("{0} {1} est mort mystèrieusement", GameItem.FirstName, _familyName);
            }
            //Debug.Assert(toPush == "i");//va bien dedans!
            b.PushAlert(toPush, "Mort");
            b.PushTrace("Villager died.");
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
            b.PushTrace("Villager is depressed");
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
            b.PushTrace("Warn player of epidemic.");
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
            b.PushTrace(String.Format("The family {0} is destroyed.", GameItem.Name));
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
            b.PushTrace(String.Format("Un nouveau villageois est né ! Il a été nommé {0}.", GameItem.FirstName));
            if (GameItem.Job == null)
                b.PushAlert(String.Format("Le nouveau villageois {0} {1} ne sait pas quel métier prendre...", GameItem.FirstName, GameItem.ParentFamily.Name), "Demande d'attribution de métier");
        }
    }
    [Serializable]
    public class FamilyBirthEvent : Event<Family>
    {
        Family _family;
        internal FamilyBirthEvent(Family f)
            : base(f)
        {
            _family = f;
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Une nouvelle famille s'est consituée {0}.", GameItem.Name));
        }
        public override void Do(IWindow b)
        {
            base.Do(b);
            b.AddNewFamilyHouse(_family.House);
        }
    }
    [Serializable]
    public class EpidimicEradicatedEvent : Event<GodSpell.Epidemic>
    {
        Game _game;
        internal EpidimicEradicatedEvent(GodSpell.Epidemic v, Game g)
            : base(v)
        {
            _game = g;
        }
        override public void PublishMessage(IWindow b)
        {
            string toPush = "L'épidémie a été éradiquée.";
            if (_game.TotalPop > 0)
            {
                b.PushAlert(toPush, "Epidémie");
            }
                b.PushTrace(toPush);
        }
    }
    [Serializable]
    public class BuildingHpChanged : Event<Buildings.BuildingsModel>
    {
        public readonly string ChangedProperty;

        internal BuildingHpChanged(Buildings.BuildingsModel item, string propName)
            : base(item)
        {
            ChangedProperty = propName;
        }

        override public void PublishMessage(IWindow b)
        {
            Debug.Assert(ChangedProperty != null, "public class EventProperty<T> : Event<T>, PublishMessage [Event] ChangedProperty is null !");
            Debug.Assert(b != null, "public class EventProperty<T> : Event<T>, PublishMessage [Event] IWindow b is null !");
            b.PushTrace(String.Format("Property {0} has changed...", ChangedProperty));
            if (GameItem.Hp == GameItem.MaxHp)
            {
                b.PushAlert(String.Format("{0} est réparé.", GameItem.Name), "Bâtiment");
            }
        }
        public override void Do(IWindow b)
        {
            base.Do(b);
        }
    }
    [Serializable]
    public class SamhaimFestEndedEvent : Event<SamhainFest>
    {
        internal SamhaimFestEndedEvent(SamhainFest fest)
            : base(fest)
        {
        }
        override public void PublishMessage(IWindow b)
        {
            b.PushAlert("Le festival est terminé.", "Festival");
            b.PushTrace("SamhaimFest destroyed");
        }
    }
    [Serializable]
    public class SamhaimFestStartedEvent : Event<SamhainFest>
    {
        internal SamhaimFestStartedEvent(SamhainFest fest)
            : base(fest)
        {
        }
        override public void PublishMessage(IWindow b)
        {
            b.PushAlert("Le festival a commencé.", "Festival");
            b.PushTrace("SamhaimFest created");
        }
    }
    [Serializable]
    public class NotEnoughFarmsEvent : Event<Farmer>
    {
        internal NotEnoughFarmsEvent(Farmer farmer)
            : base(farmer)
        {
        }
        override public void PublishMessage(IWindow b)
        {
            b.PushAlert("Il n'y a pas assez de fermes pour embaucher de nouveaux fermiers.", "Fermiers");
            b.PushTrace("EnoughFarms went to true to false");
        }
    }
    [Serializable]
    public class HungryFamilyEvent : Event<Family>
    {
        Family _family;
        internal HungryFamilyEvent(Family f)
            : base(f)
        {
            _family = f;
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Family {0} hungry status changed.", GameItem.Name));
            if (GameItem._hungry.Current == true)
            {
                b.PushAlert(String.Format("La famille {0} a faim.", GameItem.Name), "Famine");
            }
            b.PushTrace("Family hunger property has changed.");
        }
    }
    [Serializable]
    public class MeetingDestroyedEvent : Event<Meeting>
    {
        string _familyName;
        internal MeetingDestroyedEvent(Meeting m, string familyName)
            : base(m)
        {
            _familyName = familyName;
        }
        override public void PublishMessage(IWindow b)
        {
            string toPush = String.Format("La convocation de la famille {0} est terminée.", _familyName);
            b.PushAlert(toPush, "Convocation");
            b.PushTrace("Convocation destroyed");
        }
    }
    [Serializable]
    public class EpidemicBirthEvent : Event<GodSpell.Epidemic>
    {
        internal EpidemicBirthEvent(GodSpell.Epidemic e)
            : base(e)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Epedemic created."));
        }
    }
    [Serializable]
    public class MeetingCreatedEvent : Event<Meeting>
    {
        internal MeetingCreatedEvent(Meeting e)
            : base(e)
        {
        }

        override public void PublishMessage(IWindow b)
        {
            b.PushTrace(String.Format("Meeting created."));
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
