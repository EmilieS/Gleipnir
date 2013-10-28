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
            NONE = 0,
            FARMER = 10,
            CONSTRUCTION_WORKER = 20,
            COOKER = 30,
            BLACKSMITH = 40,
            APOTHECARY = 50,
            MILITIA = 60,
            MILLER = 70,
            TAILOR = 80
        };
        public enum Healths
        {
            DEAD = 0,
            HEATHY = 1,
            SICK = 2
        };
        public enum Status
        {
            SINGLE = 0,
            MARRIED = 1,
            ENGAGED = 2
        };
    //}
}
