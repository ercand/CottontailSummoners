using Newtonsoft.Json;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Matchlist
{
    /// <summary>
    /// This object contains match reference information
    /// </summary>
    public class MatchReference
    {
        /// <summary>
        /// The ID of the champion played during the match.
        /// </summary>
        [JsonProperty("champion")]
        public long ChampionID { get; set; }

        /// <summary>
        /// Participant's lane.
        /// </summary>
        [JsonProperty("lane")]
        [JsonConverter(typeof(LaneJsonConverter))]
        public RiotApi.Commons.Enums.Lane Lane { get; set; }

        /// <summary>
        /// The match ID relating to the match.
        /// </summary>
        [JsonProperty("matchId")]
        public long MatchID { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonProperty("platformId")]
        public string PlatformID { get; set; }

        /// <summary>
        /// Match queue type.
        /// </summary>
        [JsonProperty("queue")]
        [JsonConverter(typeof(LeagueQueueTypeJsonConverter))]
        public RiotApi.Commons.Enums.LeagueQueueType Queue { get; set; }

        /// <summary>
        /// Participant's role.
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(RoleJsonConverter))]
        public RiotApi.Commons.Enums.Role Role { get; set; }

        /// <summary>
        /// Season match was played.
        /// </summary>
        [JsonProperty("season")]
        [JsonConverter(typeof(SeasonTypeJsonConverter))]
        public RiotApi.Commons.Enums.SeasonType Season { get; set; }

        /// <summary>
        /// The date/time of which the game lobby was created.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

    }
}
