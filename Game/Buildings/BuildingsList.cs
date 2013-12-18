using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class BuildingsList : IReadOnlyList<BuildingsModel>
    {
        readonly List<House> _houseList;
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

        public IReadOnlyList<House> HouseList { get { return _houseList; } }
        public IReadOnlyList<BuildingsModel> ApothecaryOfficeList { get { return _apothecaryOfficeList; } }
        public IReadOnlyList<BuildingsModel> BathsList { get { return _bathsList; } }
        public IReadOnlyList<BuildingsModel> BrothelList{ get { return _brothelList; } }
        public IReadOnlyList<BuildingsModel> ChapelList{ get { return _chapelList; } }
        public IReadOnlyList<BuildingsModel> FarmList{ get { return _farmList; } }
        public IReadOnlyList<BuildingsModel> ForgeList{ get { return _forgeList; } }
        public IReadOnlyList<BuildingsModel> MillList{ get { return _millList; } }
        public IReadOnlyList<BuildingsModel> OfferingWarehouseList{ get { return _offeringWarehouseList; } }
        public IReadOnlyList<BuildingsModel> PartyRoomList{ get { return _partyRoomList; } }
        public IReadOnlyList<BuildingsModel> RestaurantList{ get { return _restaurantList; } }
        public IReadOnlyList<BuildingsModel> TablePlaceList{ get { return _tablePlaceList; } }
        public IReadOnlyList<BuildingsModel> TavernList{ get { return _tavernList; } }
        public IReadOnlyList<BuildingsModel> TheaterList{ get { return _theaterList; } }
        public IReadOnlyList<BuildingsModel> UnionOfCrafterList { get { return _unionOfCrafterList; } }

        readonly List<BuildingsModel> _buildingsList;

        public BuildingsList(Village village)
        {
            Game g = village.Game;
            _buildingsList = new List<BuildingsModel>();

            _houseList = new List<House>();
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

        }
        public void Add(House house)
        {
            _houseList.Add(house);
            _buildingsList.Add(house);
        }

        public void Add(ApothecaryOffice apothecaryOffice)
        {
            _apothecaryOfficeList.Add(apothecaryOffice);
            _buildingsList.Add(apothecaryOffice);
        }
        public void Add(Baths baths)
        {
            _bathsList.Add(baths);
            _buildingsList.Add(baths);
        }
        public void Add(Brothel brothel)
        {
            _brothelList.Add(brothel);
            _buildingsList.Add(brothel);
        }
        public void Add(Chapel chapel)
        {
            _chapelList.Add(chapel);
            _buildingsList.Add(chapel);
        }
        public void Add(Farm farm)
        {
            _farmList.Add(farm);
            _buildingsList.Add(farm);
        }
        public void Add(Forge forge)
        {
            _forgeList.Add(forge);
            _buildingsList.Add(forge);
        }
        public void Add(Mill mill)
        {
            _millList.Add(mill);
            _buildingsList.Add(mill);
        }
        public void Add(OfferingWarehouse offeringWarehouse)
        {
            _offeringWarehouseList.Add(offeringWarehouse);
            _buildingsList.Add(offeringWarehouse);
        }
        public void Add(PartyRoom partyRoom)
        {
            _partyRoomList.Add(partyRoom);
            _buildingsList.Add(partyRoom);
        }
        public void Add(Restaurant restaurant)
        {
            _restaurantList.Add(restaurant);
            _buildingsList.Add(restaurant);
        }
        public void Add(TablePlace tablePlace)
        {
            _tablePlaceList.Add(tablePlace);
            _buildingsList.Add(tablePlace);
        }
        public void Add(Tavern tavern)
        {
            _tavernList.Add(tavern);
            _buildingsList.Add(tavern);
        }
        public void Add(Theater theater)
        {
            _theaterList.Add(theater);
            _buildingsList.Add(theater);
        }
        public void Add(UnionOfCrafter unionOfCrafter)
        {
            _unionOfCrafterList.Add(unionOfCrafter);
            _buildingsList.Add(unionOfCrafter);
        }
        public void Remove(House house)
        {
            _houseList.Remove(house);
            _buildingsList.Remove(house);
        }

        public void Remove(Baths baths)
        {
            _bathsList.Remove(baths);
            _buildingsList.Remove(baths);
        }
        public void Remove(Brothel brothel)
        {
            _brothelList.Remove(brothel);
            _buildingsList.Remove(brothel);
        }
        public void Remove(Chapel chapel)
        {
            _chapelList.Remove(chapel);
            _buildingsList.Remove(chapel);
        }
        public void Remove(Farm farm)
        {
            _farmList.Remove(farm);
            _buildingsList.Remove(farm);
        }
        public void Remove(Forge forge)
        {
            _forgeList.Remove(forge);
            _buildingsList.Remove(forge);
        }
        public void Remove(Mill mill)
        {
            _millList.Remove(mill);
            _buildingsList.Remove(mill);
        }
        public void Remove(OfferingWarehouse offeringWarehouse)
        {
            _offeringWarehouseList.Remove(offeringWarehouse);
            _buildingsList.Remove(offeringWarehouse);
        }
        public void Remove(PartyRoom partyRoom)
        {
            _partyRoomList.Remove(partyRoom);
            _buildingsList.Remove(partyRoom);
        }
        public void Remove(Restaurant restaurant)
        {
            _restaurantList.Remove(restaurant);
            _buildingsList.Remove(restaurant);
        }
        public void Remove(TablePlace tablePlace)
        {
            _tablePlaceList.Remove(tablePlace);
            _buildingsList.Remove(tablePlace);
        }
        public void Remove(Tavern tavern)
        {
            _tavernList.Remove(tavern);
            _buildingsList.Remove(tavern);
        }
        public void Remove(Theater theater)
        {
            _theaterList.Remove(theater);
            _buildingsList.Remove(theater);
        }
        public void Remove(UnionOfCrafter unionOfCrafter)
        {
            _unionOfCrafterList.Remove(unionOfCrafter);
            _buildingsList.Remove(unionOfCrafter);
        }
        public void Remove(ApothecaryOffice apothecaryOffice)
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
