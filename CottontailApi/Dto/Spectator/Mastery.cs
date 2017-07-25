using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Spectator
{
    /// <summary>
    /// Class representing a mastery of a participant (Match API).
    /// </summary>
    public class Mastery
    {
        /// <summary>
        /// Mastery ID.
        /// </summary>
        [JsonProperty("masteryId")]
        public long MasteryId { get; set; }

        /// <summary>
        /// Mastery rank.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
