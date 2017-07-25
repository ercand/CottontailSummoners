using Newtonsoft.Json;

namespace RiotApi.Dto.Match
{
    /// <summary>
    /// Class representing a rune of a participant (Match API).
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// Rune rank.
        /// </summary>
        [JsonProperty("rank")]
        public long Rank { get; set; }

        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("runeId")]
        public long RuneId { get; set; }
    }
}
