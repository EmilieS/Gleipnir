using System;
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

        public TabIndex(GeneralPage p)
        {
            InitializeComponent();

            _page = p;
            isOnBought = false;

            positionX = 0;
            positionY = 10;
            
            // Create imageList
            ImageList imageList = new ImageList();
            imageList.Images.Add(GamePages.Properties.Resources.Building_House);
            
            // Add images to tabs
            actionsMenu.ImageList = imageList;
            actionsMenu.TabPages[0].ImageIndex = 0;

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

        // Buildings Click
        #region Jobs Buildings Buttons
        private void ApothicaryOffice_Click(object sender, EventArgs e)
        {
            ApothecaryOffice apo = new ApothecaryOffice(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Apothecary);
            _page.OnBoughtBuilding_Click(apo);
        }
        private void Forge_Click(object sender, EventArgs e)
        {
            Game.Buildings.Forge forge = new Forge(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Blacksmith);
            _page.OnBoughtBuilding_Click(forge);
        }
        private void UnionOfCrafter_Click(object sender, EventArgs e)
        {
            Game.Buildings.UnionOfCrafter uoc = new UnionOfCrafter(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Construction_Worker);
            _page.OnBoughtBuilding_Click(uoc);
        }
        private void Restaurant_Click(object sender, EventArgs e)
        {
            Game.Buildings.Restaurant resto = new Restaurant(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Cooker);
            _page.OnBoughtBuilding_Click(resto);
        }
        private void Farm_Click(object sender, EventArgs e)
        {
            Game.Buildings.Farm farm = new Farm(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Farmer);
            _page.OnBoughtBuilding_Click(farm);
        }
        private void Mill_Click(object sender, EventArgs e)
        {
            Game.Buildings.Mill mill = new Mill(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Miller);
            _page.OnBoughtBuilding_Click(mill);
        }
        private void MilitaryCamp_Click(object sender, EventArgs e)
        {
            Game.Buildings.MilitaryCamp gq = new MilitaryCamp(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Militia);
            _page.OnBoughtBuilding_Click(gq);
        }
        private void ClothesShop_Click(object sender, EventArgs e)
        {
            Game.Buildings.ClothesShop shop = new ClothesShop(_page.TheGame.Villages[0], _page.TheGame.Villages[0].JobsList.Tailor);
            _page.OnBoughtBuilding_Click(shop);
        }
        #endregion
        #region Hobbies Buildings
        private void Baths_Click(object sender, EventArgs e)
        {
            Baths baths = new Baths(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(baths);
        }
        private void Brothel_Click(object sender, EventArgs e)
        {
            Brothel brothel = new Brothel(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(brothel);
        }
        private void PartyRoom_Click(object sender, EventArgs e)
        {
            PartyRoom party = new PartyRoom(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(party);
        }
        private void TavernButton_Click(object sender, EventArgs e)
        {
            Tavern tavern = new Tavern(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(tavern);
        }
        private void Theater_Click(object sender, EventArgs e)
        {
            Theater theater = new Theater(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(theater);
        }
        #endregion
        #region Specials Buildings
        private void Chapel_Click(object sender, EventArgs e)
        {
            Chapel chapel = new Chapel(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(chapel);
        }
        private void OfferingsWarehouse_Click(object sender, EventArgs e)
        {
            OfferingWarehouse offeringsWarehouse = new OfferingWarehouse(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(offeringsWarehouse);
        }
        private void House_Click(object sender, EventArgs e)
        {
            House house = new House(_page.TheGame.Villages[0]);
            _page.OnBoughtBuilding_Click(house);
        }
        #endregion

        // God Spells Click
        private void StartEpidemic_Click(object sender, EventArgs e)
        {
            if(_page.TheGame.Villages[0].FamiliesList.Count > 0)
            {
                Random rnd = new Random();
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
            SamhainFest fest = new SamhainFest();
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
                VillagerBannerUC tmp = new VillagerBannerUC();
                
                // Add gender icon
                if(fam.FamilyMembers[i].Gender == Genders.FEMALE)
                    tmp.VillagerFace.BackgroundImage = GamePages.Properties.Resources.Gender_Female;
                else
                    tmp.VillagerFace.BackgroundImage = GamePages.Properties.Resources.Gender_Male;

                // Set VillagerBannerUC
                tmp.VillagerName.Text = fam.FamilyMembers[i].FirstName + " " + fam.FamilyMembers[i].Name;
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
                VillagerBannerUC tmp = new VillagerBannerUC();
                ListOfVillagersToShow.Add(tmp);
                if (job.Workers[i].Gender == Genders.FEMALE)
                    tmp.VillagerFace.BackgroundImage = GamePages.Properties.Resources.Gender_Female;
                else
                    tmp.VillagerFace.BackgroundImage = GamePages.Properties.Resources.Gender_Male;
                tmp.VillagerName.Text = job.Workers[i].FirstName + " " + job.Workers[i].Name;
                this.VillagerList.Controls.Add(tmp);
                tmp.Show();
                tmp.Location = new System.Drawing.Point(positionX, positionY);
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
    }
}
