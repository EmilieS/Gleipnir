using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //public class VillagerProperties
    //{
        public enum Genders 
        {
            MALE = 0,
            FEMALE = 1
        };
        public enum Jobs
        {
            FARMER = 0,
            CONSTRUCTION_WORKER = 1,
            COOK = 10,

        };
        [Flags]
        public enum Healths
        {
            NONE = 0, ///Healthy
            DEAD = 1,            
            SICK = 2,
            DEPRESSED = 4,
            UNHAPPY=1<<4,
            HERETIC=1<<5
        };

        public enum Status
        {
            SINGLE = 0,
            MARRIED = 1,
            ENGAGED = 2
        }


    //}
}
