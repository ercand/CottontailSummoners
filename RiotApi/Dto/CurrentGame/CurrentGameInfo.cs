using Newtonsoft.Json;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;

namespace RiotApi.Dto.CurrentGame
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrentGameInfo
    {
        /// <summary>
        /// Banned champion information
        /// </summary>
        [JsonProperty("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        /// The ID of the game
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        [JsonProperty("gameLength")]
        public long GameLength { get; set; }

        /// <summary>
        /// The game mode (Legal values: CLASSIC, ODIN, ARAM, TUTORIAL, ONEFORALL, ASCENSION, FIRSTBLOOD, KINGPORO)
        /// </summary>
        [JsonConverter(typeof(GameModeTypeJsonConverter))]
        [JsonProperty("gameMode")]
        public RiotApi.Commons.Enums.GameModeType GameMode { get; set; }

        /// <summary>
        /// The queue type (queue types are documented on the Game Constants page)
        /// </summary>
        [JsonConverter(typeof(GameQueueTypeJsonConverter))]
        [JsonProperty("gameQueueConfigId")]
        public RiotApi.Commons.Enums.GameQueueType GameQueueConfigId { get; set; }

        /// <summary>
        /// The game start time represented in epoch milliseconds
        /// </summary>
        [JsonProperty("gameStartTime")]
        public long GameStartTime { get; set; }

        /// <summary>
        /// The game type (Legal values: CUSTOM_GAME, MATCHED_GAME, TUTORIAL_GAME)
        /// </summary>
        [JsonConverter(typeof(GameTypeJsonConverter))]
        [JsonProperty("gameType")]
        public RiotApi.Commons.Enums.GameType GameType { get; set; }

        /// <summary>
        /// The ID of the map
        /// </summary>
        [JsonConverter(typeof(MapTypeJsonConverter))]
        [JsonProperty("mapId")]
        public RiotApi.Commons.Enums.MapType MapId { get; set; }

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
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonConverter(typeof(PlatformJsonConverter))]
        [JsonProperty("platformId")]
        public RiotApi.Commons.Enums.Platform PlatformId { get; set; }
    }
}
