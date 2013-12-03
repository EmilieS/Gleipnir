using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    public class ScenarioEngine
    {
        int i = 0;

        string[] scenarioContent = File.ReadAllLines(@"D:\INTECH\PI-2013S\Gleipnir\Game\Extra\scenario.txt", Encoding.UTF8);
        public ScenarioEngine()
        {
            //ReadScenario();
        }

        public string ReadScenario()
        {
            string toPush;
            if (scenarioContent[i] != "END")
            {
                toPush = scenarioContent[i]+i.ToString();
                i++;
                return toPush;
            }
            else
            {
                i=0;
                return null;
            }
        }


    }
}
