using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotApi.Dto.Summoner
{
    /// <summary>
    /// 
    /// </summary>
    public class MasteryPageDto
    {
        /// <summary>
        /// Indicates if the mastery page is the current mastery page.
        /// </summary>
        [JsonProperty("current")]
        public bool Current { get; set; }

        /// <summary>
        /// Mastery page id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Mastery page name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of mastery page talents associated with the mastery page.
        /// </summary>
        [JsonProperty("masteries")]
        public List<MasteryDto> Masteries { get; set; }
    }
}
