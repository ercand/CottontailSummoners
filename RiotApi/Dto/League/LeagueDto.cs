using Newtonsoft.Json;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.League
{
    /// <summary>
    /// This object contains league information.
    /// </summary>
    public class LeagueDto
    {
        /// <summary>
        /// The requested league entries.
        /// </summary>
        [JsonProperty("entries")]
        public List<LeagueEntryDto> Entries { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the relevant participant that is a member of this league (i.e., a requested summoner ID,
        /// a requested team ID, or the ID of a team to which one of the requested summoners belongs).
        /// Only present when full league is requested so that participant's entry can be identified.
        /// Not present when individual entry is requested.
        /// </summary>
        [JsonProperty("participantId")]
        public string ParticipantId { get; set; }

        /// <summary>
        /// The league's queue type. (Legal values: RANKED_SOLO_5x5, RANKED_TEAM_3x3, RANKED_TEAM_5x5)
        /// </summary>
        [JsonProperty("queue")]
        [JsonConverter(typeof(LeagueQueueTypeJsonConverter))]
        public RiotApi.Commons.Enums.LeagueQueueType Queue { get; set; }

        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierTypeJsonConverter))]
        public RiotApi.Commons.Enums.TierType Tier { get; set; }
    }
}
