using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Game
{
    /// <summary>
    /// This object contains recent games information.
    /// </summary>
    public class RecentGamesDto
    {
        /// <summary>
        /// Collection of recent games played (max 10).
        /// </summary>
        [JsonProperty("games")]
        public List<GameDto> Games{get;set;}

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
