using Newtonsoft.Json;
using RiotApi.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.LolStatus
{
    /// <summary>
    /// 
    /// </summary>
    public class TranslationDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Language in which the translation was done.
        /// </summary>
        [JsonProperty("locale")]
        public Enums.Language Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }
    }
}
