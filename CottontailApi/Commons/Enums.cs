using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Commons
{
    public class Enums
    {
        public enum AscendedType
        {
            CHAMPION_ASCENDED,
            CLEAR_ASCENDED,
            MINION_ASCENDED
        }
        /// <summary>
        /// 
        /// </summary>
        public enum BuildingType
        {
            INHIBITOR_BUILDING,
            TOWER_BUILDING
        }

        /// <summary>
        /// 
        /// </summary>
        public enum CapturePoint
        {
            POINT_A,
            POINT_B,
            POINT_C,
            POINT_D,
            POINT_E
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EventType
        {
            ASCENDED_EVENT,
            BUILDING_KILL,
            CAPTURE_POINT,
            CHAMPION_KILL,
            ELITE_MONSTER_KILL,
            ITEM_DESTROYED,
            ITEM_PURCHASED,
            ITEM_SOLD,
            ITEM_UNDO,
            PORO_KING_SUMMON,
            SKILL_LEVEL_UP,
            WARD_KILL,
            WARD_PLACED
        }
        /// <summary>
        /// Platform for the API.
        /// </summary>
        public enum Platform
        {
            /// <summary>
            /// Brasil.
            /// </summary>
            BR1,

            /// <summary>
            /// North-eastern Europe.
            /// </summary>
            EUN1,

            /// <summary>
            /// Western Europe.
            /// </summary>
            EUW1,

            /// <summary>
            /// Japan.
            /// </summary>
            JP1,

            /// <summary>
            /// Korea.
            /// </summary>
            KR,

            /// <summary>
            /// Latin America North.
            /// </summary>
            LA1,

            /// <summary>
            /// Latin America South.
            /// </summary>
            LA2,

            /// <summary>
            /// North America.
            /// </summary>
            NA1,

            /// <summary>
            /// Oceania.
            /// </summary>
            OC1,

            /// <summary>
            /// Turkey.
            /// </summary>
            TR1,

            /// <summary>
            /// Russia.
            /// </summary>
            RU,

            /// <summary>
            /// 
            /// </summary>
            PBE1
        }

        /// <summary>
        /// Server regions
        /// </summary>
        public enum Region
        {
            /// <summary>
            /// Brasil.
            /// </summary>
            BR,

            /// <summary>
            /// North-eastern europe.
            /// </summary>
            EUNE,

            /// <summary>
            /// Western europe.
            /// </summary>
            EUW,

            /// <summary>
            /// Japan.
            /// </summary>
            JP,

            /// <summary>
            /// South korea.
            /// </summary>
            KR,

            /// <summary>
            /// Latin America North.
            /// </summary>
            LAN,

            /// <summary>
            /// Latin America South.
            /// </summary>
            LAS,

            /// <summary>
            /// North america.
            /// </summary>
            NA,

            /// <summary>
            /// Oceania.
            /// </summary>
            OCE,

            /// <summary>
            /// Turkey.
            /// </summary>
            TR,

            /// <summary>
            /// Russia.
            /// </summary>
            RU,

            /// <summary>
            /// PBE.
            /// </summary>
            PBE,

            /// <summary>
            /// Global.
            /// </summary>
            GLOBAL
        }

        /// <summary>
        /// These constants populate the queueType ( match ) and gameQueueConfigId fields(match-v).
        /// </summary>
        public enum GameQueueType
        {
            /// <summary>
            /// Custom games
            /// </summary>
            CUSTOM = 0,

            /// <summary>
            /// Normal 3v3 games
            /// </summary>   
            NORMAL_3x3 = 8,

            /// <summary>
            /// Normal 5v5 Blind Pick games
            /// </summary>   
            NORMAL_5x5_BLIND = 2,

            /// <summary>
            /// Normal 5v5 Draft Pick games
            /// </summary>   
            NORMAL_5x5_DRAFT = 14,

            /// <summary>
            /// Ranked Solo 5v5 games
            /// </summary>   
            RANKED_SOLO_5x5 = 4,

            /// <summary>
            /// Ranked Premade 5v5 games
            /// </summary>   
            RANKED_PREMADE_5x5 = 6,

            /// <summary>
            /// Used for both historical Ranked Premade 3v3 games and current Ranked Flex Twisted Treeline games
            /// </summary>   
            RANKED_FLEX_TT = 9,

            /// <summary>
            /// Ranked Team 3v3 games
            /// </summary>   
            RANKED_TEAM_3x3 = 41,

            /// <summary>
            /// Ranked Team 5v5 games
            /// </summary>   
            RANKED_TEAM_5x5 = 42,

            /// <summary>
            /// Dominion 5v5 Blind Pick games
            /// </summary>   
            ODIN_5x5_BLIND = 16,

            /// <summary>
            /// Dominion 5v5 Draft Pick games
            /// </summary>   
            ODIN_5x5_DRAFT = 17,

            /// <summary>
            /// Historical Summoner's Rift Coop vs AI games
            /// </summary>   
            BOT_5x5 = 7,

            /// <summary>
            /// Dominion Coop vs AI games
            /// </summary>   
            BOT_ODIN_5x5 = 25,

            /// <summary>
            /// Summoner's Rift Coop vs AI Intro Bot games
            /// </summary>   
            BOT_5x5_INTRO = 31,

            /// <summary>
            /// Summoner's Rift Coop vs AI Beginner Bot games
            /// </summary>   
            BOT_5x5_BEGINNER = 32,

            /// <summary>
            /// Historical Summoner's Rift Coop vs AI Intermediate Bot games
            /// </summary>   
            BOT_5x5_INTERMEDIATE = 33,

            /// <summary>
            /// Twisted Treeline Coop vs AI games
            /// </summary>   
            BOT_TT_3x3 = 52,

            /// <summary>
            /// Team Builder games
            /// </summary>   
            GROUP_FINDER_5x5 = 61,

            /// <summary>
            /// ARAM games
            /// </summary>   
            ARAM_5x5 = 65,

            /// <summary>
            /// One for All games
            /// </summary>   
            ONEFORALL_5x5 = 70,

            /// <summary>
            /// Snowdown Showdown 1v1 games
            /// </summary>   
            FIRSTBLOOD_1x1 = 72,

            /// <summary>
            /// Snowdown Showdown 2v2 games
            /// </summary>   
            FIRSTBLOOD_2x2 = 73,

            /// <summary>
            /// Summoner's Rift 6x6 Hexakill games
            /// </summary>   
            SR_6x6 = 75,

            /// <summary>
            /// Ultra Rapid Fire games
            /// </summary>   
            URF_5x5 = 76,

            /// <summary>
            /// One for All (Mirror mode)
            /// </summary>
            ONEFORALL_MIRRORMODE_5x5 = 78,

            /// <summary>
            /// Ultra Rapid Fire games played against AI games
            /// </summary>   
            BOT_URF_5x5 = 83,

            /// <summary>
            /// Doom Bots Rank 1 games
            /// </summary>   
            NIGHTMARE_BOT_5x5_RANK1 = 91,

            /// <summary>
            /// Doom Bots Rank 2 games
            /// </summary>   
            NIGHTMARE_BOT_5x5_RANK2 = 92,

            /// <summary>
            /// Doom Bots Rank 5 games
            /// </summary>   
            NIGHTMARE_BOT_5x5_RANK5 = 93,

            /// <summary>
            /// Ascension games
            /// </summary>   
            ASCENSION_5x5 = 96,

            /// <summary>
            /// Twisted Treeline 6x6 Hexakill games
            /// </summary>   
            HEXAKILL = 98,

            /// <summary>
            /// Butcher's Bridge games
            /// </summary>   
            BILGEWATER_ARAM_5x5 = 100,

            /// <summary>
            /// King Poro games
            /// </summary>   
            KING_PORO_5x5 = 300,

            /// <summary>
            /// Nemesis games
            /// </summary>   
            COUNTER_PICK = 310,

            /// <summary>
            /// Black Market Brawlers game
            /// </summary>   
            BILGEWATER_5x5 = 313,

            /// <summary>
            /// Nexus Siege games
            /// </summary>
            SIEGE = 315,

            /// <summary>
            /// Definitely Not Dominion games
            /// </summary>
            DEFINITELY_NOT_DOMINION_5x5 = 317,

            /// <summary>
            /// All Random URF games
            /// </summary>
            ARURF_5X5 = 318,

            /// <summary>
            /// All Random Summoner's Rift games
            /// </summary>
            ARSR_5x5 = 325,

            /// <summary>
            /// Normal 5v5 Draft Pick games
            /// </summary>
            TEAM_BUILDER_DRAFT_UNRANKED_5x5 = 400,

            /// <summary>
            /// Ranked 5v5 Draft Pick games
            /// </summary>
            TEAM_BUILDER_DRAFT_RANKED_5x5 = 410,

            /// <summary>
            /// Ranked Solo games from current season that use Team Builder matchmaking
            /// </summary>
            TEAM_BUILDER_RANKED_SOLO = 420,

            /// <summary>
            /// Ranked Flex Summoner's Rift games
            /// </summary>
            RANKED_FLEX_SR = 440,

            /// <summary>
            /// Blood Hunt Assassin games
            /// </summary>
            ASSASSINATE_5x5 = 600,

            /// <summary>
            /// Darkstar games
            /// </summary>
            DARKSTAR_3x3 = 610
        }

        /// <summary>
        /// Mode of the game (Game API).
        /// These constants populate the gameMode (in "current-game-v1.0" and  "featured-games-v1.0") and matchMode ( match-v2.2) fields.
        /// </summary>
        public enum GameModeType
        {
            /// <summary>
            /// Classic Summoner's Rift and Twisted Treeline games.
            /// </summary>
            CLASSIC,

            /// <summary>
            /// Dominion/Crystal Scar games.
            /// </summary>
            ODIN,

            /// <summary>
            /// ARAM games.
            /// </summary>
            ARAM,

            /// <summary>
            /// Tutorial games.
            /// </summary>
            TUTORIAL,

            /// <summary>
            /// One for All games.
            /// </summary>
            ONEFORALL,

            /// <summary>
            /// Ascension mode games.
            /// </summary>
            ASCENSION,

            /// <summary>
            /// Snowdown Showdown games.
            /// </summary>
            FIRSTBLOOD,

            /// <summary>
            /// King Poro game mode.
            /// </summary>
            KINGPORO,

            /// <summary>
            /// Nexus Siege games
            /// </summary>
            SIEGE,

            /// <summary>
            /// Blood Hunt Assassin games
            /// </summary>
            ASSASSINATE,

            /// <summary>
            /// All Random Summoner's Rift games
            /// </summary>
            ARSR,

            /// <summary>
            /// Darkstar games
            /// </summary>
            DARKSTAR,

#warning nella documentazione non esiste ma è presente nel json
            URF,
            INTRO
        }

        /// <summary>
        /// These constants populate the gameType (in "current-game-v1.0" and  "featured-games-v1.0") and matchType ( match-v2.2) fields.
        /// </summary>
        public enum GameType
        {
            /// <summary>
            /// Custom games
            /// </summary>
            CUSTOM_GAME,

            /// <summary>
            /// All other games
            /// </summary>
            MATCHED_GAME,

            /// <summary>
            /// Tutorial games
            /// </summary>
            TUTORIAL_GAME
        }

        /// <summary>
        /// These constants populate the subType ( game-v1.3 ) field.
        /// </summary>

        public enum GameSubType
        {
            /// <summary>
            /// Custom games
            /// </summary>
            NONE,

            /// <summary>
            /// Summoner's Rift unranked games
            /// </summary>
            NORMAL,

            /// <summary>
            /// Twisted Treeline unranked games
            /// </summary>
            NORMAL_3x3,

            /// <summary>
            /// Dominion/Crystal Scar games
            /// </summary>
            ODIN_UNRANKED,

            /// <summary>
            /// ARAM / Howling Abyss games
            /// </summary>
            ARAM_UNRANKED_5x5,

            /// <summary>
            /// Summoner's Rift and Crystal Scar games played against Intro, Beginner, or Intermediate AI
            /// </summary>
            BOT,

            /// <summary>
            /// Twisted Treeline games played against AI
            /// </summary>
            BOT_3x3,

            /// <summary>
            /// Summoner's Rift ranked solo queue games
            /// </summary>
            RANKED_SOLO_5x5,

            /// <summary>
            /// 
            /// </summary>
            RANKED_PREMADE_3x3,

            /// <summary>
            /// 
            /// </summary>
            RANKED_PREMADE_5x5,

            /// <summary>
            /// Twisted Treeline ranked team games
            /// </summary>
            RANKED_TEAM_3x3,

            /// <summary>
            /// Summoner's Rift ranked team games
            /// </summary>
            RANKED_TEAM_5x5,

            /// <summary>
            /// One for All games
            /// </summary>
            ONEFORALL_5x5,

            /// <summary>
            /// Snowdown Showdown 1x1 games
            /// </summary>
            FIRSTBLOOD_1x1,

            /// <summary>
            /// Snowdown Showdown 2x2 games
            /// </summary>
            FIRSTBLOOD_2x2,

            /// <summary>
            /// Summoner's Rift 6x6 Hexakill games
            /// </summary>
            SR_6x6,

            /// <summary>
            /// Team Builder games
            /// </summary>
            CAP_5x5,

            /// <summary>
            /// Ultra Rapid Fire games
            /// </summary>
            URF,

            /// <summary>
            /// Ultra Rapid Fire games played against AI
            /// </summary>
            URF_BOT,

            /// <summary>
            /// Summoner's Rift games played against Nightmare AI
            /// </summary>
            NIGHTMARE_BOT,

            /// <summary>
            /// Ascension games
            /// </summary>
            ASCENSION,

            /// <summary>
            /// Twisted Treeline 6x6 Hexakill games
            /// </summary>
            HEXAKILL,

            /// <summary>
            /// King Poro games
            /// </summary>
            KING_PORO,

            /// <summary>
            /// Nemesis games
            /// </summary>
            COUNTER_PICK,

            /// <summary>
            /// Black Market Brawlers games
            /// </summary>
            BILGEWATER,

            /// <summary>
            /// Nexus Siege games
            /// </summary>
            SIEGE,

            /// <summary>
            /// Ranked Flex Twisted Treeline games
            /// </summary>
            RANKED_FLEX_TT,

            /// <summary>
            /// Ranked Flex Summoner's Rift games
            /// </summary>
            RANKED_FLEX_SR,

            /// <summary>
            /// Darkstar games
            /// </summary>
            DARKSTAR
        }
        /// <summary>
        /// Mode of the game (Game API).
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        public enum LaneType
        {
            BOT_LANE,
            MID_LANE,
            TOP_LANE
        }

        /// <summary>
        /// Match API
        /// </summary>
        public enum Lane
        {
            MID, MIDDLE, TOP, JUNGLE, BOT, BOTTOM
        }

        /// <summary>
        /// Language for the data retrieved (Static API).
        /// </summary>
        public enum Language
        {
            /// <summary>
            /// American English.
            /// </summary>
            en_US,

            /// <summary>
            /// British English.
            /// </summary>
            en_GB,

            /// <summary>
            /// Polish English.
            /// </summary>
            en_PL,

            /// <summary>
            /// Australian English.
            /// </summary>
            en_AU,

            /// <summary>
            /// Filipino English.
            /// </summary>
            en_PH,

            /// <summary>
            /// Singaporean English.
            /// </summary>
            en_SG,

            /// <summary>
            /// Polish.
            /// </summary>
            pl_PL,

            /// <summary>
            /// Czech.
            /// </summary>
            cs_CZ,

            /// <summary>
            /// Hungarian.
            /// </summary>
            hu_HU,

            /// <summary>
            /// German.
            /// </summary>
            de_DE,

            /// <summary>
            /// Spanish.
            /// </summary>
            es_ES,

            /// <summary>
            /// Argentinian Spanish.
            /// </summary>
            es_AR,

            /// <summary>
            /// Latam Spanish.
            /// </summary>
            es_MX,

            /// <summary>
            /// French.
            /// </summary>
            fr_FR,

            /// <summary>
            /// Italian.
            /// </summary>
            it_IT,

            /// <summary>
            /// Romanian.
            /// </summary>
            ro_RO,

            /// <summary>
            /// Greek.
            /// </summary>
            el_GR,

            /// <summary>
            /// Portuguese
            /// </summary>
            pt_PT,

            /// <summary>
            /// Brazilian Portuguese.
            /// </summary>
            pt_BR,

            /// <summary>
            /// Turkish.
            /// </summary>
            tr_TR,

            /// <summary>
            /// Russian.
            /// </summary>
            ru_RU,

            /// <summary>
            /// Chinese.
            /// </summary>
            zh_CN,

            /// <summary>
            /// Taiwanese Chinese.
            /// </summary>
            zh_TW,

            /// <summary>
            /// Korean.
            /// </summary>
            ko_KR,

            /// <summary>
            /// Bulgarian.
            /// </summary>
            bg_BG,

            /// <summary>
            /// Indonesian.
            /// </summary>
            id_ID,

            /// <summary>
            /// Malaysian.
            /// </summary>
            ms_MY,

            /// <summary>
            /// Malaysian Chinese.
            /// </summary>
            zh_MY,

            /// <summary>
            /// Dutch.
            /// </summary>
            nl_NL,

            /// <summary>
            /// Thaï.
            /// </summary>
            th_TH,

            /// <summary>
            /// Vietnamese.
            /// </summary>
            vn_VN,

            /// <summary>
            /// Japanese.
            /// </summary>
            ja_JP
        }

        /// <summary>
        /// Match API
        /// </summary>
        public enum Role
        {
            DUO, NONE, SOLO, DUO_CARRY, DUO_SUPPORT
        }

        /// <summary>
        /// 
        /// </summary>
        public enum LevelUpType
        {
            EVOLVE,
            NORMAL
        }

        /// <summary>
        /// 
        /// </summary>
        public enum MapType
        {
            /// <summary>
            /// Summoner's Rift Summer Variant
            /// </summary>
            SUMMONERS_RIFT_SUMMER_VARIANT = 1,

            /// <summary>
            /// Summoner's Rift Autumn Variant
            /// </summary>
            SUMMONERS_RIFT_AUTUMN_VARIANT = 2,

            /// <summary>
            /// The Proving Grounds Tutorial Map
            /// </summary>
            THE_PROVING_GROUNDS = 3,

            /// <summary>
            /// Twisted Treeline Original Version
            /// </summary>
            TWISTED_TREELINE_ORIGINAL = 4,

            /// <summary>
            ///The Crystal Scar Dominion Map
            /// </summary>
            THE_CRYSTAL_SCAR = 8,

            /// <summary>
            /// Twisted Treeline Current Version
            /// </summary>
            TWISTED_TREELINE_CURRENT = 10,

            /// <summary>
            /// Summoner's Rift Current Version
            /// </summary>
            SUMMONERS_RIFT = 11,

            /// <summary>
            /// Howling Abyss ARAM Map
            /// </summary>
            HOWLING_ABYSS = 12,

            /// <summary>
            /// Butcher's Bridge
            /// </summary>
            BUTCHERS_BRIDGE = 14,

            /// <summary>
            /// Darkstar Map
            /// </summary>
            COSMIC_RUINS = 16
        }

        /// <summary>
        /// 
        /// </summary>
        public enum MonsterType
        {
            BARON_NASHOR,
            BLUE_GOLEM,
            DRAGON,
            RED_LIZARD,
            RIFTHERALD,
            VILEMAW
        }

        /// <summary>
        /// For League-v3
        /// </summary>
        public enum LeagueQueueType
        {
            RANKED_FLEX_SR,
            RANKED_FLEX_TT,
            RANKED_SOLO_5x5
        }

        /// <summary>
        /// For Matchlist-v3
        /// </summary>
        public enum RankedMatchlistQueueType
        {
            TEAM_BUILDER_RANKED_SOLO = GameQueueType.TEAM_BUILDER_RANKED_SOLO,
            TEAM_BUILDER_DRAFT_RANKED_5x5 = GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5,
            RANKED_FLEX_SR = GameQueueType.RANKED_FLEX_SR,
            RANKED_FLEX_TT = GameQueueType.RANKED_FLEX_TT,
            RANKED_SOLO_5x5 = GameQueueType.RANKED_SOLO_5x5,
            RANKED_TEAM_3x3 = GameQueueType.RANKED_TEAM_3x3,
            RANKED_TEAM_5x5 = GameQueueType.RANKED_TEAM_5x5,
            ALL
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SeasonType
        {
            //UNKNOWN = 0,
            PRESEASON3 = 0,
            SEASON3 = 1,
            PRESEASON2014 = 2,
            SEASON2014 = 3,
            PRESEASON2015 = 4,
            SEASON2015 = 5,
            PRESEASON2016 = 6,
            SEASON2016 = 7,
            PRESEASON2017 = 8,
            SEASON2017 = 9
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SeasonNoPreSeasonType
        {
            UNKNOWN = 0,
            SEASON3 = SeasonType.SEASON3,
            SEASON2014 = SeasonType.SEASON2014,
            SEASON2015 = SeasonType.SEASON2015,
            SEASON2016 = SeasonType.SEASON2016,
            SEASON2017 = SeasonType.SEASON2017
        }

        /// <summary>
        /// Type of player stats (Stats API).
        /// </summary>
        public enum PlayerStatsSummaryType
        {
            AramUnranked5x5,
            CAP5x5,
            CoopVsAI,
            CoopVsAI3x3,
            OdinUnranked,
            RankedPremade3x3,
            RankedPremade5x5,
            RankedSolo5x5,
            RankedTeam3x3,
            RankedTeam5x5,
            Unranked,
            Unranked3x3,
            OneForAll5x5,
            FirstBlood1x1,
            FirstBlood2x2,
            SummonersRift6x6,
            URF,
            URFBots,
            NightmareBot,
            Ascension,
            Hexakill,
            KingPoro,
            CounterPick,
            Bilgewater,
            Siege,
            RankedFlexTT,
            RankedFlexSR
        }

        /// <summary>
        /// The league's tier.
        /// </summary>
        public enum TierType
        {
            CHALLENGER,
            MASTER,
            DIAMOND,
            PLATINUM,
            GOLD,
            SILVER,
            BRONZE,
            UNRANKED
        }


        public enum TowerType
        {
            BASE_TURRET,
            FOUNTAIN_TURRET,
            INNER_TURRET,
            NEXUS_TURRET,
            OUTER_TURRET,
            UNDEFINED_TURRET
        }
        public enum WardType
        {
            BLUE_TRINKET,
            SIGHT_WARD,
            TEEMO_MUSHROOM,
            UNDEFINED,
            VISION_WARD,
            YELLOW_TRINKET,
            YELLOW_TRINKET_UPGRADE
        }
        /// <summary>
        /// Riot API Response Error Codes. Per una documentazione dettagliata https://developer.riotgames.com/docs/response-codes
        /// </summary>
        public enum RiotApiErrorCode
        {
            /// <summary>
            /// This error indicates that there is a syntax error in the request and the request has therefore been denied.
            /// </summary>
            BAD_REQUEST = 400,

            /// <summary>
            /// This error indicates that the API request being made did not contain the necessary authentication credentials and therefore the client was denied access.
            /// </summary>
            UNAUTHORIZED = 401,

            /// <summary>
            /// This error indicates that the API request being made did not contain the necessary authentication credentials and therefore the client was denied access. If authentication credentials were already included then the Unauthorized response indicates that authorization has been refused for those credentials. In the case of the API, authorization credentials refer to your API key.
            /// </summary>
            FORBIDDEN = 403,

            /// <summary>
            /// This error indicates that the server has not found a match for the API request being made.
            /// </summary>
            NOT_FOUND = 404,

            /// <summary>
            /// This error indicates that the server is refusing to service the request because the body of the request is in a format that is not supported.
            /// </summary>
            UNSUPPORTED_MEDIA_TYPE = 415,

            /// <summary>
            /// This error indicates that the application has exhausted its maximum number of allotted API calls allowed for a given duration.
            /// </summary>
            RATE_LIMIT_EXCEEDED = 429,

            /// <summary>
            /// This error indicates an unexpected condition or exception which prevented the server from fulfilling an API request.
            /// </summary>
            INTERNAL_SERVER_ERROR = 500,

            /// <summary>
            /// 
            /// </summary>
            BAD_GETWAY = 502,

            /// <summary>
            /// This error indicates the server is currently unavailable to handle requests because of an unknown reason.
            /// </summary>
            SERVICE_UNAVAILABLE = 503,

            /// <summary>
            /// 
            /// </summary>
            GATEWAY_TIMEOUT = 504,

            /// <summary>
            /// Errore sconosciuto
            /// </summary>
            UNKNOWN = 0
        }
    }
}
