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
        GeneralPage _page;

        public InGameMenu(GeneralPage page)
        {
            _goBack = false;
            _page = page;
            InitializeComponent();
        }

        // Back to main menu
        public void GoBack_Click(object sender, EventArgs e)
        {
            GoBackExpected = true;
            RaisePropertyChanged();
            _page.GameStarted = false;
        }
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = ExpectGoBackToMenu;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        // Back to game
        public void InGameQuit_Click(object sender, EventArgs e)
        {
            _page.OnClickMenu();
        }

        // Save Game
        private void Save_Click(object sender, EventArgs e)
        {
             Game.serialize.save(_page.TheGame);
        }

        // Settings
        private void InGameSettings_Click(object sender, EventArgs e)
        {
            if (!_page.ParametersBox.IsOpen)
            {
                _page.ParametersBox.BringToFront();
                _page.ParametersBox.Show();
                _page.ParametersBox.IsOpen = true;
            }
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
