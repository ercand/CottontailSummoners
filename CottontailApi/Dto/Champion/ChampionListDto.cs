using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Champion
{
    /// <summary>
    /// This object contains a collection of champion information.
    /// </summary>
    public class ChampionListDto
    {
        /// <summary>
        /// The collection of champion information
        /// </summary>
        [JsonProperty("champions")]
        public List<ChampionDto> Champions { get; set; }
    }
}
