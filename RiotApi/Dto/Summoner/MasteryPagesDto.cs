using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotApi.Dto.Summoner
{
    /// <summary>
    /// 
    /// </summary>
    public class MasteryPagesDto
    {
        /// <summary>
        /// List of MasteryPages.
        /// </summary>
        [JsonProperty("pages")]
        public List<MasteryPageDto> Pages { get; set; }

        /// <summary>
        /// Summoner ID to wich the pages belong.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
