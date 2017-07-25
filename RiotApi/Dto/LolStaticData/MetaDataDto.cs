using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class MetaDataDto
    {
        /// <summary>
        /// Whether this item is a rune or not.
        /// </summary>
        [JsonProperty("isRune")]
        public bool IsRune { get; set; }

        /// <summary>
        /// Tier of the rune.
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }

        /// <summary>
        /// Type of the rune.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
