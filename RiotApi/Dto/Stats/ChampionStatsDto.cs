using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Stats
{
    /// <summary>
    /// Stats for all champions (Stats API).
    /// </summary>
    public class ChampionStatsDto
    {
        /// <summary>
        /// Champion ID. Note that champion ID 0 represents the combined stats for all champions.
        /// </summary>
        [JsonProperty("id")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Aggregated stats associated with the champion.
        /// </summary>
        [JsonProperty("stats")]
        public AggregatedStatsDto Stats { get; set; }
    }
}
