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
        int positionX;
        int positionY;
        List<VillagerBannerUC> ListOfVillagersToShow;

        public TabIndex()
        {
            InitializeComponent();
            positionX = 0;
            positionY = 0;
        }
        internal void ShowUnboughtBuildings()
        {

        }

        private void Tavern_Click(object sender, EventArgs e)
        {
            //TODO: check list if unique. 
            //TODO : check if player can pay
            //TODO : any other conditions?
            //TODO : memorise the chosen building choice
            //TODO : display differently and make clikable the possible squares

            //THEN, once the played cliked on the map in a possible square
            //TODO : pay
            //TODO : create building whith correct location.

            //ELSE he cliked elsewhere
            //CANCEL <= delete the memorised building choice
        }

        private void ApothicaryOffice_Click(object sender, EventArgs e)
        {

        }

        private void Chapel_Click(object sender, EventArgs e)
        {

        }

        private void PartyRoom_Click(object sender, EventArgs e)
        {

        }

        private void Baths_Click(object sender, EventArgs e)
        {

        }

        private void Brothel_Click(object sender, EventArgs e)
        {

        }

        private void Theater_Click(object sender, EventArgs e)
        {

        }

        private void Restaurant_Click(object sender, EventArgs e)
        {

        }
        bool _passed;
        internal void ShowVillagerListInFamily(Family fam)
        {
            if (_passed != true)
            { 
               _passed = true;
                ListOfVillagersToShow = new List<VillagerBannerUC>();
            }
            DestroyVillagerListInFamily();

            for (int i = 0; i < fam.FamilyMembers.Count; i++)
            {
                
            //    int i = 0;
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
    }
}
