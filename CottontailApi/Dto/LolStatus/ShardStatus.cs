using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.LolStatus
{
    public class ShardStatus
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region_tag")]
        public string Region_tag { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("locales")]
        public List<string> Locales { get; set; }
    }
}
