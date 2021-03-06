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
using Game.GodSpell;
using System.Diagnostics;

namespace GamePages
{
    public partial class TabIndex : UserControl
    {
        List<VillagerBannerUC> ListOfVillagersToShow;
        readonly GeneralPage _page;
        bool isOnBought;
        bool passed;
        int positionX;
        int positionY;
        Random rnd;
        ToolTip GeneralTooltip;
        bool isRepairClick;

        public TabIndex(GeneralPage p)
        {
            InitializeComponent();

            _page = p;
            isOnBought = false;
            rnd = new Random();

            positionX = 0;
            positionY = 10;

            GeneralTooltip = new ToolTip();
            GeneralTooltip.ShowAlways = true;
            GeneralTooltip.InitialDelay = 100;
            GeneralTooltip.ReshowDelay = 100;

            // Create imageList
            ImageList imageList = new ImageList();
            imageList.Images.Add(GamePages.Properties.Resources.ActionTab_building_TabIcon);
            imageList.Images.Add(GamePages.Properties.Resources.ActionTab_happiness_TabIcon);
            imageList.Images.Add(GamePages.Properties.Resources.ActionTab_VillagerList_TabIcon);
            imageList.Images.Add(GamePages.Properties.Resources.ActionTab_action_TabIcon);

            // Add images to tabs
            actionsMenu.ImageList = imageList;
            for (int i = 0; i < 4; i++)
                actionsMenu.TabPages[i].ImageIndex = i;

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
            get { return isOnBought; }
            set { isOnBought = value; }
        }
        public bool IsRepairClick
        {
            get { return isRepairClick; }
            set { isRepairClick = value; }
        }

        // Buildings Click
        #region Jobs Buildings Buttons
        private void ApothicaryOffice_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.ApothecaryOfficeCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.APOTHECARY_OFFICE;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void Forge_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.ForgeCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.FORGE;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void UnionOfCrafter_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.UnionOfCrafterCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.UNION;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void Restaurant_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.RestaurantCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.RESTAURANT;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void Farm_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.FarmCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.FARM;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void Mill_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.MillCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.MILL;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void MilitaryCamp_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.MilitaryCampCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.MILITARY_CAMP;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void ClothesShop_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.ClothesShopCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.CLOTHES_SHOP;
                _page.OnBoughtBuilding_Click();
            }
        }
        #endregion
        #region Hobbies Buildings
        private void Baths_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.BathsCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.BATHS;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void Brothel_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.BrothelCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.BROTHEL;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void PartyRoom_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.PartyRoomCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.PARTY_ROOM;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void TavernButton_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.TavernCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.TAVERN;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void Theater_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.TheaterCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.THEATER;
                _page.OnBoughtBuilding_Click();
            }
        }
        #endregion
        #region Specials Buildings
        private void Chapel_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.ChapelCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.CHAPEL;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void OfferingsWarehouse_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.OfferingWarehouseCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.OFFERING_WAREHOUSE;
                _page.OnBoughtBuilding_Click();
            }
        }
        private void House_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].BuildingsList.HouseCreationCondition())
            {
                _page.BuildingSelected = BuildingTypes.HOUSE;
                _page.OnBoughtBuilding_Click();
            }
        }
        #endregion

        // Upgrades Click
        #region Cooker's Upgrades
        private void Level1_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Level1.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Level1.IsActivated)
            {
                Level1_butt.Enabled = false;
                _page.PushText("Votre niveau de restauration a augmenté", "Level1 acheté");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Level1.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else if (_page.TheGame.Villages[0].BuildingsList.RestaurantList.Count == 0)
            {
                _page.PushAlert("Vous devez avoir déja au moins un restaurant !", "Pas de restaurant, pas d'argent");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amelioration", "Echec d'achat !");
            }
        }

        private void Level2_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Level2.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Level2.IsActivated)
            {
                Level2_butt.Enabled = false;
                _page.PushText("Votre niveau de restauration a augmenté", "Level2 acheté");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Level2.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }

        private void Level3_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Level3.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Level3.IsActivated)
            {
                Level3_butt.Enabled = false;
                _page.PushText("Votre niveau de restauration a augmenté", "Level3 acheté");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Level3.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }

        private void Level4_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Level4.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Level4.IsActivated)
            {
                Level4_butt.Enabled = false;
                _page.PushText("Votre niveau de restauration a augmenté", "Level4 acheté");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Level4.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        #endregion
        #region Crafter's Upgrades
        private void Pulley_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Pulley.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Pulley.IsActivated)
            {
                Pulley_butt.Enabled = false;
                _page.PushText("Vos ouvriers sont plus efficaces", "Poulie achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Pulley.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }

        private void Hoist_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Hoist.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Hoist.IsActivated)
            {
                Hoist_butt.Enabled = false;
                _page.PushText("Vos ouvriers sont plus efficaces", "Grue achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Hoist.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else if (!_page.TheGame.Villages[0].Upgrades.Pulley.IsActivated)
            {
                _page.PushAlert("Achetez d'abord un poulie !", "Amélioration manquante");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }

        private void Scaffholding_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Scaffolding.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Scaffolding.IsActivated)
            {
                Scaffolding_butt.Enabled = false;
                _page.PushText("Vos ouvriers sont plus efficaces", "Grue achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Scaffolding.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else if (!_page.TheGame.Villages[0].Upgrades.Pulley.IsActivated && !_page.TheGame.Villages[0].Upgrades.Pulley.IsActivated)
            {
                _page.PushAlert("Vous devez d'abord avoir une poulie et une grue !", "Amélioration manquante");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        #endregion
        #region Blacksmith's Upgrades
        private void Saw_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Saw.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Saw.IsActivated)
            {
                Saw_butt.Enabled = false;
                _page.PushText("Les forgeron sont plus compétents", "La scie est achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Saw.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        private void Furnace_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Furnace.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Furnace.IsActivated)
            {
                Furnace_butt.Enabled = false;
                _page.PushText("Les forgeron sont plus compétents", "Le four est achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Furnace.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        private void Plow_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Plow.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Plow.IsActivated)
            {
                Plow_butt.Enabled = false;
                _page.PushText("Les forgeron sont plus compétents", "La charrue est achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Plow.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        #endregion
        #region Farmer's Upgrades
        private void Scarecrow_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Scarecrow.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Scarecrow.IsActivated)
            {
                Scarecrow_butt.Enabled = false;
                _page.PushText("La production de la ferme augmente", "L'épouvantail est achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Scarecrow.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        private void Fertilizer_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Fertilizer.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Fertilizer.IsActivated)
            {
                Fertilizer_butt.Enabled = false;
                _page.PushText("La production de la ferme augmente", "Le fertilisant est achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Fertilizer.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        private void Irrigation_butt_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].Upgrades.Irrigation.Buy();
            if (_page.TheGame.Villages[0].Upgrades.Irrigation.IsActivated)
            {
                Irrigation_butt.Enabled = false;
                _page.PushText("La production de la ferme augmente", "L'irrigation est achetée");
            }
            else if (_page.TheGame.Villages[0].Upgrades.Irrigation.CostPrice > _page.TheGame.Offerings)
            {
                _page.PushAlert("Vous n'avez pas assez d'argent pour acheter", "Pas assez d'argent ! ");
            }
            else
            {
                _page.PushAlert("Vous n'avez pas put acheter l'amélioration", "Echec d'achat !");
            }
        }
        #endregion

        // God Spells Click
        private void StartEpidemic_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].FamiliesList.Count > 0)
            {
                int familyChoosen = rnd.Next(0, _page.TheGame.Villages[0].FamiliesList.Count);
                int villagerChoosen = rnd.Next(0, _page.TheGame.Villages[0].FamiliesList[familyChoosen].FamilyMembers.Count);
                Epidemic epidemic = new Epidemic(_page.TheGame, _page.TheGame.Villages[0].FamiliesList[familyChoosen].FamilyMembers[villagerChoosen]);
            }
        }
        private void StartEarthquake_Click(object sender, EventArgs e)
        {
            Earthquake earthquake = new Earthquake(_page.TheGame, _page.TheGame.Villages[0]);
        }
        private void StartHeal_Click(object sender, EventArgs e)
        {
            Heal heal = new Heal(_page.TheGame);
        }
        private void StartFest_Click(object sender, EventArgs e)
        {
            _page.TheGame.Villages[0].FestStart();
        }
        private void StartRepair_Click(object sender, EventArgs e)
        {
            if (!isRepairClick)
            {
                if (_page.TheGame.Villages[0].JobsList.Construction_Worker.Workers.Count > 0)
                {
                    _page.ActionStatement = GamePages.GeneralPage.ActionState.SelectRepair;
                    _page.ShowBuildingsCanBeRepaired();
                    isRepairClick = true;
                }
            }
            else
            {
                _page.HideBuildingsCanBeRepaired();
                isRepairClick = false;
            }
        }

        // Villagers list
        internal void ShowVillagerListInFamily(Family fam)
        {
            if (!passed)
            {
                ListOfVillagersToShow = new List<VillagerBannerUC>();
                passed = true;
            }
            DestroyVillagerList();

            for (int i = 0; i < fam.FamilyMembers.Count; i++)
            {
                VillagerBannerUC tmp = new VillagerBannerUC(fam.FamilyMembers[i]);

                // Set VillagerBannerUC
                tmp.Location = new System.Drawing.Point(positionX, positionY);

                // Add VillagerBannerUC to lists and show it
                this.VillagerList.Controls.Add(tmp);
                ListOfVillagersToShow.Add(tmp);
                tmp.Show();

                // Set position for next VillagerBannerUC
                positionY += 62;
            }
        }
        internal void ShowConvocatedVillagers(Family fam)
        {
            if (!passed)
            {
                ListOfVillagersToShow = new List<VillagerBannerUC>();
                passed = true;
            }
            DestroyVillagerList();

            for (int i = 0; i < fam.FamilyMembers.Count; i++)
            {
                VillagerBannerUC tmp = new VillagerBannerUC(fam.FamilyMembers[i]);

                // Set VillagerBannerUC
                tmp.Location = new System.Drawing.Point(positionX, positionY);

                // Add VillagerBannerUC to lists and show it
                this.VillagerList.Controls.Add(tmp);
                ListOfVillagersToShow.Add(tmp);
                tmp.Show();

                // Set position for next VillagerBannerUC
                positionY += 62;
            }
        }
        internal void ShowWorkersInJob(JobsModel job)
        {
            if (passed == false)
            {
                passed = true;
                ListOfVillagersToShow = new List<VillagerBannerUC>();
            }
            DestroyVillagerList();

            for (int i = 0; i < job.Workers.Count; i++)
            {
                VillagerBannerUC tmp = new VillagerBannerUC(job.Workers[i]);

                // Set VillagerBannerUC
                tmp.Location = new System.Drawing.Point(positionX, positionY);

                // Add VillagerBannerUC to lists and show it
                this.VillagerList.Controls.Add(tmp);
                ListOfVillagersToShow.Add(tmp);
                tmp.Show();

                // Set position for next VillagerBannerUC
                positionY += 62;
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

        // Tooltip
        #region Tooltips' implementation
        private void UnionOfCrafter_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(UnionOfCrafter, "Syndicat");
        }

        private void Forge_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Forge, "Forge");
        }

        private void Farm_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Farm, "Ferme");
        }

        private void ApothecaryOffice_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(ApothecaryOffice, "Cabinet d'apothicaire");
        }

        private void Restaurant_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Restaurant, "Restaurant");
        }

        private void ClothesShop_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(ClothesShop, "Tailleur");
        }

        private void Mill_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Mill, "Moulin");
        }

        private void Baths_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Baths, "Bains");
        }

        private void Brothel_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Brothel, "Maison close");
        }

        private void Tavern_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Tavern, "Taverne");
        }

        private void Theater_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Theater, "Théatre");
        }

        private void PartyRoom_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(PartyRoom, "Salle des fêtes");
        }

        private void OfferingsWarehouse_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(OfferingsWarehouse, "Sanctuaire");
        }

        private void Chapel_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Chapel, "Chapelle");
        }

        private void Level1_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Level1_butt, "Niveau 2 Cuisine");
        }

        private void Level2_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Level2_butt, "Niveau 3 Cuisine");
        }

        private void Level3_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Level3_butt, "Niveau 4 Cuisine");
        }

        private void Level4_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Level4_butt, "Niveau 5 Cuisine");
        }

        private void Pulley_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Pulley_butt, "Poulie");
        }

        private void Hoist_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Hoist_butt, "Grue");
        }

        private void Scaffolding_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Scaffolding_butt, "Echaffaudage");
        }

        private void Saw_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Saw_butt, "Scie");
        }

        private void Scarecrow_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Scarecrow_butt, "Epouvantail");
        }

        private void Fertilizer_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Fertilizer_butt, "Fertilisant");
        }

        private void Irrigation_butt_MouseHover(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(Irrigation_butt, "Système d'irrigation");
        }

        #endregion
    }
}
