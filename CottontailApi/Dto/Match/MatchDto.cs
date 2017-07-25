using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;
using CottontailApi.Commons.CustomJsonConverter;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class MatchDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentityDto> ParticipantIdentities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("platformId")]
        [JsonConverter(typeof(PlatformJsonConverter))]
        public Enums.Platform PlatformId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gameMode")]
        [JsonConverter(typeof(GameModeTypeJsonConverter))]
        public Enums.GameModeType GameMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("gameType")]
        [JsonConverter(typeof(GameTypeJsonConverter))]
        public Enums.GameType GameType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("teams")]
        public List<TeamStatsDto> Teams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("participants")]
        public List<ParticipantDto> Participants { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gameDuration")]
        public long GameDuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gameCreation")]
        public long GameCreation { get; set; }
    }
}
