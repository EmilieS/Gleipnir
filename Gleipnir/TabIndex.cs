﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;
using Game.Buildings;

namespace GamePages
{
    public partial class TabIndex : UserControl
    {
        readonly GeneralPage _page;
        bool _isOnBought;
        bool _passed;
        bool _isEpidemicLaunched;
        List<VillagerBannerUC> ListOfVillagersToShow;
        int positionX;
        int positionY;

        public TabIndex(GeneralPage p)
        {
            _page = p;
            _isOnBought = false;
            InitializeComponent();
            positionX = 0;
            positionY = 0;

            #region Jobs
            ApothecaryOffice.Click += ApothicaryOffice_Click;
            Forge.Click += Forge_Click;
            UnionOfCrafter.Click += UnionOfCrafter_Click;
            Restaurant.Click += Restaurant_Click;
            Farm.Click += Farm_Click;
            Mill.Click += Mill_Click;
            ClothesShop.Click += ClothesShop_Click;
            #endregion
            #region Hobbies
            Baths.Click += Baths_Click;
            Brothel.Click += Brothel_Click;
            Chapel.Click += Chapel_Click;
            PartyRoom.Click += PartyRoom_Click;
            Tavern.Click += TavernButton_Click;
            Theater.Click += Theater_Click;
            #endregion
            #region Specials
            OfferingsWarehouse.Click += OfferingsWarehouse_Click;
            House.Click += House_Click;
            #endregion
        }

        public bool IsOnBought
        {
            get { return _isOnBought; }
            set { _isOnBought = value; }
        }

        internal void ShowUnboughtBuildings()
        {
        }

        #region Jobs Buildings Buttons
        private void ApothicaryOffice_Click(object sender, EventArgs e)
        {
            ApothecaryOffice apo = new ApothecaryOffice(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Apothecary);
            _page.OnBoughtBuilding_Click(apo);
        }
        private void Forge_Click(object sender, EventArgs e)
        {
            Game.Buildings.Forge forge = new Forge(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Blacksmith);
            _page.OnBoughtBuilding_Click(forge);
        }
        private void UnionOfCrafter_Click(object sender, EventArgs e)
        {
            Game.Buildings.UnionOfCrafter uoc = new UnionOfCrafter(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Construction_Worker);
            _page.OnBoughtBuilding_Click(uoc);
        }
        private void Restaurant_Click(object sender, EventArgs e)
        {
            Game.Buildings.Restaurant resto = new Restaurant(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Cooker);
            _page.OnBoughtBuilding_Click(resto);
        }
        private void Farm_Click(object sender, EventArgs e)
        {
            Game.Buildings.Farm farm = new Farm(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Farmer);
            _page.OnBoughtBuilding_Click(farm);
        }
        private void Mill_Click(object sender, EventArgs e)
        {
            Game.Buildings.Mill mill = new Mill(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Miller);
            _page.OnBoughtBuilding_Click(mill);
        }
        private void MilitaryCamp_Click(object sender, EventArgs e)
        {
            Game.Buildings.MilitaryCamp gq = new MilitaryCamp(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Militia);
            _page.OnBoughtBuilding_Click(gq);
        }
        private void ClothesShop_Click(object sender, EventArgs e)
        {
            Game.Buildings.ClothesShop shop = new ClothesShop(_page.Game.Villages[0], _page.Game.Villages[0].Jobs.Tailor);
            _page.OnBoughtBuilding_Click(shop);
        }
        #endregion
        #region Hobbies Buildings
        private void Baths_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(8);
        }
        private void Brothel_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(9);
        }
        private void PartyRoom_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(10);
        }
        private void TavernButton_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(11);
        }
        private void Theater_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(12);
        }
        #endregion
        #region Specials Buildings
        private void Chapel_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(13);
        }
        private void OfferingsWarehouse_Click(object sender, EventArgs e)
        {
            //_page.OnBoughtBuilding_Click(14);
        }
        private void House_Click(object sender, EventArgs e)
        {
            Game.Buildings.House house = new Game.Buildings.House(_page.Game.Villages[0]);
            _page.OnBoughtBuilding_Click(house);
        }
        #endregion

        private void StartEpidemic_Click(object sender, EventArgs e)
        {
            if (!_isEpidemicLaunched)
            {
                Game.GodSpell.Epidemic epidemic = new Game.GodSpell.Epidemic(_page.Game, _page.Game.Villages[0].FamiliesList[0].FamilyMembers[0]);
                _isEpidemicLaunched = true;
            }
        }
        
        internal void ShowVillagerListInFamily(Family fam)
        {
            if (_passed == false)
            {
                _passed = true;
                ListOfVillagersToShow = new List<VillagerBannerUC>();
            }
            DestroyVillagerList();

            for (int i = 0; i < fam.FamilyMembers.Count; i++)
            {
                VillagerBannerUC tmp = new VillagerBannerUC();
                ListOfVillagersToShow.Add(tmp);
                tmp.VillagerName.Text = fam.FamilyMembers[i].FirstName + " " + fam.FamilyMembers[i].Name;
                this.VillagerList.Controls.Add(tmp);
                tmp.Show();
                tmp.Location = new System.Drawing.Point(positionX, positionY);
                positionY += 65;
            }
        }
        internal void ShowWorkersInJob(JobsModel job)
        {
            if (_passed == false)
            {
                _passed = true;
                ListOfVillagersToShow = new List<VillagerBannerUC>();
            }
            DestroyVillagerList();

            for (int i = 0; i < job.Workers.Count; i++)
            {
                VillagerBannerUC tmp = new VillagerBannerUC();
                ListOfVillagersToShow.Add(tmp);
                tmp.VillagerName.Text = job.Workers[i].FirstName + " " + job.Workers[i].Name;
                this.VillagerList.Controls.Add(tmp);
                tmp.Show();
                tmp.Location = new System.Drawing.Point(positionX, positionY);
                positionY += 65;
            }
        }
        internal void DestroyVillagerList()
        {
            if (ListOfVillagersToShow != null)
            {
                for (int i = 0; i < ListOfVillagersToShow.Count; i++)
                {
                    ListOfVillagersToShow[i].Hide();
                    this.VillagerList.Controls.Remove(ListOfVillagersToShow[i]);
                }
                positionX = positionY = 0;
                ListOfVillagersToShow.Clear();
            }
        }
    }
}
