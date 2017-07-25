using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons.CustomJsonConverter;
using Newtonsoft.Json;

namespace CottontailApi.Dto.League
{
    /// <summary>
    /// This object contains league information.
    /// </summary>
    public class LeagueListDto
    {
        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierTypeJsonConverter))]
        public CottontailApi.Commons.Enums.TierType Tier { get; set; }

        /// <summary>
        /// The league's queue type. (Legal values: RANKED_SOLO_5x5, RANKED_TEAM_3x3, RANKED_TEAM_5x5)
        /// </summary>
        [JsonProperty("queue")]
        [JsonConverter(typeof(LeagueQueueTypeJsonConverter))]
        public CottontailApi.Commons.Enums.LeagueQueueType Queue { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The requested league entries.
        /// </summary>
        [JsonProperty("entries")]
        public List<LeagueItemDto> Entries { get; set; }

    }
}
