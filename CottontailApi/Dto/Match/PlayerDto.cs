using CottontailApi.Commons;
using CottontailApi.Commons.CustomJsonConverter;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    /// <summary>
    /// Player in a match (Match API).
    /// </summary>
    public class PlayerDto
    {
        // TODO: currentPlatformid certe volte ritorna "NA" e altre volte "NA1" possibile bug da controllare in futuro. Se corretto sostituire con Enums.Platform
        /*
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currentPlatformId")]
        [JsonConverter(typeof(PlatformJsonConverter))]
        public Enums.Platform CurrentPlatformId { get; set; }
        */
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currentPlatformId")]
        public string CurrentPlatformId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// Match history URI.
        /// </summary>
        [JsonProperty("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currentAccountId")]
        public long CurrentAccountId { get; set; }

        /// <summary>
        /// Profile icon ID.
        /// </summary>
        [JsonProperty("profileIcon")]
        public int ProfileIcon { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("accountId")]
        public long AccountId { get; set; }

    }
}
