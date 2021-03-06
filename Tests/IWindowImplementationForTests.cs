﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Tests
{
    public class IWindowImplementationForTests : IWindow
    {
        public IWindowImplementationForTests() { }

        public void PushTrace(string message)
        {
            nb_pushTrace++;
        }
        public void PushAlert(string message, string title)
        {
            nb_pushAlert++;
        }
        public void PushGeneralCoins(int value) { }
        public void PushGeneralGold(int value) { goldtouched++; }
        public void PushGeneralHappiness(double value) { }
        public void PushGeneralFaith(double value) { }
        public void PushOfferingsPointsPerTick(int value) { }
        public void PushName(string name) { }
        public int nb_pushTrace;
        public int nb_pushAlert;
        public int offeringstouched;
        public int populationtouched;
        public int goldtouched;
        public void PushPopulation(int pop) { populationtouched++; }
        public void SetEmptySquare(int row, int col) { }
        public void AddNewFamilyHouse(Game.Buildings.House house) { }
        public void GameLost() { }
    }
}
