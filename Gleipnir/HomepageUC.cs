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

namespace GamePages
{
    public partial class HomepageUC : UserControl  
    {
        public bool _isStarted;
        public bool _isLoaded;
        public event PropertyChangedEventHandler Launched;
        GeneralPage _page;

        public HomepageUC(GeneralPage page)
        {
            _page = page;
            InitializeComponent();
            _isStarted = false;
            _isLoaded = false;
        }

        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; }
        }
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; }
        }

        public void new_game(object sender, EventArgs e)
        {
            this.Visible = false;
            _isStarted = true;
            RaisePropertyChanged();
        }
        private void loadGame_Click(object sender, EventArgs e)
        {
            if (Game.serialize.load() != null)
            {
                this.Visible = false;
                _isLoaded = true;
                _isStarted = false;
                _page.LoadGame();
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = Launched;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
