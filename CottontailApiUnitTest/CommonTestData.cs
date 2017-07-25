using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;

namespace CottontailApiUnitTest
{
    public static class CommonTestData
    {
        public static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        public static int ChampionId = Int32.Parse(ConfigurationManager.AppSettings["ChampionId"]);
        public static int SummonerId = Int32.Parse(ConfigurationManager.AppSettings["SummonerId"]);
        public static int AccountId = Int32.Parse(ConfigurationManager.AppSettings["AccountId"]);
        public static string SummonerName = ConfigurationManager.AppSettings["SummonerName"];
        public static long GameId = long.Parse(ConfigurationManager.AppSettings["GameId"]); 
        public static Enums.Platform Platform = (Enums.Platform)Enum.Parse(typeof(Enums.Platform),ConfigurationManager.AppSettings["CommonPlatform"]);
    }
}
