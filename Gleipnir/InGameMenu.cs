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
    public partial class InGameMenu : UserControl
    {
        public event PropertyChangedEventHandler ExpectGoBackToMenu;
        bool _goBack;
        public InGameMenu()
        {
            _goBack = false;
            InitializeComponent();
        }

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

        public bool GoBackExpected
        {
            get { return _goBack; }
            set { _goBack = value; }
        }
    }
}
