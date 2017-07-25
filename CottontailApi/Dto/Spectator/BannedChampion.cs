using Newtonsoft.Json;

namespace CottontailApi.Dto.Spectator
{
    /// <summary>
    /// 
    /// </summary>
    public class BannedChampion
    {
        /// <summary>
        /// The turn during which the champion was banned
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        /// <summary>
        /// The ID of the banned champion
        /// </summary>
        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// The ID of the team that banned the champion
        /// </summary>
        [JsonProperty("teamId")]
        public long TeamId { get; set; }
    }
}
