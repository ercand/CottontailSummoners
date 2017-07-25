using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class MatchReferenceDto
    { 	 
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lane")]
        public string Lane { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("champion")]
        public int Champion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("platformId")]
        public  string PlatformId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("season")]
        public int Season { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("queue")]
        public int Queue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp  { get; set; }
    }
}
