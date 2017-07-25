using Newtonsoft.Json;

namespace RiotApi.Dto.FeaturedGames
{
    /// <summary>
    /// 
    /// </summary>
    public class Observer
    {
        /// <summary>
        /// Key used to decrypt the spectator grid game data for playback
        /// </summary>
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}
