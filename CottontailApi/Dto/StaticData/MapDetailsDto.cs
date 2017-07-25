using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.StaticData
{
    public class MapDetailsDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapName")]
        public string MapName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapId")]
        public long MapId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("unpurchasableItemList")]
        public List<long> UnpurchasableItemList { get; set; }
    }
}
