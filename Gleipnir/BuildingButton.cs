using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePages
{//SHOULD WE USE THIS?
    public partial class BuildingButton : UserControl
    {
        public BuildingButton()
        {
            InitializeComponent();
        }

        private void BuildingButton_Click(object sender, EventArgs e)
        {
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
    }
}
