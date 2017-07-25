using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class ItemListDto
    {
        /// <summary>
        /// Basic data about the items retrieved.
        /// </summary>
        [JsonProperty("basic")]
        public BasicDataDto Basic { get; set; }

        /// <summary>
        /// Map of items indexed by their id.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, ItemDto> Data { get; set; }

        /// <summary>
        /// Information about the groups of an item.
        /// </summary>
        [JsonProperty("groups")]
        public List<GroupDto> Groups { get; set; }

        /// <summary>
        /// Items' tree (Tools, Defense, Attack, Magic, Movement).
        /// </summary>
        [JsonProperty("tree")]
        public List<ItemTreeDto> Tree { get; set; }

        /// <summary>
        /// API type (item).
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
