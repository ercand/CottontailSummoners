using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class MatchlistDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("matches")]
        public List<MatchReferenceDto> Matches { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("totalGames")]
        public int TotalGames { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("endIndex")]
        public int EndIndex { get; set; }
    }
}
