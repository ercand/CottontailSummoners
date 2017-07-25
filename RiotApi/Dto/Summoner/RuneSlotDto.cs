using Newtonsoft.Json;

namespace RiotApi.Dto.Summoner
{
    /// <summary>
    /// 
    /// </summary>
    public class RuneSlotDto
    {
        /// <summary>
        /// Rune ID associated with the rune slot. For static information correlating to rune IDs, please refer to the LoL Static Data API.
        /// </summary>
        [JsonProperty("runeId")]
        public int RuneId { get; set; }

        /// <summary>
        /// <para>Rune slot ID.</para>
        /// </summary>
        [JsonProperty("runeSlotId")]
        public int RuneSlotId { get; set; }
    }
}
