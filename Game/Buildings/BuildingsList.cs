using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class BuildingsList : IReadOnlyList<BuildingsModel>
    {
        readonly Baths _baths;
        readonly Brothel _brothel;
        readonly Chapel _chapel;
        readonly Farm _farm;
        readonly Forge _forge;
        readonly Mill _mill;
        readonly OfferingWarehouse _offeringWarehouse;
        readonly PartyRoom _partyRoom;
        readonly Restaurant _restaurant;
        readonly TablePlace _tablePlace;
        readonly Tavern _tavern;
        readonly Theater _theater;
        readonly UnionOfCrafter _unionOfCrafter;

        public BuildingsModel Baths { get { return _baths; } }
        public BuildingsModel Brothel { get { return _brothel; } }
        public BuildingsModel Chapel { get { return _chapel; } }
        public BuildingsModel Farm { get { return _farm; } }
        public BuildingsModel Forge { get { return _forge; } }
        public BuildingsModel Mill { get { return _mill; } }
        public BuildingsModel OfferingWarehouse { get { return _offeringWarehouse; } }
        public BuildingsModel PartyRoom { get { return _partyRoom; } }
        public BuildingsModel Restaurant { get { return _restaurant; } }
        public BuildingsModel TablePlace { get { return _tablePlace; } }
        public BuildingsModel Tavern { get { return _tavern; } }
        public BuildingsModel Theater { get { return Theater; } }
        public BuildingsModel UnionOfCrafter { get { return _unionOfCrafter; } }

        

        readonly List<BuildingsModel> _buildingsList;

        public BuildingsList(Village village)
        {
            _buildingsList = new List<BuildingsModel>();
            _baths = new Baths(g, this, "Bains");
            _brothel = new Brothel(g, this, "Bordel");
            _chapel = new Chapel(g, this, "Chapelle");
            _farm = new Farm(g, this, "Ferme");
            _forge = new Forge(g, this, "Forge");
            _mill = new Mill(g, this, "Moulin");
            _offeringWarehouse = new OfferingWarehouse(g, this, "Entrepôt");
            _partyRoom = new PartyRoom(g, this, "Salle de Fête");
            _restaurant = new Restaurant(g, this, "Restaurant");
            _tablePlace = new TablePlace(g, this, "Table");
            _tavern = new Tavern(g, this, "Taverne");
            _theater = new Theater(g, this, "Théatre");
            _unionOfCrafter = new UnionOfCrafter(g, this, "Syndicat des Ouvriers");
            _buildingsList.Add(_baths);
            _buildingsList.Add(_brothel);
            _buildingsList.Add(_chapel);
            _buildingsList.Add(_farm);
            _buildingsList.Add(_forge);
            _buildingsList.Add(_mill);
            _buildingsList.Add(_offeringWarehouse);
            _buildingsList.Add(_partyRoom);
            _buildingsList.Add(_restaurant);
            _buildingsList.Add(_tablePlace);
            _buildingsList.Add(_tavern);
            _buildingsList.Add(_theater);
            _buildingsList.Add(_unionOfCrafter);
        }
        public BuildingsModel this[int index]
        {
            get { return _buildingsList[index]; }
        }

        public int Count
        {
            get { return _buildingsList.Count; }
        }

        public IEnumerator<BuildingsModel> GetEnumerator()
        {
            return _buildingsList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
