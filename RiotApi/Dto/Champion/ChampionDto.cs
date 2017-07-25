using Newtonsoft.Json;
using System;

namespace RiotApi.Dto.Champion
{
    /// <summary>
    /// This object contains champion information.
    /// </summary>
    [Serializable]
    public class ChampionDto
    {
        /// <summary>
        /// Indicates if the champion is active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Bot enabled flag (for custom games).
        /// </summary>
        [JsonProperty("botEnabled")]
        public bool BotEnabled { get; set; }

        /// <summary>
        /// Bot Match Made enabled flag (for Co-op vs. AI games).
        /// </summary>
        [JsonProperty("botMmEnabled")]
        public bool BotMmEnabled { get; set; }

        /// <summary>
        /// Indicates if the champion is free to play. Free to play champions are rotated periodically.
        /// </summary>
        [JsonProperty("freeToPlay")]
        public bool FreeToPlay { get; set; }

        /// <summary>
        /// Champion ID. For static information correlating to champion IDs, please refer to the LoL Static Data API.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Ranked play enabled flag.
        /// </summary>
        [JsonProperty("rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; set; }
    }
}
