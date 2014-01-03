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
        
        string[] scenarioContent = File.ReadAllLines(@"Extra\scenario.txt", Encoding.UTF8);
        public ScenarioEngine()
        {
            //ReadScenario();
        }

        public string ReadScenario()
        {
            string toPush;
            if (scenarioContent[i] != "END")
            {
                toPush = scenarioContent[i];
                i++;
                return toPush;
            }
            else
                return null;
        }
    }
}
