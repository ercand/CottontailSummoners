using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.StaticData
{
    public class ProfileIconDataDto
    {
        [JsonProperty("data")]
        public Dictionary<string, IconDataDto> Data { get; set; }

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
