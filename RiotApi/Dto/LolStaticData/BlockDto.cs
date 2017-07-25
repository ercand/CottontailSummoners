using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class BlockDto
    {
        /// <summary>
        /// List of recommended items.
        /// </summary>
        [JsonProperty("items")]
        public List<BlockItemDto> Items { get; set; }

        /// <summary>
        /// Rec math.
        /// </summary>
        [JsonProperty("recMath")]
        public bool RecMath { get; set; }

        /// <summary>
        /// Type of items (starting, essential, offensive, etc).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
