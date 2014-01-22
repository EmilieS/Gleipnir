using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class BuildingsList : IReadOnlyList<BuildingsModel>
    {
        readonly List<BuildingsModel> _buildingsList;
        readonly List<House> _houseList;
        readonly List<ApothecaryOffice> _apothecaryOfficeList;
        readonly List<Baths> _bathsList;
        readonly List<Brothel> _brothelList;
        readonly List<Chapel> _chapelList;
        readonly List<ClothesShop> _clothesShopList;
        readonly List<Farm> _farmList;
        readonly List<Forge> _forgeList;
        readonly List<MilitaryCamp> _militaryCampList;
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
        public IReadOnlyList<BuildingsModel> BrothelList { get { return _brothelList; } }
        public IReadOnlyList<BuildingsModel> ChapelList { get { return _chapelList; } }
        public IReadOnlyList<BuildingsModel> ClothesShopList { get { return _clothesShopList; } }
        public IReadOnlyList<BuildingsModel> FarmList { get { return _farmList; } }
        public IReadOnlyList<BuildingsModel> ForgeList { get { return _forgeList; } }
        public IReadOnlyList<BuildingsModel> MilitaryCampList { get { return _militaryCampList; } }
        public IReadOnlyList<BuildingsModel> MillList { get { return _millList; } }
        public IReadOnlyList<BuildingsModel> OfferingWarehouseList { get { return _offeringWarehouseList; } }
        public IReadOnlyList<BuildingsModel> PartyRoomList { get { return _partyRoomList; } }
        public IReadOnlyList<BuildingsModel> RestaurantList { get { return _restaurantList; } }
        public IReadOnlyList<BuildingsModel> TablePlaceList { get { return _tablePlaceList; } }
        public IReadOnlyList<BuildingsModel> TavernList { get { return _tavernList; } }
        public IReadOnlyList<BuildingsModel> TheaterList { get { return _theaterList; } }
        public IReadOnlyList<BuildingsModel> UnionOfCrafterList { get { return _unionOfCrafterList; } }

        Village _owner;

        public BuildingsList(Village village)
        {
            Game g = village.Game;
            _owner = village;
            _buildingsList = new List<BuildingsModel>();

            _houseList = new List<House>();
            _apothecaryOfficeList = new List<ApothecaryOffice>();
            _bathsList = new List<Buildings.Baths>();
            _brothelList = new List<Buildings.Brothel>();
            _chapelList = new List<Buildings.Chapel>();
            _clothesShopList = new List<Buildings.ClothesShop>();
            _farmList = new List<Buildings.Farm>();
            _forgeList = new List<Buildings.Forge>();
            _militaryCampList = new List<Buildings.MilitaryCamp>();
            _millList = new List<Buildings.Mill>();
            _offeringWarehouseList = new List<Buildings.OfferingWarehouse>();
            _partyRoomList = new List<Buildings.PartyRoom>();
            _restaurantList = new List<Buildings.Restaurant>();
            _tablePlaceList = new List<Buildings.TablePlace>();
            _tavernList = new List<Buildings.Tavern>();
            _theaterList = new List<Buildings.Theater>();
            _unionOfCrafterList = new List<Buildings.UnionOfCrafter>();
        }
        #region Add
        internal void Add(House house)
        {
            _houseList.Add(house);
            _buildingsList.Add(house);
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
        internal void Add(ClothesShop clothesShop)
        {
            _clothesShopList.Add(clothesShop);
            _buildingsList.Add(clothesShop);
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
        internal void Add(MilitaryCamp militaryCamp)
        {
            _militaryCampList.Add(militaryCamp);
            _buildingsList.Add(militaryCamp);
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
        #endregion
        #region Remove
        internal void Remove(House house)
        {
            _houseList.Remove(house);
            _buildingsList.Remove(house);
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
        internal void Remove(ClothesShop clothesShop)
        {
            _clothesShopList.Add(clothesShop);
            _buildingsList.Add(clothesShop);
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
        internal void Remove(MilitaryCamp militaryCamp)
        {
            _militaryCampList.Add(militaryCamp);
            _buildingsList.Add(militaryCamp);
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
        #endregion
        #region CreateBuilding
        //Creation coditions for PLAYER !
        //TODO : takeout the static prices.
        #region Conditions
        internal bool CommonCreationCondition()
        {
            if (_owner.JobsList.Construction_Worker.Workers.Count > 0)
                return true;
            return false;
        }
        public bool HouseCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 50)
                return true;
            return false;
        }
        public bool ApothecaryOfficeCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 200)
                return true;
            return false;
        }
        public bool BathsCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 5000)
                return true;
            return false;
        }
        public bool BrothelCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 700)
                return true;
            return false;
        }
        public bool ChapelCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 1000)
                return true;
            return false;
        }
        public bool ClothesShopCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 300)
                return true;
            return false;
        }
        public bool FarmCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 200)
                return true;
            return false;
        }
        public bool ForgeCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 100)
                return true;
            return false;
        }
        public bool MilitaryCampCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 800)
                return true;
            return false;
        }
        public bool MillCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 500)
                return true;
            return false;
        }
        public bool OfferingWarehouseCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 400)
                return true;
            return false;
        }
        public bool PartyRoomCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 2500)
                return true;
            return false;
        }
        public bool RestaurantCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 400)
                return true;
            return false;
        }
        public bool TavernCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 100)
                return true;
            return false;
        }
        public bool TheaterCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 6500)
                return true;
            return false;
        }
        public bool UnionOfCrafterCreationCondition()
        {
            if (CommonCreationCondition() && _owner.Game.Offerings >= 100)
                return true;
            return false;
        }

        #endregion
        public BuildingsModel CreateHouse ()//50
        {
            if (HouseCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-50);                
                var house= new House(_owner, true);
                _owner.AddEmptyHouse(house);//TODO: CHECK
                return house;
            }
            return null;                       
        }
        public BuildingsModel CreateApothecaryOffice ()//200
        {
            if (ApothecaryOfficeCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-200);
                return new ApothecaryOffice(_owner, _owner.JobsList.Apothecary);
            }
            return null;  
        }
        public BuildingsModel CreateBaths()//5000
        {
            if (BathsCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-5000);
                return new Baths(_owner);
            }
            return null; 
        }
        public BuildingsModel CreateBrothel()//700
        {
            if (BrothelCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-700);
                return new Brothel(_owner);
            }
            return null;  
        }
        public BuildingsModel CreateChapel ()//1000
        {
            if (ChapelCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-1000);
                return new Chapel(_owner);
            }
            return null;  
        }
        public BuildingsModel CreateClothesShop()//300
        {
            if (ClothesShopCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-300);
                return new ClothesShop(_owner, _owner.JobsList.Tailor);
            }
            return null;
        }
        public BuildingsModel CreateFarm()//200
        {
            if (FarmCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-200);
                return new Farm(_owner, _owner.JobsList.Farmer);
            }
            return null;
        }
        public BuildingsModel CreateForge()//100
        {
            if (ForgeCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-100);
                return new Forge(_owner, _owner.JobsList.Blacksmith);
            }
            return null;
        }
        public BuildingsModel CreateMilitaryCamp ()//800
        {
            if (MilitaryCampCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-800);
                return new MilitaryCamp(_owner, _owner.JobsList.Militia);
            }
            return null;
        }
        public BuildingsModel CreateMill ()//500
        {
            if (MillCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-500);
                return new Mill(_owner, _owner.JobsList.Miller);
            }
            return null;
        }
        public BuildingsModel CreateOfferingWarehouse ()//400
        {
            if (OfferingWarehouseCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-400);
                return new OfferingWarehouse(_owner);
            }
            return null;
        }
        public BuildingsModel CreatePartyRoom ()//2500
        {
            if (PartyRoomCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-2500);
                return new PartyRoom(_owner);
            }
            return null;
        }
        public BuildingsModel CreateRestaurant ()//400
        {
            if (RestaurantCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-400);
                return new Restaurant(_owner, _owner.JobsList.Cooker);
            }
            return null;
        }
        public BuildingsModel CreateTavern()//100
        {
            if (TavernCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-100);
                return new Tavern(_owner);
            }
            return null;
        }
        public BuildingsModel CreateTheater ()//6500
        {
            if (TheaterCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-6500);
                return new Theater(_owner);
            }
            return null;
        }
        public BuildingsModel CreateUnionOfCrafter ()//100
        {
            if (UnionOfCrafterCreationCondition())
            {
                _owner.Game.AddOrTakeFromOfferings(-100);
                return new UnionOfCrafter(_owner, _owner.JobsList.Construction_Worker);
            }
            return null;
        }
        #endregion
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
