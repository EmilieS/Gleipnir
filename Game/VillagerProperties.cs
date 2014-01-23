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
        public enum BuildingTypes
        {
            NONE = 0,
            HOUSE = 5,
            FARM = 10,
            UNION = 20,
            RESTAURANT = 30,
            FORGE = 40,
            APOTHECARY_OFFICE = 50,
            MILITARY_CAMP = 60,
            MILL = 70,
            CLOTHES_SHOP = 80,
            BATHS=90,
            BROTHEL=100,
            CHAPEL=110,
            OFFERING_WAREHOUSE=120,
            PARTY_ROOM=130,
            TAVERN=140,
            THEATER=150,
        };

        [Flags]
        public enum Healths
        {
            NONE = 0, ///Healthy
            DEAD = 1,            
            SICK = 2,
            DEPRESSED = 4,
            UNHAPPY=1<<4,
            HERETIC=1<<5,
            ASSASSINATED=1<<6,
            EARTHQUAKE_INJURED=1<<7,
            HUNGRY=1<<8
        };
        public enum Status
        {
            SINGLE = 0,
            MARRIED = 1,
            ENGAGED = 2,
            MOURNING = 3
        };
        [Flags]
        public enum ActivityStatus
        {
            NONE = 0,
            HOBBY = 1,
            WORKING = 2,
            CONVOCATED = 1<<3,
            PARTYING = 1<<4    
        }
        public enum Missions
        {
            NONE = 0,
            ORACLE = 10,
            ASSASSIN = 20
        }

    //}
}
