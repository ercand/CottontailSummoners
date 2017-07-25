using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Commons
{
    public static class GenericConverter
    {
        /// <summary>
        /// Convert PlatformId to string
        /// </summary>
        /// <param name="platformId"></param>
        /// <returns></returns>
        public static string PlatformIdToString(Enums.Platform platformId)
        {
            switch (platformId)
            {
                case Enums.Platform.BR1:
                    return "BR1";
                case Enums.Platform.EUN1:
                    return "EUN1";
                case Enums.Platform.EUW1:
                    return "EUW1";
                case Enums.Platform.JP1:
                    return "JP1";
                case Enums.Platform.KR:
                    return "KR";
                case Enums.Platform.LA1:
                    return "LA1";
                case Enums.Platform.LA2:
                    return "LA2";
                case Enums.Platform.NA1:
                    return "NA1";
                case Enums.Platform.OC1:
                    return "OC1";
                case Enums.Platform.TR1:
                    return "TR1";
                case Enums.Platform.RU:
                    return "RU";
                case Enums.Platform.PBE1:
                    return "PBE1";
                default:
                    throw new InvalidEnumArgumentException(platformId.ToString());
            }
        }

        /// <summary>
        /// Convert PlatformId to Region
        /// </summary>
        /// <param name="platformId"></param>
        /// <returns></returns>
        public static Enums.Region PlatformIdToRegion(Enums.Platform platformId)
        {
            switch (platformId)
            {
                case Enums.Platform.BR1:
                    return Enums.Region.BR;
                case Enums.Platform.EUN1:
                    return Enums.Region.EUNE;
                case Enums.Platform.EUW1:
                    return Enums.Region.EUW;
                case Enums.Platform.KR:
                    return Enums.Region.KR;
                case Enums.Platform.LA1:
                    return Enums.Region.LAN;
                case Enums.Platform.LA2:
                    return Enums.Region.LAS;
                case Enums.Platform.NA1:
                    return Enums.Region.NA;
                case Enums.Platform.OC1:
                    return Enums.Region.OCE;
                case Enums.Platform.TR1:
                    return Enums.Region.TR;
                case Enums.Platform.RU:
                    return Enums.Region.RU;
                case Enums.Platform.JP1:
                    return Enums.Region.JP;
                case Enums.Platform.PBE1:
                    return Enums.Region.PBE;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        /// <summary>
        /// Convert PlatformId to Region
        /// </summary>
        /// <param name="platformId"></param>
        /// <returns></returns>
        public static Enums.Region PlatformIdToRegion(string platformId)
        {
            switch (platformId.ToUpper())
            {
                case "BR1":
                    return Enums.Region.BR;
                case "EUN1":
                    return Enums.Region.EUNE;
                case "EUW1":
                    return Enums.Region.EUW;
                case "JP1":
                    return Enums.Region.JP;
                case "KR":
                    return Enums.Region.KR;
                case "LA1":
                    return Enums.Region.LAN;
                case "LA2":
                    return Enums.Region.LAS;
                case "NA1":
                    return Enums.Region.NA;
                case "OC1":
                    return Enums.Region.OCE;
                case "TR1":
                    return Enums.Region.TR;
                case "RU2":
                    return Enums.Region.RU;
                case "PBE1":
                    return Enums.Region.PBE;
                default:
                    throw new InvalidEnumArgumentException(platformId);
            }
        }

        /// <summary>
        /// Convert Region to PlatformId
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static Enums.Platform RegionToPlatfomrId(Enums.Region region)
        {
            switch (region)
            {
                case Enums.Region.BR:
                    return Enums.Platform.BR1;
                case Enums.Region.EUNE:
                    return Enums.Platform.EUN1;
                case Enums.Region.EUW:
                    return Enums.Platform.EUW1;
                case Enums.Region.JP:
                    return Enums.Platform.JP1;
                case Enums.Region.KR:
                    return Enums.Platform.KR;
                case Enums.Region.LAN:
                    return Enums.Platform.LA1;
                case Enums.Region.LAS:
                    return Enums.Platform.LA2;
                case Enums.Region.NA:
                    return Enums.Platform.NA1;
                case Enums.Region.OCE:
                    return Enums.Platform.OC1;
                case Enums.Region.TR:
                    return Enums.Platform.TR1;
                case Enums.Region.RU:
                    return Enums.Platform.RU;
                case Enums.Region.PBE:
                    return Enums.Platform.PBE1;
                //     case Enums.Region.GLOBAL:
                //        return Enums.Platform.;
                default:
                    throw new InvalidEnumArgumentException(region.ToString());
            }
        }

        /// <summary>
        /// Convert Region to PlatformId
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static Enums.Platform RegionToPlatfomrId(string region)
        {
            switch (region.ToUpper())
            {
                case "BR":
                    return Enums.Platform.BR1;
                case "EUNE":
                    return Enums.Platform.EUN1;
                case "EUW":
                    return Enums.Platform.EUW1;
                case "JP":
                    return Enums.Platform.JP1;
                case "KR":
                    return Enums.Platform.KR;
                case "LAN":
                    return Enums.Platform.LA1;
                case "LAS":
                    return Enums.Platform.LA2;
                case "NA":
                    return Enums.Platform.NA1;
                case "OCE":
                    return Enums.Platform.OC1;
                case "TR":
                    return Enums.Platform.TR1;
                case "RU":
                    return Enums.Platform.RU;
                case "PBE":
                    return Enums.Platform.PBE1;
                //     case Enums.Region.GLOBAL:
                //        return Enums.Platform.;
                default:
                    throw new InvalidEnumArgumentException(region);
            }
        }

        /// <summary>
        /// Convert Region to string
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static string RegionToString(Enums.Region region)
        {
            switch (region)
            {
                case Enums.Region.BR:
                    return "BR";
                case Enums.Region.EUNE:
                    return "EUNE";
                case Enums.Region.EUW:
                    return "EUW";
                case Enums.Region.KR:
                    return "KR";
                case Enums.Region.LAN:
                    return "LAN";
                case Enums.Region.LAS:
                    return "LAS";
                case Enums.Region.NA:
                    return "NA";
                case Enums.Region.OCE:
                    return "OCE";
                case Enums.Region.TR:
                    return "TR";
                case Enums.Region.RU:
                    return "RU";
                case Enums.Region.JP:
                    return "JP";
                case Enums.Region.PBE:
                    return "PBE";
                case Enums.Region.GLOBAL:
                    return "GLOBAL";
                default:
                    throw new InvalidEnumArgumentException(region.ToString());
            }
        }

        /// <summary>
        /// Convert Region to PlatformId
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static Enums.Region StringToRegion(string region)
        {
            switch (region.ToUpper())
            {
                case "BR":
                    return Enums.Region.BR;
                case "EUNE":
                    return Enums.Region.EUNE;
                case "EUW":
                    return Enums.Region.EUW;
                case "KR":
                    return Enums.Region.KR;
                case "LAN":
                    return Enums.Region.LAN;
                case "LAS":
                    return Enums.Region.LAS;
                case "NA":
                    return Enums.Region.NA;
                case "OCE":
                    return Enums.Region.OCE;
                case "TR":
                    return Enums.Region.TR;
                case "RU":
                    return Enums.Region.RU;
                case "JP":
                    return Enums.Region.JP;
                case "PBE":
                    return Enums.Region.PBE;
                case "GLOBAL":
                    return Enums.Region.GLOBAL;
                default:
                    throw new InvalidEnumArgumentException(region);
            }
        }

        public static string LeagueQueueTypeToString(Enums.LeagueQueueType leagueQueueType)
        {
            switch (leagueQueueType)
            {
                case Enums.LeagueQueueType.RANKED_FLEX_SR:
                    return "RANKED_FLEX_SR";
                case Enums.LeagueQueueType.RANKED_FLEX_TT:
                    return "RANKED_FLEX_TT";
                case Enums.LeagueQueueType.RANKED_SOLO_5x5:
                    return "RANKED_SOLO_5x5";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static Enums.LeagueQueueType StringToLeagueQueueType(string leagueQueueType)
        {
            switch (leagueQueueType)
            {
                case "RANKED_FLEX_SR":
                    return Enums.LeagueQueueType.RANKED_FLEX_SR;
                case "RANKED_FLEX_TT":
                    return Enums.LeagueQueueType.RANKED_FLEX_TT;
                case "RANKED_SOLO_5x5":
                    return Enums.LeagueQueueType.RANKED_SOLO_5x5;
                default:
                    throw new InvalidEnumArgumentException(leagueQueueType);
            }
        }

        public static Enums.Platform ConvertStringToPlatform(string platform)
        {
            switch (platform.ToUpper())
            {
                case "NA1":
                    return Enums.Platform.NA1;
                case "BR1":
                    return Enums.Platform.BR1;
                case "LA1":
                    return Enums.Platform.LA1;
                case "LA2":
                    return Enums.Platform.LA2;
                case "OC1":
                    return Enums.Platform.OC1;
                case "EUN1":
                    return Enums.Platform.EUN1;
                case "TR1":
                    return Enums.Platform.TR1;
                case "RU":
                    return Enums.Platform.RU;
                case "EUW1":
                    return Enums.Platform.EUW1;
                case "JP1":
                    return Enums.Platform.JP1;
                case "KR":
                    return Enums.Platform.KR;
                default:
                    throw new InvalidEnumArgumentException(platform);
            }
        }

        public static string ConvertPlatformToString(Enums.Platform platform)
        {
            return platform.ToString().ToUpper();
        }

        public static string WardTypeToString(Enums.WardType wardType)
        {
            switch (wardType)
            {
                case Enums.WardType.SIGHT_WARD:
                    return "SIGHT_WARD";
                case Enums.WardType.TEEMO_MUSHROOM:
                    return "TEEMO_MUSHROOM";
                case Enums.WardType.UNDEFINED:
                    return "UNDEFINED";
                case Enums.WardType.VISION_WARD:
                    return "VISION_WARD";
                case Enums.WardType.YELLOW_TRINKET:
                    return "YELLOW_TRINKET";
                case Enums.WardType.YELLOW_TRINKET_UPGRADE:
                    return "YELLOW_TRINKET_UPGRADE";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.WardType StringToWardType(string wardType)
        {
            switch (wardType)
            {
                case "SIGHT_WARD":
                    return Enums.WardType.SIGHT_WARD;
                case "TEEMO_MUSHROOM":
                    return Enums.WardType.TEEMO_MUSHROOM;
                case "UNDEFINED":
                    return Enums.WardType.UNDEFINED;
                case "VISION_WARD":
                    return Enums.WardType.VISION_WARD;
                case "YELLOW_TRINKET":
                    return Enums.WardType.YELLOW_TRINKET;
                case "YELLOW_TRINKET_UPGRADE":
                    return Enums.WardType.YELLOW_TRINKET_UPGRADE;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string TowerTypeToString(Enums.TowerType towerType)
        {
            switch (towerType)
            {
                case Enums.TowerType.BASE_TURRET:
                    return "BASE_TURRET";
                case Enums.TowerType.FOUNTAIN_TURRET:
                    return "FOUNTAIN_TURRET";
                case Enums.TowerType.INNER_TURRET:
                    return "INNER_TURRET";
                case Enums.TowerType.NEXUS_TURRET:
                    return "NEXUS_TURRET";
                case Enums.TowerType.OUTER_TURRET:
                    return "OUTER_TURRET";
                case Enums.TowerType.UNDEFINED_TURRET:
                    return "UNDEFINED_TURRET";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.TowerType StringToTowerType(string towerType)
        {
            switch (towerType)
            {
                case "BASE_TURRET":
                    return Enums.TowerType.BASE_TURRET;
                case "FOUNTAIN_TURRET":
                    return Enums.TowerType.FOUNTAIN_TURRET;
                case "INNER_TURRET":
                    return Enums.TowerType.INNER_TURRET;
                case "NEXUS_TURRET":
                    return Enums.TowerType.NEXUS_TURRET;
                case "OUTER_TURRET":
                    return Enums.TowerType.OUTER_TURRET;
                case "UNDEFINED_TURRET":
                    return Enums.TowerType.UNDEFINED_TURRET;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string CapturePointToString(Enums.CapturePoint capturePoint)
        {
            switch (capturePoint)
            {
                case Enums.CapturePoint.POINT_A:
                    return "POINT_A";
                case Enums.CapturePoint.POINT_B:
                    return "POINT_B";
                case Enums.CapturePoint.POINT_C:
                    return "POINT_C";
                case Enums.CapturePoint.POINT_D:
                    return "POINT_D";
                case Enums.CapturePoint.POINT_E:
                    return "POINT_E";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.CapturePoint StringToCapturePoint(string capturePoint)
        {
            switch (capturePoint)
            {
                case "POINT_A":
                    return Enums.CapturePoint.POINT_A;
                case "POINT_B":
                    return Enums.CapturePoint.POINT_B;
                case "POINT_C":
                    return Enums.CapturePoint.POINT_C;
                case "POINT_D":
                    return Enums.CapturePoint.POINT_D;
                case "POINT_E":
                    return Enums.CapturePoint.POINT_E;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string MonsterTypeToString(Enums.MonsterType monsterType)
        {
            switch (monsterType)
            {
                case Enums.MonsterType.BARON_NASHOR:
                    return "BARON_NASHOR";
                case Enums.MonsterType.BLUE_GOLEM:
                    return "BLUE_GOLEM";
                case Enums.MonsterType.DRAGON:
                    return "DRAGON";
                case Enums.MonsterType.RED_LIZARD:
                    return "RED_LIZARD";
                case Enums.MonsterType.VILEMAW:
                    return "VILEMAW";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.MonsterType StringToMonsterType(string monsterType)
        {
            switch (monsterType)
            {
                case "BARON_NASHOR":
                    return Enums.MonsterType.BARON_NASHOR;
                case "BLUE_GOLEM":
                    return Enums.MonsterType.BLUE_GOLEM;
                case "DRAGON":
                    return Enums.MonsterType.DRAGON;
                case "RED_LIZARD":
                    return Enums.MonsterType.RED_LIZARD;
                case "VILEMAW":
                    return Enums.MonsterType.VILEMAW;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string LevelUpTypeToString(Enums.LevelUpType levelUpType)
        {
            switch (levelUpType)
            {
                case Enums.LevelUpType.EVOLVE:
                    return "EVOLVE";
                case Enums.LevelUpType.NORMAL:
                    return "NORMAL";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.LevelUpType StringToLevelUpType(string levelUpType)
        {
            switch (levelUpType)
            {
                case "EVOLVE":
                    return Enums.LevelUpType.EVOLVE;
                case "NORMAL":
                    return Enums.LevelUpType.NORMAL;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string LaneTypeToString(Enums.LaneType laneType)
        {
            switch (laneType)
            {
                case Enums.LaneType.BOT_LANE:
                    return "BOT_LANE";
                case Enums.LaneType.MID_LANE:
                    return "MID_LANE";
                case Enums.LaneType.TOP_LANE:
                    return "TOP_LANE";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.LaneType StringToLaneType(string laneType)
        {
            switch (laneType)
            {
                case "BOT_LANE":
                    return Enums.LaneType.BOT_LANE;
                case "MID_LANE":
                    return Enums.LaneType.MID_LANE;
                case "TOP_LANE":
                    return Enums.LaneType.TOP_LANE;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string BuildingTypeToString(Enums.BuildingType buildingType)
        {
            switch (buildingType)
            {
                case Enums.BuildingType.INHIBITOR_BUILDING:
                    return "INHIBITOR_BUILDING";
                case Enums.BuildingType.TOWER_BUILDING:
                    return "TOWER_BUILDING";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.BuildingType StringToBuildingType(string buildingType)
        {
            switch (buildingType)
            {
                case "INHIBITOR_BUILDING":
                    return Enums.BuildingType.INHIBITOR_BUILDING;
                case "TOWER_BUILDING":
                    return Enums.BuildingType.TOWER_BUILDING;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string AscendedTypeToString(Enums.AscendedType ascendedType)
        {
            switch (ascendedType)
            {
                case Enums.AscendedType.CHAMPION_ASCENDED:
                    return "CHAMPION_ASCENDED";
                case Enums.AscendedType.CLEAR_ASCENDED:
                    return "CLEAR_ASCENDED";
                case Enums.AscendedType.MINION_ASCENDED:
                    return "MINION_ASCENDED";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.AscendedType StringToAscendedType(string ascendedType)
        {
            switch (ascendedType)
            {
                case "CHAMPION_ASCENDED":
                    return Enums.AscendedType.CHAMPION_ASCENDED;
                case "CLEAR_ASCENDED":
                    return Enums.AscendedType.CLEAR_ASCENDED;
                case "MINION_ASCENDED":
                    return Enums.AscendedType.MINION_ASCENDED;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string EventTypeToString(Enums.EventType eventType)
        {
            switch (eventType)
            {
                case Enums.EventType.ASCENDED_EVENT:
                    return "ASCENDED_EVENT";
                case Enums.EventType.BUILDING_KILL:
                    return "BUILDING_KILL";
                case Enums.EventType.CAPTURE_POINT:
                    return "CAPTURE_POINT";
                case Enums.EventType.CHAMPION_KILL:
                    return "CHAMPION_KILL";
                case Enums.EventType.ELITE_MONSTER_KILL:
                    return "ELITE_MONSTER_KILL";
                case Enums.EventType.ITEM_DESTROYED:
                    return "ITEM_DESTROYED";
                case Enums.EventType.ITEM_PURCHASED:
                    return "ITEM_PURCHASED";
                case Enums.EventType.ITEM_SOLD:
                    return "ITEM_SOLD";
                case Enums.EventType.ITEM_UNDO:
                    return "ITEM_UNDO";
                case Enums.EventType.PORO_KING_SUMMON:
                    return "PORO_KING_SUMMON";
                case Enums.EventType.SKILL_LEVEL_UP:
                    return "SKILL_LEVEL_UP";
                case Enums.EventType.WARD_KILL:
                    return "WARD_KILL";
                case Enums.EventType.WARD_PLACED:
                    return "WARD_PLACED";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.EventType StringToEventType(string eventType)
        {
            switch (eventType)
            {
                case "ASCENDED_EVENT":
                    return Enums.EventType.ASCENDED_EVENT;
                case "BUILDING_KILL":
                    return Enums.EventType.BUILDING_KILL;
                case "CAPTURE_POINT":
                    return Enums.EventType.CAPTURE_POINT;
                case "CHAMPION_KILL":
                    return Enums.EventType.CHAMPION_KILL;
                case "ELITE_MONSTER_KILL":
                    return Enums.EventType.ELITE_MONSTER_KILL;
                case "ITEM_DESTROYED":
                    return Enums.EventType.ITEM_DESTROYED;
                case "ITEM_PURCHASED":
                    return Enums.EventType.ITEM_PURCHASED;
                case "ITEM_SOLD":
                    return Enums.EventType.ITEM_SOLD;
                case "ITEM_UNDO":
                    return Enums.EventType.ITEM_UNDO;
                case "PORO_KING_SUMMON":
                    return Enums.EventType.PORO_KING_SUMMON;
                case "SKILL_LEVEL_UP":
                    return Enums.EventType.SKILL_LEVEL_UP;
                case "WARD_KILL":
                    return Enums.EventType.WARD_KILL;
                case "WARD_PLACED":
                    return Enums.EventType.WARD_PLACED;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string LaneToString(Enums.Lane laneType)
        {
            switch (laneType)
            {
                case Enums.Lane.BOT:
                    return "BOT";
                case Enums.Lane.BOTTOM:
                    return "BOTTOM";
                case Enums.Lane.JUNGLE:
                    return "JUNGLE";
                case Enums.Lane.MID:
                    return "MID";
                case Enums.Lane.MIDDLE:
                    return "MIDDLE";
                case Enums.Lane.TOP:
                    return "TOP";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.Lane StringToLane(string laneType)
        {
            switch (laneType)
            {
                case "BOT":
                    return Enums.Lane.BOT;
                case "BOTTOM":
                    return Enums.Lane.BOTTOM;
                case "JUNGLE":
                    return Enums.Lane.JUNGLE;
                case "MID":
                    return Enums.Lane.MID;
                case "MIDDLE":
                    return Enums.Lane.MIDDLE;
                case "TOP":
                    return Enums.Lane.TOP;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static string RoleToString(Enums.Role roleType)
        {
            switch (roleType)
            {
                case Enums.Role.DUO:
                    return "DUO";
                case Enums.Role.DUO_CARRY:
                    return "DUO_CARRY";
                case Enums.Role.DUO_SUPPORT:
                    return "DUO_SUPPORT";
                case Enums.Role.NONE:
                    return "NONE";
                case Enums.Role.SOLO:
                    return "SOLO";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.Role StringToRole(string roleType)
        {
            switch (roleType)
            {
                case "DUO":
                    return Enums.Role.DUO;
                case "DUO_CARRY":
                    return Enums.Role.DUO_CARRY;
                case "DUO_SUPPORT":
                    return Enums.Role.DUO_SUPPORT;
                case "NONE":
                    return Enums.Role.NONE;
                case "SOLO":
                    return Enums.Role.SOLO;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static string SeasonTypeToString(Enums.SeasonType seasonType)
        {
            switch (seasonType)
            {
                case Enums.SeasonType.PRESEASON3:
                    return "PRESEASON3";
                case Enums.SeasonType.SEASON3:
                    return "SEASON3";

                case Enums.SeasonType.PRESEASON2014:
                    return "PRESEASON2014";
                case Enums.SeasonType.SEASON2014:
                    return "SEASON2014";

                case Enums.SeasonType.PRESEASON2015:
                    return "PRESEASON2015";
                case Enums.SeasonType.SEASON2015:
                    return "SEASON2015";

                case Enums.SeasonType.PRESEASON2016:
                    return "PRESEASON2016";
                case Enums.SeasonType.SEASON2016:
                    return "SEASON2016";

                case Enums.SeasonType.PRESEASON2017:
                    return "PRESEASON2017";
                case Enums.SeasonType.SEASON2017:
                    return "SEASON2017";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.SeasonType StringToSeasonType(string seasonType)
        {
            switch (seasonType)
            {
                case "PRESEASON3":
                    return Enums.SeasonType.PRESEASON3;
                case "SEASON3":
                    return Enums.SeasonType.SEASON3;
            
                case "PRESEASON2014":
                    return Enums.SeasonType.PRESEASON2014;
                case "SEASON2014":
                    return Enums.SeasonType.SEASON2014;

                case "PRESEASON2015":
                    return Enums.SeasonType.PRESEASON2015;
                case "SEASON2015":
                    return Enums.SeasonType.SEASON2015;
                
                case "PRESEASON2016":
                    return Enums.SeasonType.PRESEASON2016;
                case "SEASON2016":
                    return Enums.SeasonType.SEASON2016;

                case "PRESEASON2017":
                    return Enums.SeasonType.PRESEASON2017;
                case "SEASON2017":
                    return Enums.SeasonType.SEASON2017;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }


        public static string TierTypeToString(Enums.TierType tierType)
        {
            switch (tierType)
            {
                case Enums.TierType.CHALLENGER:
                    return "CHALLENGER";
                case Enums.TierType.MASTER:
                    return "MASTER";
                case Enums.TierType.DIAMOND:
                    return "DIAMOND";
                case Enums.TierType.PLATINUM:
                    return "PLATINUM";
                case Enums.TierType.GOLD:
                    return "GOLD";
                case Enums.TierType.SILVER:
                    return "SILVER";
                case Enums.TierType.BRONZE:
                    return "BRONZE";
                case Enums.TierType.UNRANKED:
                    return "UNRANKED";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        public static Enums.TierType StringToTierType(string tierType)
        {
            switch (tierType)
            {
                case "CHALLENGER":
                    return Enums.TierType.CHALLENGER;
                case "MASTER":
                    return Enums.TierType.MASTER;
                case "DIAMOND":
                    return Enums.TierType.DIAMOND;
                case "PLATINUM":
                    return Enums.TierType.PLATINUM;
                case "GOLD":
                    return Enums.TierType.GOLD;
                case "SILVER":
                    return Enums.TierType.SILVER;
                case "BRONZE":
                    return Enums.TierType.BRONZE;
                case "UNRANKED":
                    return Enums.TierType.UNRANKED;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }


        public static string PlayerStatsSummaryTypeToString(Enums.PlayerStatsSummaryType playerStatsSummaryType)
        {
            return ((Enums.PlayerStatsSummaryType)playerStatsSummaryType).ToString();
        }
        public static Enums.PlayerStatsSummaryType StringToPlayerStatsSummaryType(string playerStatsSummaryType)
        {
            switch (playerStatsSummaryType)
            {
                case "AramUnranked5x5":
                    return Enums.PlayerStatsSummaryType.AramUnranked5x5;
                case "CAP5x5":
                    return Enums.PlayerStatsSummaryType.CAP5x5;
                case "CoopVsAI":
                    return Enums.PlayerStatsSummaryType.CoopVsAI;
                case "CoopVsAI3x3":
                    return Enums.PlayerStatsSummaryType.CoopVsAI3x3;
                case "OdinUnranked":
                    return Enums.PlayerStatsSummaryType.OdinUnranked;
                case "RankedPremade3x3":
                    return Enums.PlayerStatsSummaryType.RankedPremade3x3;
                case "RankedPremade5x5":
                    return Enums.PlayerStatsSummaryType.RankedPremade5x5;
                case "RankedSolo5x5":
                    return Enums.PlayerStatsSummaryType.RankedSolo5x5;
                case "RankedTeam3x3":
                    return Enums.PlayerStatsSummaryType.RankedTeam3x3;
                case "RankedTeam5x5":
                    return Enums.PlayerStatsSummaryType.RankedTeam5x5;
                case "Unranked":
                    return Enums.PlayerStatsSummaryType.Unranked;
                case "Unranked3x3":
                    return Enums.PlayerStatsSummaryType.Unranked3x3;
                case "OneForAll5x5":
                    return Enums.PlayerStatsSummaryType.OneForAll5x5;
                case "FirstBlood1x1":
                    return Enums.PlayerStatsSummaryType.FirstBlood1x1;
                case "FirstBlood2x2":
                    return Enums.PlayerStatsSummaryType.FirstBlood2x2;
                case "SummonersRift6x6":
                    return Enums.PlayerStatsSummaryType.SummonersRift6x6;
                case "URF":
                    return Enums.PlayerStatsSummaryType.URF;
                case "URFBots":
                    return Enums.PlayerStatsSummaryType.URFBots;
                case "NightmareBot":
                    return Enums.PlayerStatsSummaryType.NightmareBot;
                case "Ascension":
                    return Enums.PlayerStatsSummaryType.Ascension;
                case "Hexakill":
                    return Enums.PlayerStatsSummaryType.Hexakill;
                case "KingPoro":
                    return Enums.PlayerStatsSummaryType.KingPoro;
                case "CounterPick":
                    return Enums.PlayerStatsSummaryType.CounterPick;
                case "Bilgewater":
                    return Enums.PlayerStatsSummaryType.Bilgewater;
                case "RankedFlexSR":
                    return Enums.PlayerStatsSummaryType.RankedFlexSR;
                case "RankedFlexTT":
                    return Enums.PlayerStatsSummaryType.RankedFlexTT;
                default:
                    throw new InvalidEnumArgumentException(playerStatsSummaryType);
            }
        }

        public static string SeasonNoPreSeasonTypeToString(Enums.SeasonNoPreSeasonType seasonNoPreSeasonType)
        {
            return ((Enums.SeasonNoPreSeasonType)seasonNoPreSeasonType).ToString();
        }

        //
        public static string GameTypeToString(Enums.GameType gameType)
        {
            return ((Enums.GameType)gameType).ToString();
        }
        public static Enums.GameType StringToGameType(string gameType)
        {
            switch (gameType)
            {
                case "CUSTOM_GAME":
                    return Enums.GameType.CUSTOM_GAME;
                case "TUTORIAL_GAME":
                    return Enums.GameType.TUTORIAL_GAME;
                case "MATCHED_GAME":
                    return Enums.GameType.MATCHED_GAME;
                default:
                    throw new InvalidEnumArgumentException(gameType);
            }
        }

        //
        public static string GameQueueTypeToString(Enums.GameQueueType gameQueueType)
        {
            return ((Enums.GameQueueType)gameQueueType).ToString();
        }
        public static Enums.GameQueueType StringToGameQueueType(string gameQueueType)
        {
            switch (gameQueueType)
            {
                case "CUSTOM":
                case "0":
                    return Enums.GameQueueType.CUSTOM;
                case "NORMAL_5x5_BLIND":
                case "2":
                    return Enums.GameQueueType.NORMAL_5x5_BLIND;
                case "BOT_5x5":
                case "7":
                    return Enums.GameQueueType.BOT_5x5;
                case "BOT_5x5_INTRO":
                case "31":
                    return Enums.GameQueueType.BOT_5x5_INTRO;
                case "BOT_5x5_BEGINNER":
                case "32":
                    return Enums.GameQueueType.BOT_5x5_BEGINNER;
                case "BOT_5x5_INTERMEDIATE":
                case "33":
                    return Enums.GameQueueType.BOT_5x5_INTERMEDIATE;
                case "NORMAL_3x3":
                case "8":
                    return Enums.GameQueueType.NORMAL_3x3;
                case "NORMAL_5x5_DRAFT":
                case "14":
                    return Enums.GameQueueType.NORMAL_5x5_DRAFT;
                case "ODIN_5x5_BLIND":
                case "16":
                    return Enums.GameQueueType.ODIN_5x5_BLIND;
                case "ODIN_5x5_DRAFT":
                case "17":
                    return Enums.GameQueueType.ODIN_5x5_DRAFT;
                case "BOT_ODIN_5x5":
                case "25":
                    return Enums.GameQueueType.BOT_ODIN_5x5;
                case "RANKED_SOLO_5x5":
                case "4":
                    return Enums.GameQueueType.RANKED_SOLO_5x5;
                case "RANKED_FLEX_TT":
                case "RANKED_PREMADE_3x3":
                case "9":
                    return Enums.GameQueueType.RANKED_FLEX_TT;
                case "RANKED_PREMADE_5x5":
                case "6":
                    return Enums.GameQueueType.RANKED_PREMADE_5x5;
                case "RANKED_TEAM_3x3":
                case "41":
                    return Enums.GameQueueType.RANKED_TEAM_3x3;
                case "RANKED_TEAM_5x5":
                case "42":
                    return Enums.GameQueueType.RANKED_TEAM_5x5;
                case "BOT_TT_3x3":
                case "52":
                    return Enums.GameQueueType.BOT_TT_3x3;
                case "GROUP_FINDER_5x5":
                case "61":
                    return Enums.GameQueueType.GROUP_FINDER_5x5;
                case "ARAM_5x5":
                case "65":
                    return Enums.GameQueueType.ARAM_5x5;
                case "ONEFORALL_5x5":
                case "70":
                    return Enums.GameQueueType.ONEFORALL_5x5;
                case "FIRSTBLOOD_1x1":
                case "72":
                    return Enums.GameQueueType.FIRSTBLOOD_1x1;
                case "FIRSTBLOOD_2x2":
                case "73":
                    return Enums.GameQueueType.FIRSTBLOOD_2x2;
                case "SR_6x6":
                case "75":
                    return Enums.GameQueueType.SR_6x6;
                case "URF_5x5":
                case "76":
                    return Enums.GameQueueType.URF_5x5;
                case "BOT_URF_5x5":
                case "83":
                    return Enums.GameQueueType.BOT_URF_5x5;
                case "NIGHTMARE_BOT_5x5_RANK1":
                case "91":
                    return Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK1;
                case "NIGHTMARE_BOT_5x5_RANK2":
                case "92":
                    return Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK2;
                case "NIGHTMARE_BOT_5x5_RANK5":
                case "93":
                    return Enums.GameQueueType.NIGHTMARE_BOT_5x5_RANK5;
                case "ASCENSION_5x5":
                case "96":
                    return Enums.GameQueueType.ASCENSION_5x5;
                case "HEXAKILL":
                case "98":
                    return Enums.GameQueueType.HEXAKILL;
                case "BILGEWATER_ARAM_5x5":
                case "100":
                    return Enums.GameQueueType.BILGEWATER_ARAM_5x5;
                case "KING_PORO_5x5":
                case "300":
                    return Enums.GameQueueType.KING_PORO_5x5;
                case "SIEGE":
                case "315":
                    return Enums.GameQueueType.SIEGE;
                case "DEFINITELY_NOT_DOMINION_5x5":
                case "317":
                    return Enums.GameQueueType.DEFINITELY_NOT_DOMINION_5x5;
                case "BILGEWATER_5x5":
                case "313":
                    return Enums.GameQueueType.BILGEWATER_5x5;
                case "ARURF_5X5":
                case "318":
                    return Enums.GameQueueType.ARURF_5X5;
                case "ARSR_5x5":
                case "325":
                    return Enums.GameQueueType.ARSR_5x5;
                case "TEAM_BUILDER_DRAFT_UNRANKED_5x5":
                case "400":
                    return Enums.GameQueueType.TEAM_BUILDER_DRAFT_UNRANKED_5x5;
                case "TEAM_BUILDER_DRAFT_RANKED_5x5":
                case "410":
                    return Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5;
                case "TEAM_BUILDER_RANKED_SOLO":
                case "420":
                    return Enums.GameQueueType.TEAM_BUILDER_RANKED_SOLO; 
                case "RANKED_FLEX_SR":
                case "440":
                    return Enums.GameQueueType.RANKED_FLEX_SR;
                case "ASSASSINATE_5x5":
                case "600":
                    return Enums.GameQueueType.ASSASSINATE_5x5;
                case "DARKSTAR_3x3":
                case "610":
                    return Enums.GameQueueType.DARKSTAR_3x3;
                default:
                    throw new InvalidEnumArgumentException(gameQueueType);
            }
        }


        //
        public static string GameModeTypeToString(Enums.GameModeType gameModeType)
        {
            return ((Enums.GameModeType)gameModeType).ToString();
        }
        public static Enums.GameModeType StringToGameModeType(string gameModeType)
        {
            switch (gameModeType)
            {
                case "CLASSIC":
                    return Enums.GameModeType.CLASSIC;
                case "ODIN":
                    return Enums.GameModeType.ODIN;
                case "ARAM":
                    return Enums.GameModeType.ARAM;
                case "TUTORIAL":
                    return Enums.GameModeType.TUTORIAL;
                case "ONEFORALL":
                    return Enums.GameModeType.ONEFORALL;
                case "ASCENSION":
                    return Enums.GameModeType.ASCENSION;
                case "FIRSTBLOOD":
                    return Enums.GameModeType.FIRSTBLOOD;
                case "KINGPORO":
                    return Enums.GameModeType.KINGPORO;
                case "SIEGE":
                    return Enums.GameModeType.SIEGE;
                case "ASSASSINATE":
                    return Enums.GameModeType.ASSASSINATE;
                case "ARSR":
                    return Enums.GameModeType.ARSR;
                case "DARKSTAR":
                    return Enums.GameModeType.DARKSTAR;
                case "URF":
                    return Enums.GameModeType.URF;
                case "INTRO":
                    return Enums.GameModeType.INTRO;
                default:
                    throw new InvalidEnumArgumentException(gameModeType);
            }
        }
    }
}
