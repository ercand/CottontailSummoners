using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotApi.Dto.LolStatus
{
    public class ServiceDto
    {
        /// <summary>
        /// List of incidents for this service.
        /// </summary>
        [JsonProperty("incidents")]
        public List<IncidentDto> Incidents { get; set; }

        /// <summary>
        /// Name of the service.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Legal values: Online, Alert, Offline, Deploying
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
