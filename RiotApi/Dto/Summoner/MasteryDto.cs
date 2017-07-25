using Newtonsoft.Json;

namespace RiotApi.Dto.Summoner
{
    /// <summary>
    /// 
    /// </summary>
    public class MasteryDto
    {
        /// <summary>
        /// Mastery id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Mastery rank (i.e. the number of points put into this mastery).
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
