using Newtonsoft.Json;

namespace CottontailApi.Dto.Spectator
{
    /// <summary>
    /// Class representing a rune of a participant (Match API).
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("runeId")]
        public long RuneId { get; set; }
        /// <summary>
        /// Rune rank.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
