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
        Game.Game _startedGame;
        public bool _isStarted;
        public event PropertyChangedEventHandler Launched;
        public HomepageUC()
        {
            InitializeComponent();
            _startedGame = new Game.Game();
            _isStarted = false;
        }

        public  void new_game(object sender, EventArgs e)
        {
            this.Visible = false;
            IsStarted = true;
            RaisePropertyChanged();
        }
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = Launched;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
