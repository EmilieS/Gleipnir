using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class UpgradesList : IReadOnlyList<UpgradesModel>
    {
        Village _owner;

        //Apothecaries' Upgrades
        //readonly Drugs _drugs;
        //readonly Surgery _surgery;
        ////Blacksmithes' Upgrades
        //readonly Furnace _furnace;
        //readonly Plow _plow;
        //readonly Saw _saw;
        //Cookers' Upgrades
        readonly Level1 _level1;
        readonly Level2 _level2;
        readonly Level3 _level3;
        readonly Level4 _level4;
        ////Crafters' Upgrades
        readonly Pulley _pulley;
        readonly Hoist _hoist;
        //readonly Scaffolding _scaffolding;
        //readonly Whitewash _whitewash;
        //readonly Cement _cement;
        //readonly Reinforced _reinforced;
        ////Farmers' Upgrades
        //readonly Fertilizer _fertilizer;
        //readonly Fields_expansion _fields_expansion;
        //readonly Irrigation _irrigation;
        //readonly Scarecrow _scarecrow;

        public UpgradesModel Level1 { get { return _level1; } }
        public UpgradesModel Level2 { get { return _level2; } }
        public UpgradesModel Level3 { get { return _level3; } }
        public UpgradesModel Level4 { get { return _level4; } }
        //public UpgradesModel Furnace { get { return Furnace; } }
        public UpgradesModel Hoist { get { return _hoist; } }
        //public UpgradesModel Plow { get { return _plow; } }
        //public UpgradesModel Saw { get { return _saw; } }
        //public UpgradesModel Surgery { get { return _surgery; } }
        //public UpgradesModel Drugs { get { return _drugs; } }
        public UpgradesModel Pulley { get { return _pulley; } }
        //public UpgradesModel Scaffolding { get { return _scaffolding; } }
        //public UpgradesModel Whitewash { get { return _whitewash; } }
        //public UpgradesModel Cement { get { return _cement; } }
        //public UpgradesModel Reinforced { get { return _reinforced; } }
        //public UpgradesModel Fertilizer { get { return _fertilizer; } }
        //public UpgradesModel Fields_expansion { get { return _fields_expansion; } }
        //public UpgradesModel Irrigation { get { return _irrigation; } }
        //public UpgradesModel Scarecrow { get { return _scarecrow; } }

        readonly List<UpgradesModel> _upgradesList;

        internal Village Owner { get { return _owner; } }

        public UpgradesList(Village village)
        {
            Game game = village.Game;
            _upgradesList = new List<UpgradesModel>();
            _owner = village;
            //_cement = new Cement(game);
            //_drugs = new Drugs(game);
            //_fertilizer = new Fertilizer(game);
            //_fields_expansion = new Fields_expansion(game);
            //_furnace = new Furnace(game);
            _hoist = new Hoist(game, village, this, Owner.JobsList);
            //_irrigation = new Irrigation(game);
            _level1 = new Level1(game, village, this, Owner.JobsList);
            _level2 = new Level2(game, village, this, Owner.JobsList);
            _level3 = new Level3(game, village, this, Owner.JobsList);
            _level4 = new Level4(game, village, this, Owner.JobsList);
            //_plow = new Plow(game);
            _pulley = new Pulley(game, village, this, Owner.JobsList);
            //_reinforced = new Reinforced(game);
            //_saw = new Saw(game);
            //_scaffolding = new Scaffolding(game);
            //_scarecrow = new Scarecrow(game);
            //_surgery = new Surgery(game);
            //_whitewash = new Whitewash(game);
            //_upgradesList.Add(_cement);
            //_upgradesList.Add(_drugs);
            //_upgradesList.Add(_fertilizer);
            //_upgradesList.Add(_fields_expansion);
            //_upgradesList.Add(_furnace);
            _upgradesList.Add(_hoist);
            //_upgradesList.Add(_irrigation);
            _upgradesList.Add(_level1);
            _upgradesList.Add(_level2);
            _upgradesList.Add(_level3);
            _upgradesList.Add(_level4);
            //_upgradesList.Add(_plow);
            _upgradesList.Add(_pulley);
            //_upgradesList.Add(_reinforced);
            //_upgradesList.Add(_saw);
            //_upgradesList.Add(_scaffolding);
            //_upgradesList.Add(_scarecrow);
            //_upgradesList.Add(_surgery);
            //_upgradesList.Add(_whitewash);
            _owner = village;
        }
        public UpgradesModel this[int index]
        {
            get { return _upgradesList[index]; }
        }
        public int Count
        {
            get { return _upgradesList.Count; }
        }
        public IEnumerator<UpgradesModel> GetEnumerator()
        {
            return _upgradesList.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        internal void Destroy()
        {
            foreach (UpgradesModel upgrades in _upgradesList)
            {
                upgrades.Destroy();
            }
            _owner = null;
        }
    }
}
