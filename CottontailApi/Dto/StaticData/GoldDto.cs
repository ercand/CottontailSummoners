using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Dto.StaticData
{
    public class GoldDto
    {
        /// <summary>
        /// Base price of an item.
        /// </summary>
        [JsonProperty("base")]
        public int Base { get; set; }

        /// <summary>
        /// Whether an item is purchasable or not.
        /// </summary>
        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        /// <summary>
        /// Reselling price of an item.
        /// </summary>
        [JsonProperty("sell")]
        public int Sell { get; set; }

        /// <summary>
        /// Total price of an item.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
