using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Team
{
    /// <summary>
    /// Team stats (Team API).
    /// </summary>
    public class TeamStatDetailDto
    {
        /// <summary>
        /// Number of games played on average.
        /// </summary>
        [JsonProperty("averageGamesPlayed")]
        public int AverageGamesPlayed { get; set; }

        /// <summary>
        /// Number of losses.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Type of team stat.
        /// </summary>
        [JsonProperty("teamStatType")]
        public string TeamStatType { get; set; }

        /// <summary>
        /// Number of wins.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
