using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class MasteryListDto
    {
        /// <summary>
        /// Map of masteries indexed by their id.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, MasteryDto> Data { get; set; }

        /// <summary>
        /// Tree of masteries.
        /// </summary>
        [JsonProperty("tree")]
        public MasteryTreeDto Tree { get; set; }

        /// <summary>
        /// API type (mastery).
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
