using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.LolStatus
{
    public class Message
    {
        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("created_at")]
        public string Created_at { get; set; }

        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }

        [JsonProperty("updated_at")]
        public string Updated_at { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
