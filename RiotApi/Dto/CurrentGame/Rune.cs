using Newtonsoft.Json;

namespace RiotApi.Dto.CurrentGame
{
    /// <summary>
    /// 
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// The count of this rune used by the participant
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// The ID of the rune
        /// </summary>
        [JsonProperty("runeId")]
        public long RuneId { get; set; }
    }
}
