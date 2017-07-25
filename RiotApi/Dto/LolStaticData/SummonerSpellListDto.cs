using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStaticData
{
    public class SummonerSpellListDto
    {
        /// <summary>
        /// Map of summoner spells indexed by their name.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, SummonerSpellDto> SummonerSpells { get; set; }

        /// <summary>
        /// API type (summoner).
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
