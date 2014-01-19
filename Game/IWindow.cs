using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IWindow
    {
        // TraceWindow / EventList Update
        void PushTrace(string message);
        void PushAlert(string message, string title);

        // Stats Update
        void PushPopulation(int pop);
        void PushGeneralGold(int value);
        void PushGeneralCoins(int value);
        void PushGeneralFaith(double value);
        void PushGeneralHappiness(double value);
        void PushOfferingsPointsPerTick(int value);
        void PushName(string name);
        void GameLost();

        // Grid Update
        void SetEmptySquare(int row, int col);
        void AddNewFamilyHouse(Buildings.House house);
    }
}
