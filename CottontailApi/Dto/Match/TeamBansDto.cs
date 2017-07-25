using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    /// <summary>
    /// This object contains information about banned champions
    /// </summary>
    public class TeamBansDto
    {
        /// <summary>
        /// Banned champion ID.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Turn during which the champion was banned.
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
    }
}
