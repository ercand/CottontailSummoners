using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Dto.StaticData
{
    public class RuneListDto
    {
        /// <summary>
        /// Map of runes indexed by their id.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, RuneDto> Data { get; set; }

        /// <summary>
        /// API type (rune).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
