using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Game;

namespace GamePages
{
    public partial class InGameMenu : UserControl
    {
        public event PropertyChangedEventHandler ExpectGoBackToMenu;
        bool _goBack;
        bool _isMenuOpen;

        public InGameMenu()
        {
            _goBack = false;
            InitializeComponent();
        }

        // Back to main menu event
        public void GoBack_Click(object sender, EventArgs e)
        {
            GoBackExpected = true;
            RaisePropertyChanged();
        }
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = ExpectGoBackToMenu;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets or Sets if the player go back in main menu
        /// </summary>
        public bool GoBackExpected
        {
            get { return _goBack; }
            set { _goBack = value; }
        }

        /// <summary>
        /// Gets or Sets if the InGameMenu is open
        /// </summary>
        public bool IsOpen
        {
            get { return _isMenuOpen; }
            set { _isMenuOpen = value; }
        }
    }
}
