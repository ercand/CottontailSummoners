using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Dto.StaticData
{
    public class ChampionListDto
    {
        /// <summary>
        /// Map of champions indexed by their name.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, ChampionDto> Champions { get; set; }

        /// <summary>
        /// Format of the data.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Map of the champions names indexed by their id.
        /// </summary>
        [JsonProperty("keys")]
        public Dictionary<string, string> Keys { get; set; }

        /// <summary>
        /// TAPI type (item).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API (should be cdn).
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
