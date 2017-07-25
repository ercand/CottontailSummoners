using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Website.Helpers
{
    public static class Utility
    {
        private static readonly DateTime StartTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Secondi trascorsi a partire dall'epoch specificato
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SecondElapsedFromEpoch(long value)
        {
            return (int)(DateTime.UtcNow - StartTimeUtc.AddMilliseconds(value)).TotalSeconds;
        }

        /// <summary>
        /// Epoch to DateTime
        /// </summary>
        /// <param name="millisecondEpoch"></param>
        /// <returns></returns>
        public static DateTime FromMillisecondsEpochToDateTime(long millisecondEpoch)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(millisecondEpoch);
        }
        public static int WeekOfYearISO8601(DateTime date)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static int RankedDivisionToInt(string division)
        {
            switch (division.ToLower())
            {
                case "i":
                    return 1;
                case "ii":
                    return 2;
                case "iii":
                    return 3;
                case "iv":
                    return 4;
                case "v":
                    return 5;
                default:
                    throw new InvalidEnumArgumentException("Website.Helpers.Utility.RankedDivisionToInt(" + division + ");");
            }
        }
        public static string RankedDivisionToString(int division)
        {
            switch (division)
            {
                case 1:
                    return "i";
                case 2:
                    return "ii";
                case 3:
                    return "iii";
                case 4:
                    return "iv";
                case 5:
                    return "v";
                default:
                    throw new InvalidEnumArgumentException("Website.Helpers.Utility.RankedDivisionToString(" + division + ");");
            }
        }

        public static int TierToInt(this CottontailApi.Commons.Enums.TierType tier)
        {
            switch (tier)
            {
                case CottontailApi.Commons.Enums.TierType.CHALLENGER:
                    return 7;
                case CottontailApi.Commons.Enums.TierType.MASTER:
                    return 6;
                case CottontailApi.Commons.Enums.TierType.DIAMOND:
                    return 5;
                case CottontailApi.Commons.Enums.TierType.PLATINUM:
                    return 4;
                case CottontailApi.Commons.Enums.TierType.GOLD:
                    return 3;
                case CottontailApi.Commons.Enums.TierType.SILVER:
                    return 2;
                case CottontailApi.Commons.Enums.TierType.BRONZE:
                    return 1;
                case CottontailApi.Commons.Enums.TierType.UNRANKED:
                    return 0;
                default:
                    throw new InvalidEnumArgumentException("Website.Helpers.Utility.TierToInt(" + tier + ");");
            }
        }

        public static string TierToString(int tier)
        {
            switch (tier)
            {
                case 7:
                    return "Challenger";
                case 6:
                    return "Master";
                case 5:
                    return "Diamond";
                case 4:
                    return "Platinum";
                case 3:
                    return "Gold";
                case 2:
                    return "Silver";
                case 1:
                    return "Bronze";
                case 0:
                    return "Unranked";
                default:
                    throw new InvalidEnumArgumentException("Website.Helpers.Utility.TierToString(" + tier + ");");
            }
        }

        public static bool IsBotGame(CottontailApi.Commons.Enums.GameQueueType queueType)
        {
            if (queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_5x5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_5x5_BEGINNER ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_5x5_INTERMEDIATE ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_5x5_INTRO ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK1 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK2 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_ODIN_5x5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_TT_3x3 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.BOT_URF_5x5)
            {
                return true;
            }
            return false;
        }

        public static bool IsRankedGame(CottontailApi.Commons.Enums.GameQueueType queueType)
        {
            if (queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_FLEX_TT ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_FLEX_SR ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_SOLO_5x5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_RANKED_SOLO ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_PREMADE_5x5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_TEAM_3x3 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_TEAM_5x5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5)
            {
                return true;
            }
            return false;
        }

        public static bool IsRankedSolo(CottontailApi.Commons.Enums.GameQueueType queueType)
        {
            if (queueType == CottontailApi.Commons.Enums.GameQueueType.RANKED_SOLO_5x5 ||
                queueType == CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_RANKED_SOLO)
            {
                return true;
            }
            return false;
        }

        public static class Region
        {
            public static CottontailApi.Commons.Enums.Region PlatformToRegion(CottontailApi.Commons.Enums.Platform platform)
            {
                switch (platform)
                {
                    case CottontailApi.Commons.Enums.Platform.BR1:
                        return CottontailApi.Commons.Enums.Region.BR;
                    case CottontailApi.Commons.Enums.Platform.EUN1:
                        return CottontailApi.Commons.Enums.Region.EUNE;
                    case CottontailApi.Commons.Enums.Platform.EUW1:
                        return CottontailApi.Commons.Enums.Region.EUW;
                    case CottontailApi.Commons.Enums.Platform.KR:
                        return CottontailApi.Commons.Enums.Region.KR;
                    case CottontailApi.Commons.Enums.Platform.LA1:
                        return CottontailApi.Commons.Enums.Region.LAN;
                    case CottontailApi.Commons.Enums.Platform.LA2:
                        return CottontailApi.Commons.Enums.Region.LAS;
                    case CottontailApi.Commons.Enums.Platform.NA1:
                        return CottontailApi.Commons.Enums.Region.NA;
                    case CottontailApi.Commons.Enums.Platform.OC1:
                        return CottontailApi.Commons.Enums.Region.OCE;
                    case CottontailApi.Commons.Enums.Platform.TR1:
                        return CottontailApi.Commons.Enums.Region.TR;
                    case CottontailApi.Commons.Enums.Platform.RU:
                        return CottontailApi.Commons.Enums.Region.RU;
                    case CottontailApi.Commons.Enums.Platform.JP1:
                        return CottontailApi.Commons.Enums.Region.JP;
                    case CottontailApi.Commons.Enums.Platform.PBE1:
                        return CottontailApi.Commons.Enums.Region.PBE;
                    default:
                        throw new InvalidEnumArgumentException();
                }
            }

            public static CottontailApi.Commons.Enums.Region StringToRegion(string region)
            {
                switch (region.ToUpper())
                {
                    case "BR":
                        return CottontailApi.Commons.Enums.Region.BR;
                    case "EUNE":
                        return CottontailApi.Commons.Enums.Region.EUNE;
                    case "EUW":
                        return CottontailApi.Commons.Enums.Region.EUW;
                    case "KR":
                        return CottontailApi.Commons.Enums.Region.KR;
                    case "LAN":
                        return CottontailApi.Commons.Enums.Region.LAN;
                    case "LAS":
                        return CottontailApi.Commons.Enums.Region.LAS;
                    case "NA":
                        return CottontailApi.Commons.Enums.Region.NA;
                    case "OCE":
                        return CottontailApi.Commons.Enums.Region.OCE;
                    case "TR":
                        return CottontailApi.Commons.Enums.Region.TR;
                    case "RU":
                        return CottontailApi.Commons.Enums.Region.RU;
                    case "JP":
                        return CottontailApi.Commons.Enums.Region.JP;
                    case "PBE":
                        return CottontailApi.Commons.Enums.Region.PBE;
                    case "GLOBAL":
                        return CottontailApi.Commons.Enums.Region.GLOBAL;
                    default:
                        throw new InvalidEnumArgumentException(region);
                }
            }

            public static CottontailApi.Commons.Enums.Region RegionIntToRegion(int region)
            {
                switch (region)
                {
                    case 0:
                        return CottontailApi.Commons.Enums.Region.BR;
                    case 1:
                        return CottontailApi.Commons.Enums.Region.EUNE;
                    case 2:
                        return CottontailApi.Commons.Enums.Region.EUW;
                    case 3:
                        return CottontailApi.Commons.Enums.Region.KR;
                    case 4:
                        return CottontailApi.Commons.Enums.Region.LAN;
                    case 5:
                        return CottontailApi.Commons.Enums.Region.LAS;
                    case 6:
                        return CottontailApi.Commons.Enums.Region.NA;
                    case 7:
                        return CottontailApi.Commons.Enums.Region.OCE;
                    case 8:
                        return CottontailApi.Commons.Enums.Region.TR;
                    case 9:
                        return CottontailApi.Commons.Enums.Region.RU;
                    case 10:
                        return CottontailApi.Commons.Enums.Region.JP;
                    case 11:
                        return CottontailApi.Commons.Enums.Region.PBE;
                    case 12:
                        return CottontailApi.Commons.Enums.Region.GLOBAL;
                    default:
                        throw new InvalidEnumArgumentException("Website.Helpers.Utility.RegionIntToRegion(" + region + ");");
                }
            }

            public static int RegionToInt(CottontailApi.Commons.Enums.Region region)
            {
                switch (region)
                {
                    case CottontailApi.Commons.Enums.Region.BR:
                        return 0;
                    case CottontailApi.Commons.Enums.Region.EUNE:
                        return 1;
                    case CottontailApi.Commons.Enums.Region.EUW:
                        return 2;
                    case CottontailApi.Commons.Enums.Region.KR:
                        return 3;
                    case CottontailApi.Commons.Enums.Region.LAN:
                        return 4;
                    case CottontailApi.Commons.Enums.Region.LAS:
                        return 5;
                    case CottontailApi.Commons.Enums.Region.NA:
                        return 6;
                    case CottontailApi.Commons.Enums.Region.OCE:
                        return 7;
                    case CottontailApi.Commons.Enums.Region.TR:
                        return 8;
                    case CottontailApi.Commons.Enums.Region.RU:
                        return 9;
                    case CottontailApi.Commons.Enums.Region.JP:
                        return 10;
                    case CottontailApi.Commons.Enums.Region.PBE:
                        return 11;
                    case CottontailApi.Commons.Enums.Region.GLOBAL:
                        return 12;
                    default:
                        throw new InvalidEnumArgumentException("Website.Helpers.Utility.RegionToInt(" + region + ");");
                }
            }
        }

        public static class Platform
        {
            public static int PlatformToInt(CottontailApi.Commons.Enums.Platform platform)
            {
                switch (platform)
                {
                    case CottontailApi.Commons.Enums.Platform.BR1:
                        return 0;
                    case CottontailApi.Commons.Enums.Platform.EUN1:
                        return 1;
                    case CottontailApi.Commons.Enums.Platform.EUW1:
                        return 2;
                    case CottontailApi.Commons.Enums.Platform.KR:
                        return 3;
                    case CottontailApi.Commons.Enums.Platform.LA1:
                        return 4;
                    case CottontailApi.Commons.Enums.Platform.LA2:
                        return 5;
                    case CottontailApi.Commons.Enums.Platform.NA1:
                        return 6;
                    case CottontailApi.Commons.Enums.Platform.OC1:
                        return 7;
                    case CottontailApi.Commons.Enums.Platform.TR1:
                        return 8;
                    case CottontailApi.Commons.Enums.Platform.RU:
                        return 9;
                    case CottontailApi.Commons.Enums.Platform.JP1:
                        return 10;
                    case CottontailApi.Commons.Enums.Platform.PBE1:
                        return 11;
                    default:
                        throw new InvalidEnumArgumentException("Website.Helpers.Utility.PlatformToInt(" + platform + ");");
                }
            }

            public static CottontailApi.Commons.Enums.Platform PlatformIntToPlatform(int platform)
            {
                switch (platform)
                {
                    case 0:
                        return CottontailApi.Commons.Enums.Platform.BR1;
                    case 1:
                        return CottontailApi.Commons.Enums.Platform.EUN1;
                    case 2:
                        return CottontailApi.Commons.Enums.Platform.EUW1;
                    case 3:
                        return CottontailApi.Commons.Enums.Platform.KR;
                    case 4:
                        return CottontailApi.Commons.Enums.Platform.LA1;
                    case 5:
                        return CottontailApi.Commons.Enums.Platform.LA2;
                    case 6:
                        return CottontailApi.Commons.Enums.Platform.NA1;
                    case 7:
                        return CottontailApi.Commons.Enums.Platform.OC1;
                    case 8:
                        return CottontailApi.Commons.Enums.Platform.TR1;
                    case 9:
                        return CottontailApi.Commons.Enums.Platform.RU;
                    case 10:
                        return CottontailApi.Commons.Enums.Platform.JP1;
                    case 11:
                        return CottontailApi.Commons.Enums.Platform.PBE1;
                    default:
                        throw new InvalidEnumArgumentException("Website.Helpers.Utility.Platform.PlatformIntToPlatform(" + platform + ");");
                }
            }

            public static string ToString(CottontailApi.Commons.Enums.Platform platform)
            {
                switch (platform)
                {
                    case CottontailApi.Commons.Enums.Platform.BR1:
                        return "BR1";
                    case CottontailApi.Commons.Enums.Platform.EUN1:
                        return "EUN1";
                    case CottontailApi.Commons.Enums.Platform.EUW1:
                        return "EUW1";
                    case CottontailApi.Commons.Enums.Platform.JP1:
                        return "JP1";
                    case CottontailApi.Commons.Enums.Platform.KR:
                        return "KR";
                    case CottontailApi.Commons.Enums.Platform.LA1:
                        return "LA1";
                    case CottontailApi.Commons.Enums.Platform.LA2:
                        return "LA2";
                    case CottontailApi.Commons.Enums.Platform.NA1:
                        return "NA1";
                    case CottontailApi.Commons.Enums.Platform.OC1:
                        return "OC1";
                    case CottontailApi.Commons.Enums.Platform.TR1:
                        return "TR1";
                    case CottontailApi.Commons.Enums.Platform.RU:
                        return "RU";
                    case CottontailApi.Commons.Enums.Platform.PBE1:
                        return "PBE1";
                    default:
                        throw new InvalidEnumArgumentException(platform.ToString());
                }
            }

            public static CottontailApi.Commons.Enums.Platform ToPlatform(CottontailApi.Commons.Enums.Region region)
            {
                switch (region)
                {
                    case CottontailApi.Commons.Enums.Region.BR:
                        return CottontailApi.Commons.Enums.Platform.BR1;
                    case CottontailApi.Commons.Enums.Region.EUNE:
                        return CottontailApi.Commons.Enums.Platform.EUN1;
                    case CottontailApi.Commons.Enums.Region.EUW:
                        return CottontailApi.Commons.Enums.Platform.EUW1;
                    case CottontailApi.Commons.Enums.Region.JP:
                        return CottontailApi.Commons.Enums.Platform.JP1;
                    case CottontailApi.Commons.Enums.Region.KR:
                        return CottontailApi.Commons.Enums.Platform.KR;
                    case CottontailApi.Commons.Enums.Region.LAN:
                        return CottontailApi.Commons.Enums.Platform.LA1;
                    case CottontailApi.Commons.Enums.Region.LAS:
                        return CottontailApi.Commons.Enums.Platform.LA2;
                    case CottontailApi.Commons.Enums.Region.NA:
                        return CottontailApi.Commons.Enums.Platform.NA1;
                    case CottontailApi.Commons.Enums.Region.OCE:
                        return CottontailApi.Commons.Enums.Platform.OC1;
                    case CottontailApi.Commons.Enums.Region.TR:
                        return CottontailApi.Commons.Enums.Platform.TR1;
                    case CottontailApi.Commons.Enums.Region.RU:
                        return CottontailApi.Commons.Enums.Platform.RU;
                    case CottontailApi.Commons.Enums.Region.PBE:
                        return CottontailApi.Commons.Enums.Platform.PBE1;
                    //     case Enums.Region.GLOBAL:
                    //        return Enums.Platform.;
                    default:
                        throw new InvalidEnumArgumentException(region.ToString());
                }
            }

            public static CottontailApi.Commons.Enums.Platform RegionIntToPlatform(int region)
            {
                return Utility.Platform.ToPlatform(Utility.Region.RegionIntToRegion(region));
            }
        }

        public static class Rune
        {
            public static string ToRunePageCode(List<CottontailApi.Dto.Runes.RuneSlotDto> slots)
            {
                // Inizializzo un lista di 30 valori con RuneId=0;
                List<string> list = new List<string>(30);
                for (int i = 0; i < 30; i++)
                {
                    list.Add((i + 1) + ":0");
                }

                if (slots != null)
                {
                    foreach (var item in slots)
                    {
                        int slotId = item.RuneSlotId;
                        int runeId = item.RuneId;
                        list[slotId - 1] = slotId + ":" + runeId;
                    }
                }
                return String.Join(",", list); //slotId:runeId,slotId:runeId,slotId:runeId
            }

            public static string ToRunePageCode(List<CottontailApi.Dto.Match.RuneDto> slots)
            {
                if (slots == null)
                    return "";

                List<string> list = new List<string>();
                foreach (var item in slots)
                {
                    list.Add(item.RuneId + ":" + item.Rank);
                }
                return String.Join(",", list);
            }

            public static List<Tuple<int, int>> RunePageCodeToList(string runePageCodeString)
            {
                List<Tuple<int, int>> result = new List<Tuple<int, int>>();

                if (runePageCodeString == string.Empty)
                {
                    return result;
                }

                var s = runePageCodeString.Split(',');

                foreach (var item in s)
                {
                    var temp = item.Split(':');

                    int RuneSlotId = Int32.Parse(temp[0]);
                    int RuneId = Int32.Parse(temp[1]);

                    Tuple<int, int> slot = new Tuple<int, int>(RuneSlotId, RuneId);
                    result.Add(slot);
                }

                return result;
            }
        }

        public static class Mastery
        {
            public static string ToMasteyPageCode(List<CottontailApi.Dto.Masteries.MasteryDto> slots)
            {
                if (slots == null)
                    return "";

                if (slots == null)
                {
                    return String.Empty;
                }
                List<string> list = new List<string>();

                foreach (var item in slots)
                {
                    int masteryId = item.Id;
                    int masteryRank = item.Rank;
                    list.Add(masteryId + ":" + masteryRank);
                }
                return String.Join(",", list);
            }

            public static string ToMasteyPageCode(List<CottontailApi.Dto.Match.MasteryDto> slots)
            {
                if (slots == null)
                    return "";

                List<string> list = new List<string>();

                foreach (var item in slots)
                {
                    int masteryId = (int)item.MasteryId;
                    int masteryRank = (int)item.Rank;
                    list.Add(masteryId + ":" + masteryRank);
                }
                return String.Join(",", list);
            }

            public static Dictionary<int, int> MasteryPageCodeToDictionary(string MasteryPageCodeString)
            {
                Dictionary<int, int> result = new Dictionary<int, int>();

                if (String.IsNullOrEmpty(MasteryPageCodeString))
                {
                    return result;
                }
                var s = MasteryPageCodeString.Split(',');

                foreach (var item in s)
                {
                    var temp = item.Split(':');

                    int masteryId = Int32.Parse(temp[0]);
                    int masteryPoint = Int32.Parse(temp[1]);


                    result.Add(masteryId, masteryPoint);
                }

                return result;
            }
        }

        public static class Html
        {
            public static string HtmlToolTipString(Dictionary<int, int> MasteryList, int id)
            {
                var md = (HttpRuntime.Cache[GlobalCustomConstants.MasteriesData] as CottontailApi.Dto.StaticData.MasteryListDto).Data;
                string result = "<span style =\"color:#fd4\">" + md[id.ToString()].Name + "</span><br />";
                string desc = (MasteryList.ContainsKey(id) ? md[id.ToString()].Description[MasteryList[id] - 1] : md[id.ToString()].Description[0]);

                return result + desc;
            }

            public static string HtmlMasteryBackgroundCssString(int id)
            {
                var cdn = (HttpRuntime.Cache[GlobalCustomConstants.MasteriesData] as CottontailApi.Dto.StaticData.MasteryListDto).Version;

                return "background-image:url(http://ddragon.leagueoflegends.com/cdn/" + cdn + "/img/mastery/" + id + ".png);";
            }
        }
    }
}