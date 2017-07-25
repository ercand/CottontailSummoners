using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.Dto.StaticData
{
    public class SpellVarsDto
    {
        /// <summary>
        /// Coeff for this summoner spell for the summoner's level.
        /// </summary>
        [JsonProperty("coeff")]
        public List<double> Coeff { get; set; }

        /// <summary>
        /// Seems to always be equal to + when it is present.
        /// </summary>
        [JsonProperty("dyn")]
        public string Dyn { get; set; }

        /// <summary>
        /// Key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Link.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// Ranks with.
        /// </summary>
        [JsonProperty("ranksWith")]
        public string RanksWith { get; set; }
    }
}
