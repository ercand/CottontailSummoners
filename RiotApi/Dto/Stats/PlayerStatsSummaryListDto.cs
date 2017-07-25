using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Stats
{
    /// <summary>
    /// This object contains a collection of player stats summary information.
    /// </summary>
    public class PlayerStatsSummaryListDto
    {
        /// <summary>
        /// Collection of player stats summaries associated with the summoner.
        /// </summary>
        [JsonProperty("playerStatSummaries")]
        public List<PlayerStatsSummaryDto> PlayerStatSummaries { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
