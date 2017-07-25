using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using CottontailApi.Commons;
using CottontailApi.Commons.CustomJsonConverter;

namespace CottontailApi.Dto.Spectator
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrentGameInfo
    {
        /// <summary>
        /// The ID of the game
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The game start time represented in epoch milliseconds
        /// </summary>
        [JsonProperty("gameStartTime")]
        public long GameStartTime { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonConverter(typeof(PlatformJsonConverter))]
        [JsonProperty("platformId")]
        public Enums.Platform PlatformId { get; set; }

        /// <summary>
        /// The game mode (Legal values: CLASSIC, ODIN, ARAM, TUTORIAL, ONEFORALL, ASCENSION, FIRSTBLOOD, KINGPORO)
        /// </summary>
        [JsonConverter(typeof(GameModeTypeJsonConverter))]
        [JsonProperty("gameMode")]
        public Enums.GameModeType GameMode { get; set; }

        /// <summary>
        /// The ID of the map
        /// </summary>
        [JsonConverter(typeof(MapTypeJsonConverter))]
        [JsonProperty("mapId")]
        public Enums.MapType MapId { get; set; }

        /// <summary>
        /// The game type (Legal values: CUSTOM_GAME, MATCHED_GAME, TUTORIAL_GAME)
        /// </summary>
        [JsonConverter(typeof(GameTypeJsonConverter))]
        [JsonProperty("gameType")]
        public Enums.GameType GameType { get; set; }
        
        /// <summary>
        /// Banned champion information
        /// </summary>
        [JsonProperty("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        /// The observer information
        /// </summary>
        [JsonProperty("observers")]
        public Observer Observers { get; set; }
        
        /// <summary>
        /// The participant information
        /// </summary>
        [JsonProperty("participants")]
        public List<CurrentGameParticipant> Participants { get; set; }


        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        [JsonProperty("gameLength")]
        public long GameLength { get; set; }

        /// <summary>
        /// The queue type (queue types are documented on the Game Constants page)
        /// </summary>
        [JsonConverter(typeof(GameQueueTypeJsonConverter))]
        [JsonProperty("gameQueueConfigId")]
        public Enums.GameQueueType GameQueueConfigId { get; set; }
    }
}
