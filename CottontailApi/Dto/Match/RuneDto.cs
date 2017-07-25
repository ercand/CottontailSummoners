using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    /// <summary>
    /// Class representing a rune of a participant (Match API).
    /// </summary>
    public class RuneDto
    {
        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("runeId")]
        public long RuneId { get; set; }
        /// <summary>
        /// Rune rank.
        /// </summary>
        [JsonProperty("rank")]
        public long Rank { get; set; }
    }
}
