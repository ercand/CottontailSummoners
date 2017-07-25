using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Website.Helpers
{
    public static class EnumsToFriendlyString
    {
        public static string ToFriendlyName(this CottontailApi.Commons.Enums.Platform platform)
        {
            switch (platform)
            {
                case CottontailApi.Commons.Enums.Platform.BR1:
                    return "Brazil";
                case CottontailApi.Commons.Enums.Platform.EUN1:
                    return "EU Nordic & East";
                case CottontailApi.Commons.Enums.Platform.EUW1:
                    return "EU West";
                case CottontailApi.Commons.Enums.Platform.JP1:
                    return "Japan";
                case CottontailApi.Commons.Enums.Platform.KR:
                    return "Korea";
                case CottontailApi.Commons.Enums.Platform.LA1:
                    return "Latin America North";
                case CottontailApi.Commons.Enums.Platform.LA2:
                    return "Latin America South";
                case CottontailApi.Commons.Enums.Platform.NA1:
                    return "North America";
                case CottontailApi.Commons.Enums.Platform.OC1:
                    return "Oceania";
                case CottontailApi.Commons.Enums.Platform.TR1:
                    return "Turkey";
                case CottontailApi.Commons.Enums.Platform.RU:
                    return "Russian";
                case CottontailApi.Commons.Enums.Platform.PBE1:
                    return "PBE";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string ToFriendlyName(this CottontailApi.Commons.Enums.Region region)
        {
            switch (region)
            {
                case CottontailApi.Commons.Enums.Region.BR:
                    return "Brazil";
                case CottontailApi.Commons.Enums.Region.EUNE:
                    return "EU Nordic & East";
                case CottontailApi.Commons.Enums.Region.EUW:
                    return "EU West";
                case CottontailApi.Commons.Enums.Region.JP:
                    return "Japan";
                case CottontailApi.Commons.Enums.Region.KR:
                    return "Korea";
                case CottontailApi.Commons.Enums.Region.LAN:
                    return "Latin America North";
                case CottontailApi.Commons.Enums.Region.LAS:
                    return "Latin America South";
                case CottontailApi.Commons.Enums.Region.NA:
                    return "North America";
                case CottontailApi.Commons.Enums.Region.OCE:
                    return "Oceania";
                case CottontailApi.Commons.Enums.Region.TR:
                    return "Turkey";
                case CottontailApi.Commons.Enums.Region.RU:
                    return "Russian";
                case CottontailApi.Commons.Enums.Region.PBE:
                    return "PBE";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string ToFriendlyName(this CottontailApi.Commons.Enums.MapType map)
        {
            switch (map)
            {
                case CottontailApi.Commons.Enums.MapType.SUMMONERS_RIFT_SUMMER_VARIANT:
                case CottontailApi.Commons.Enums.MapType.SUMMONERS_RIFT_AUTUMN_VARIANT:
                case CottontailApi.Commons.Enums.MapType.SUMMONERS_RIFT:
                    return "Summoner's Rift";
                case CottontailApi.Commons.Enums.MapType.THE_PROVING_GROUNDS:
                    return "The Proving Grounds";
                case CottontailApi.Commons.Enums.MapType.TWISTED_TREELINE_ORIGINAL:
                    return "Old Twisted Treeline";
                case CottontailApi.Commons.Enums.MapType.THE_CRYSTAL_SCAR:
                    return "The Crystal Scar";
                case CottontailApi.Commons.Enums.MapType.TWISTED_TREELINE_CURRENT:
                    return "Twisted Treeline";
                case CottontailApi.Commons.Enums.MapType.HOWLING_ABYSS:
                    return "Howling Abyss";
                case CottontailApi.Commons.Enums.MapType.BUTCHERS_BRIDGE:
                    return "Butcher's Bridge";
                case CottontailApi.Commons.Enums.MapType.COSMIC_RUINS:
                    return "Cosmic Ruins";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string ToFriendlyName(this CottontailApi.Commons.Enums.GameQueueType gameQueue)
        {
            switch (gameQueue)
            {
                case CottontailApi.Commons.Enums.GameQueueType.CUSTOM:
                    return "Custom";
                case CottontailApi.Commons.Enums.GameQueueType.NORMAL_3x3:
                    return "Normal 3v3";
                case CottontailApi.Commons.Enums.GameQueueType.NORMAL_5x5_BLIND:
                    return "Normal 5v5"; // + "Blind Pick";
                case CottontailApi.Commons.Enums.GameQueueType.NORMAL_5x5_DRAFT:
                    return "Normal 5v5 Draft";
                case CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5:
                    return "Ranked 5v5";
                case CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_DRAFT_UNRANKED_5x5:
                    return "Normal 5v5 Draft";
                case CottontailApi.Commons.Enums.GameQueueType.RANKED_SOLO_5x5:
                    return "Ranked Solo 5v5";
                case CottontailApi.Commons.Enums.GameQueueType.RANKED_PREMADE_5x5:
                    return "Ranked Premade 5v5";
                case CottontailApi.Commons.Enums.GameQueueType.RANKED_FLEX_TT:
                    return "Ranked Premade 3v3";
                case CottontailApi.Commons.Enums.GameQueueType.RANKED_TEAM_3x3:
                    return "Ranked Team 3v3";
                case CottontailApi.Commons.Enums.GameQueueType.RANKED_TEAM_5x5:
                    return "Ranked Team 5v5";
                case CottontailApi.Commons.Enums.GameQueueType.ODIN_5x5_BLIND:
                    return "Dominion 5v5"; // + "Blind Pick";
                case CottontailApi.Commons.Enums.GameQueueType.ODIN_5x5_DRAFT:
                    return "Dominion 5v5 Draft";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_5x5:
                    return "Historical Summoner's Rift - Coop vs AI games";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_ODIN_5x5:
                    return "Dominion Coop";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_5x5_INTRO:
                    return "Summoner's Rift - Coop vs AI Intro Bot";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_5x5_BEGINNER:
                    return "Summoner's Rift - Coop vs AI Beginner Bot";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_5x5_INTERMEDIATE:
                    return "Summoner's Rift - Coop vs AI Intermediate Bot";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_TT_3x3:
                    return "Twisted Treeline - Coop";
                case CottontailApi.Commons.Enums.GameQueueType.GROUP_FINDER_5x5:
                    return "Team Builder";
                case CottontailApi.Commons.Enums.GameQueueType.ARAM_5x5:
                    return "ARAM";
                case CottontailApi.Commons.Enums.GameQueueType.ONEFORALL_5x5:
                    return "One for All";
                case CottontailApi.Commons.Enums.GameQueueType.FIRSTBLOOD_1x1:
                    return "Snowdown Showdown 1v1";
                case CottontailApi.Commons.Enums.GameQueueType.FIRSTBLOOD_2x2:
                    return "Snowdown Showdown 2v2";
                case CottontailApi.Commons.Enums.GameQueueType.SR_6x6:
                    return "Summoner's Rift 6x6 Hexakill";
                case CottontailApi.Commons.Enums.GameQueueType.URF_5x5:
                    return "Ultra Rapid Fire";
                case CottontailApi.Commons.Enums.GameQueueType.BOT_URF_5x5:
                    return "Ultra Rapid Fire vs Bot";
                case CottontailApi.Commons.Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK1:
                    return "Doom Bots Rank 1";
                case CottontailApi.Commons.Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK2:
                    return "Doom Bots Rank 2";
                case CottontailApi.Commons.Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK5:
                    return "Doom Bots Rank 5";
                case CottontailApi.Commons.Enums.GameQueueType.ASCENSION_5x5:
                    return "Ascension";
                case CottontailApi.Commons.Enums.GameQueueType.HEXAKILL:
                    return "Twisted Treeline 6x6 Hexakill";
                case CottontailApi.Commons.Enums.GameQueueType.BILGEWATER_ARAM_5x5:
                    return "Butcher's Bridge";
                case CottontailApi.Commons.Enums.GameQueueType.KING_PORO_5x5:
                    return "King Poro";
                case CottontailApi.Commons.Enums.GameQueueType.SIEGE:
                    return "Siege";
                case CottontailApi.Commons.Enums.GameQueueType.DEFINITELY_NOT_DOMINION_5x5:
                    return "Definitely Not Dominion";
                case CottontailApi.Commons.Enums.GameQueueType.ARURF_5X5:
                    return "All Random URF";
                case CottontailApi.Commons.Enums.GameQueueType.COUNTER_PICK:
                    return "Nemesis";
                case CottontailApi.Commons.Enums.GameQueueType.BILGEWATER_5x5:
                    return "Black Market Brawlers";
                case CottontailApi.Commons.Enums.GameQueueType.RANKED_FLEX_SR:
                    return "Ranked Flex";
                case CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_RANKED_SOLO:
                    return "Ranked Solo";
                case CottontailApi.Commons.Enums.GameQueueType.ARSR_5x5:
                    return "All Random Summoner's Rift games";
                case CottontailApi.Commons.Enums.GameQueueType.ASSASSINATE_5x5:
                    return "Blood Hunt Assassin games";
                case CottontailApi.Commons.Enums.GameQueueType.DARKSTAR_3x3:
                    return "Darkstar games";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string SeasonIntToString(int season)
        {
            switch (season)
            {
                case (int)CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON3:
                    return "Season 3";
                case (int)CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON2014:
                    return "Season 4";
                case (int)CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON2015:
                    return "Season 5";
                case (int)CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON2016:
                    return "Season 6";
                case (int)CottontailApi.Commons.Enums.SeasonNoPreSeasonType.SEASON2017:
                    return "Season 7";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}