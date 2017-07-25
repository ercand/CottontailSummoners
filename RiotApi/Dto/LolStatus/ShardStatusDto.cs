using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Commons.CustomJsonConverter;
using System.Collections.Generic;

namespace RiotApi.Dto.LolStatus
{
    /// <summary>
    /// 
    /// </summary>
    public class ShardStatusDto
    {
        /// <summary>
        /// Hostname of the shard.
        /// </summary>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// List of locales supported by this shard.
        /// </summary>
        [JsonProperty("locales")]
        public List<Enums.Language> Locales { get; set; }

        /// <summary>
        /// Name of the region the shard is handling.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tag of the region the shard is handling.
        /// </summary>
        [JsonProperty("region_tag")]
        public string RegionTag { get; set; }

        /// <summary>
        /// List of services for this shard.
        /// </summary>
        [JsonProperty("services")]
        public List<ServiceDto> Services { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonProperty("slug")]
        [JsonConverter(typeof(RegionJsonConverter))]
        public Enums.Region Slug { get; set; }

    }
}
