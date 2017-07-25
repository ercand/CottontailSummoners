using Newtonsoft.Json;

namespace CottontailApi.Dto.Spectator
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
