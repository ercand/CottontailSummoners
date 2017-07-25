using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Stats
{
    /// <summary>
    /// This object contains ranked stats information.
    /// </summary>
    public class RankedStatsDto
    {
        /// <summary>
        /// Collection of aggregated stats summarized by champion.
        /// </summary>
        [JsonProperty("champions")]
        public List<ChampionStatsDto> Champions { get; set; }

        /// <summary>
        /// Date stats were last modified specified as epoch milliseconds.
        /// </summary>
        [JsonProperty("modifyDate")]
        public long ModifyDate { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
