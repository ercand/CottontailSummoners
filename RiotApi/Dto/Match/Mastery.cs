using Newtonsoft.Json;

namespace RiotApi.Dto.Match
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
        public long Rank { get; set; }
    }
}
