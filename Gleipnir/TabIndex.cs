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

namespace GamePages
{
    public partial class TabIndex : UserControl
    {
        readonly GeneralPage _page;
        bool _isOnBought;
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
            ApothicaryOffice.Click += ApothicaryOffice_Click;
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
            _page.OnBoughtBuilding_Click(0);
        }
        private void Forge_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(1);
        }
        private void UnionOfCrafter_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(2);
        }
        private void Restaurant_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(3);
        }
        private void Farm_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(4);
        }
        private void Mill_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(5);
        }
        private void MilitaryCamp_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(6);
        }
        private void ClothesShop_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(7);
        }
        #endregion
        #region Hobbies Buildings
        private void Baths_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(8);
        }
        private void Brothel_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(9);
        }
        private void PartyRoom_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(10);
        }
        private void TavernButton_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(11);
        }
        private void Theater_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(12);
        }
        #endregion
        #region Specials Buildings
        private void Chapel_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(13);
        }
        private void OfferingsWarehouse_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(14);
        }        
        private void House_Click(object sender, EventArgs e)
        {
            _page.OnBoughtBuilding_Click(15);
        }
        #endregion

        private void StartEpidemic_Click(object sender, EventArgs e)
        {
            Game.GodSpell.Epidemic epidemic = new Game.GodSpell.Epidemic(_page.StartedGame, _page.StartedGame.Villages[0].FamiliesList[0].FamilyMembers[0]);
        }

        bool _passed;
        internal void ShowVillagerListInFamily(Family fam)
        {
            if (_passed == false)
            {
                _passed = true;
                ListOfVillagersToShow = new List<VillagerBannerUC>();
            }
            DestroyVillagerListInFamily();

            for (int i = 0; i < fam.FamilyMembers.Count; i++)
            {
                VillagerBannerUC tmp = new VillagerBannerUC();
                ListOfVillagersToShow.Add(tmp);
                tmp.VillagerName.Text = fam.FamilyMembers[i].Name;
                this.VillagerList.Controls.Add(tmp);
                tmp.Show();
                tmp.Location = new System.Drawing.Point(positionX, positionY);
                positionY += 65;
            }
        }

        internal void DestroyVillagerListInFamily()
        {
            for (int i = 0; i < ListOfVillagersToShow.Count; i++)
            {
                ListOfVillagersToShow[i].Hide();
                this.VillagerList.Controls.Remove(ListOfVillagersToShow[i]);
            }
            positionX = positionY = 0;
            ListOfVillagersToShow.Clear();
        }

        #region Cooker's Upgrades
        private void Level1_butt_Click(object sender, EventArgs e)
        {
            _page.StartedGame.Villages[0].Upgrades.Level1.Buy();
            Level1_butt.Visible = false;
            Controls.Remove(Level1_butt);
        }

        #endregion

    }
}
