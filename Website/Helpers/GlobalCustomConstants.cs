using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Helpers
{
    public static class GlobalCustomConstants
    {
        public const CottontailApi.Commons.Enums.SeasonNoPreSeasonType CurrentSeasonNoPreseason = CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON2017;
        public const CottontailApi.Commons.Enums.SeasonNoPreSeasonType PreviousSeasonNoPreseason = CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON2016;
        public const CottontailApi.Commons.Enums.SeasonType CurrentSeason = CottontailApi.Commons.Enums.SeasonType.PRESEASON2017;
        public const CottontailApi.Commons.Enums.SeasonType PreviousSeason = CottontailApi.Commons.Enums.SeasonType.SEASON2016;
        public const string CurrentSeasonNumberString = "7";
        public const int CurrentSeasonNumber = 7;
        public const string PreviousSeasonNumberString = "6";
        public const int PreviousSeasonNumber = 6;

        //
        public const string ChampionData = "ChampionData";
        public const string SummonerSpellData = "SummonerSpellData";
        public const string RuneData = "RuneData";
        public const string ItemData = "ItemData";
        public const string MasteriesData = "MasteriesData";
    }
}