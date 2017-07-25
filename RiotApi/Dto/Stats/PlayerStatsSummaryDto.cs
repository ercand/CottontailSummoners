using Newtonsoft.Json;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Stats
{
    /// <summary>
    /// This object contains player stats summary information.
    /// </summary>
    public class PlayerStatsSummaryDto
    {
        /// <summary>
        /// Aggregated stats.
        /// </summary>
        [JsonProperty("aggregatedStats")]
        public AggregatedStatsDto AggregatedStats { get; set; }

        /// <summary>
        /// Number of losses for this queue type. Returned for ranked queue types only.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Date stats were last modified specified as epoch milliseconds.
        /// </summary>
        [JsonProperty("modifyDate")]
        public long ModifyDate { get; set; }

        /// <summary>
        /// Player stats summary type.
        /// </summary>
        [JsonProperty("playerStatSummaryType")]
        [JsonConverter(typeof(PlayerStatsSummaryTypeJsonConverter))]
        public RiotApi.Commons.Enums.PlayerStatsSummaryType PlayerStatSummaryType { get; set; }

        /// <summary>
        /// Number of wins for this queue type.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
