using Newtonsoft.Json;
using System.Collections.Generic;

namespace CottontailApi.Dto.Runes
{
    /// <summary>
    /// 
    /// </summary>
    public class RunePagesDto
    {
        /// <summary>
        /// List of RunePages.
        /// </summary>
        [JsonProperty("pages")]
        public List<RunePageDto> Pages { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
