using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotApi.Dto.Champion
{
    public class ChampionListDto
    {
        /// <summary>
        /// List of Champions.
        /// </summary>
        [JsonProperty("champions")]
        public List<ChampionDto> Champions { get; set; }
    }
}
