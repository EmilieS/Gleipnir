using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class BuildingsList : IReadOnlyList<BuildingsModel>
    {
        readonly List<ApothecaryOffice> _apothecaryOfficeList;
        readonly List<Baths> _bathsList;
        readonly List<Brothel> _brothelList;
        readonly List<Chapel> _chapelList;
        readonly List<Farm> _farmList;
        readonly List<Forge> _forgeList;
        readonly List<Mill> _millList;
        readonly List<OfferingWarehouse> _offeringWarehouseList;
        readonly List<PartyRoom> _partyRoomList;
        readonly List<Restaurant> _restaurantList;
        readonly List<TablePlace> _tablePlaceList;
        readonly List<Tavern> _tavernList;
        readonly List<Theater> _theaterList;
        readonly List<UnionOfCrafter> _unionOfCrafterList;

        public IReadOnlyList<ApothecaryOffice> ApothecaryOfficeList { get { return _apothecaryOfficeList; } }
        public  IReadOnlyList<BuildingsModel> BathsList { get { return _bathsList; } }
        public  IReadOnlyList<BuildingsModel> BrothelList{ get { return _brothelList; } }
        public  IReadOnlyList<BuildingsModel> ChapelList{ get { return _chapelList; } }
        public  IReadOnlyList<BuildingsModel> FarmList{ get { return _farmList; } }
        public  IReadOnlyList<BuildingsModel> ForgeList{ get { return _forgeList; } }
        public  IReadOnlyList<BuildingsModel> MillList{ get { return _millList; } }
        public  IReadOnlyList<BuildingsModel> OfferingWarehouseList{ get { return _offeringWarehouseList; } }
        public  IReadOnlyList<BuildingsModel> PartyRoomList{ get { return _partyRoomList; } }
        public  IReadOnlyList<BuildingsModel> RestaurantList{ get { return _restaurantList; } }
        public  IReadOnlyList<BuildingsModel> TablePlaceList{ get { return _tablePlaceList; } }
        public  IReadOnlyList<BuildingsModel> TavernList{ get { return _tavernList; } }
        public  IReadOnlyList<BuildingsModel> TheaterList{ get { return _theaterList; } }
        public  IReadOnlyList<BuildingsModel> UnionOfCrafterList { get { return _unionOfCrafterList; } }

        /*
        #region oldcode
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
        #endregion
        */

        readonly List<BuildingsModel> _buildingsList;

        public BuildingsList(Village village)
        {
            Game g = village.Game;
            _buildingsList = new List<BuildingsModel>();

            _apothecaryOfficeList = new List<ApothecaryOffice>();
            _bathsList=new List<Buildings.Baths>();
            _brothelList=new List<Buildings.Brothel>();
             _chapelList=new List<Buildings.Chapel>();
            _farmList=new List<Buildings.Farm>();
            _forgeList=new List<Buildings.Forge>();
            _millList=new List<Buildings.Mill>();
            _offeringWarehouseList = new List<Buildings.OfferingWarehouse>();
            _partyRoomList = new List<Buildings.PartyRoom>();
            _restaurantList = new List<Buildings.Restaurant>();
            _tablePlaceList = new List<Buildings.TablePlace>();
            _tavernList = new List<Buildings.Tavern>();
            _theaterList = new List<Buildings.Theater>();
            _unionOfCrafterList = new List<Buildings.UnionOfCrafter>();
            /*
            #region old code
            _baths = new Baths(village, this, "Bains");
            _brothel = new Brothel(village, this, "Bordel");
            _chapel = new Chapel(village, this, "Chapelle");
            _farm = new Farm(village, this, "Ferme");
            _forge = new Forge(village, this, "Forge");
            _mill = new Mill(village, this, "Moulin");
            _offeringWarehouse = new OfferingWarehouse(village, this, "Entrepôt");
            _partyRoom = new PartyRoom(village, this, "Salle de Fête");
            _restaurant = new Restaurant(village, this, "Restaurant");
            _tablePlace = new TablePlace(village, this, "Table");
            _tavern = new Tavern(village, this, "Taverne");
            _theater = new Theater(village, this, "Théatre");
            _unionOfCrafter = new UnionOfCrafter(village, this, "Syndicat des Ouvriers");
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
            #endregion
            */
        }
        internal void Add(ApothecaryOffice apothecaryOffice)
        {
            _apothecaryOfficeList.Add(apothecaryOffice);
            _buildingsList.Add(apothecaryOffice);
        }
        internal void Add(Baths baths)
        {
            _bathsList.Add(baths);
            _buildingsList.Add(baths);
        }
        internal void Add(Brothel brothel)
        {
            _brothelList.Add(brothel);
            _buildingsList.Add(brothel);
        }
        internal void Add(Chapel chapel)
        {
            _chapelList.Add(chapel);
            _buildingsList.Add(chapel);
        }
        internal void Add(Farm farm)
        {
            _farmList.Add(farm);
            _buildingsList.Add(farm);
        }
        internal void Add(Forge forge)
        {
            _forgeList.Add(forge);
            _buildingsList.Add(forge);
        }
        internal void Add(Mill mill)
        {
            _millList.Add(mill);
            _buildingsList.Add(mill);
        }
        internal void Add(OfferingWarehouse offeringWarehouse)
        {
            _offeringWarehouseList.Add(offeringWarehouse);
            _buildingsList.Add(offeringWarehouse);
        }
        internal void Add(PartyRoom partyRoom)
        {
            _partyRoomList.Add(partyRoom);
            _buildingsList.Add(partyRoom);
        }
        internal void Add(Restaurant restaurant)
        {
            _restaurantList.Add(restaurant);
            _buildingsList.Add(restaurant);
        }
        internal void Add(TablePlace tablePlace)
        {
            _tablePlaceList.Add(tablePlace);
            _buildingsList.Add(tablePlace);
        }
        internal void Add(Tavern tavern)
        {
            _tavernList.Add(tavern);
            _buildingsList.Add(tavern);
        }

        internal void Add(Theater theater)
        {
            _theaterList.Add(theater);
            _buildingsList.Add(theater);
        }
        internal void Add(UnionOfCrafter unionOfCrafter)
        {
            _unionOfCrafterList.Add(unionOfCrafter);
            _buildingsList.Add(unionOfCrafter);
        }
        internal void Remove(Baths baths)
        {
            _bathsList.Remove(baths);
            _buildingsList.Remove(baths);
        }
        internal void Remove(Brothel brothel)
        {
            _brothelList.Remove(brothel);
            _buildingsList.Remove(brothel);
        }
        internal void Remove(Chapel chapel)
        {
            _chapelList.Remove(chapel);
            _buildingsList.Remove(chapel);
        }
        internal void Remove(Farm farm)
        {
            _farmList.Remove(farm);
            _buildingsList.Remove(farm);
        }
        internal void Remove(Forge forge)
        {
            _forgeList.Remove(forge);
            _buildingsList.Remove(forge);
        }
        internal void Remove(Mill mill)
        {
            _millList.Remove(mill);
            _buildingsList.Remove(mill);
        }
        internal void Remove(OfferingWarehouse offeringWarehouse)
        {
            _offeringWarehouseList.Remove(offeringWarehouse);
            _buildingsList.Remove(offeringWarehouse);
        }
        internal void Remove(PartyRoom partyRoom)
        {
            _partyRoomList.Remove(partyRoom);
            _buildingsList.Remove(partyRoom);
        }
        internal void Remove(Restaurant restaurant)
        {
            _restaurantList.Remove(restaurant);
            _buildingsList.Remove(restaurant);
        }
        internal void Remove(TablePlace tablePlace)
        {
            _tablePlaceList.Remove(tablePlace);
            _buildingsList.Remove(tablePlace);
        }
        internal void Remove(Tavern tavern)
        {
            _tavernList.Remove(tavern);
            _buildingsList.Remove(tavern);
        }

        internal void Remove(Theater theater)
        {
            _theaterList.Remove(theater);
            _buildingsList.Remove(theater);
        }
        internal void Remove(UnionOfCrafter unionOfCrafter)
        {
            _unionOfCrafterList.Remove(unionOfCrafter);
            _buildingsList.Remove(unionOfCrafter);
        }

        internal void Remove(ApothecaryOffice apothecaryOffice)
        {
            _apothecaryOfficeList.Remove(apothecaryOffice);
            _buildingsList.Remove(apothecaryOffice);
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
