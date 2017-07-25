using Newtonsoft.Json;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Match
{
    public class MatchDetail
    {
        /// <summary>
        /// Team information.
        /// </summary>
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; }

        /// <summary>
        /// Match timeline data. Not included by default.
        /// </summary>
        [JsonProperty("timeline")]
        public Timeline Timeline { get; set; }

        /// <summary>
        /// Map type.
        /// </summary>
        [JsonProperty("mapId")]
        [JsonConverter(typeof(MapTypeJsonConverter))]
        public RiotApi.Commons.Enums.MapType MapType { get; set; }

        /// <summary>
        /// Match creation time. Designates when the team select lobby is created and/or the match is made through
        /// match making, not when the game actually starts.
        /// </summary>
        [JsonProperty("matchCreation")]
        public long MatchCreation { get; set; }

        /// <summary>
        /// Match duration.
        /// </summary>
        [JsonProperty("matchDuration")]
        public long MatchDuration { get; set; }

        /// <summary>
        /// Match ID.
        /// </summary>
        [JsonProperty("matchId")]
        public long MatchId { get; set; }

        /// <summary>
        /// Match mode.
        /// </summary>
        [JsonProperty("matchMode")]
        [JsonConverter(typeof(GameModeTypeJsonConverter))]
        public RiotApi.Commons.Enums.GameModeType MatchMode { get; set; }

        [JsonProperty("matchType")]
        [JsonConverter(typeof(GameTypeJsonConverter))]
        public RiotApi.Commons.Enums.GameType MatchType { get; set; }

        /// <summary>
        /// Match version.
        /// </summary>
        [JsonProperty("matchVersion")]
        public string MatchVersion { get; set; }

        /// <summary>
        /// Participants identity information.
        /// </summary>
        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        /// <summary>
        /// Participants information
        /// </summary>
        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Match queue type.
        /// </summary>
        [JsonProperty("queueType")]
        [JsonConverter(typeof(GameQueueTypeJsonConverter))]
        public RiotApi.Commons.Enums.GameQueueType QueueType { get; set; }

        /// <summary>
        /// Region where the match was played.
        /// </summary>
        [JsonProperty("region")]
        [JsonConverter(typeof(RegionJsonConverter))]
        public RiotApi.Commons.Enums.Region Region { get; set; }

        /// <summary>
        /// Season match was played.
        /// </summary>
        [JsonProperty("season")]
        [JsonConverter(typeof(SeasonTypeJsonConverter))]
        public RiotApi.Commons.Enums.SeasonType Season { get; set; }
    }
}
