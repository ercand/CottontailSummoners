using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.LolStatus
{
    public class Service
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("incidents")]
        public List<Incident> Incidents { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
