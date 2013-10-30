﻿using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePages
{
    public partial class GamePage : Form
    {
        Game.Game _startedGame;

        public GamePage(Game.Game newGame)
        {
            InitializeComponent();
            _startedGame = newGame;
        }
    }
}
