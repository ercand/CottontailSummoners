using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Game
{
    /// <summary>
    /// This object contains game information.
    /// </summary>
    public class GameDto
    {
        /// <summary>
        /// Champion ID associated with game.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Date that end game data was recorded, specified as epoch milliseconds.
        /// </summary>
        [JsonProperty("createDate")]
        public long CreateDate { get; set; }

        /// <summary>
        /// Other players associated with the game.
        /// </summary>
        [JsonProperty("fellowPlayers")]
        public List<PlayerDto> FellowPlayers { get; set; }

        /// <summary>
        /// Game ID.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }


        /// <summary>
        /// The game mode (Legal values: CLASSIC, ODIN, ARAM, TUTORIAL, ONEFORALL, ASCENSION, FIRSTBLOOD, KINGPORO)
        /// </summary>
        [JsonConverter(typeof(GameModeTypeJsonConverter))]
        [JsonProperty("gameMode")]
        public RiotApi.Commons.Enums.GameModeType GameMode { get; set; }

        /// <summary>
        /// The game type (Legal values: CUSTOM_GAME, MATCHED_GAME, TUTORIAL_GAME)
        /// </summary>
        [JsonConverter(typeof(GameTypeJsonConverter))]
        [JsonProperty("gameType")]
        public RiotApi.Commons.Enums.GameType GameType { get; set; }

        /// <summary>
        /// Invalid flag.
        /// </summary>
        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        /// <summary>
        /// IP Earned.
        /// </summary>
        [JsonProperty("ipEarned")]
        public int IpEarned { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// The ID of the map
        /// </summary>
        [JsonConverter(typeof(MapTypeJsonConverter))]
        [JsonProperty("mapId")]
        public RiotApi.Commons.Enums.MapType MapId { get; set; }

        /// <summary>
        /// ID of first summoner spell.
        /// </summary>
        [JsonProperty("spell1")]
        public int SummonerSpell1 { get; set; }

        /// <summary>
        /// ID of second summoner spell.
        /// </summary>
        [JsonProperty("spell2")]
        public int SummonerSpell2 { get; set; }

        /// <summary>
        /// Statistics associated with the game for this summoner.
        /// </summary>
        [JsonProperty("stats")]
        public RawStatsDto Stats { get; set; }

        /// <summary>
        /// Game sub-type. (Legal values: NONE, NORMAL, BOT, RANKED_SOLO_5x5, RANKED_PREMADE_3x3, RANKED_PREMADE_5x5, ODIN_UNRANKED, RANKED_TEAM_3x3, RANKED_TEAM_5x5, NORMAL_3x3, BOT_3x3, CAP_5x5, 
        /// ARAM_UNRANKED_5x5, ONEFORALL_5x5, FIRSTBLOOD_1x1, FIRSTBLOOD_2x2, SR_6x6, URF, URF_BOT, NIGHTMARE_BOT, ASCENSION, HEXAKILL, KING_PORO, COUNTER_PICK, BILGEWATER)
        /// </summary>
        [JsonConverter(typeof(GameSubTypeJsonConverter))]
        [JsonProperty("subType")]
        public RiotApi.Commons.Enums.GameSubType SubType { get; set; }

        /// <summary>
        /// Team ID associated with game. Team ID 100 is blue team. Team ID 200 is purple team.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
