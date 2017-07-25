using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.LolStatus
{
    public class Incident
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public string Created_at { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("updates")]
        public List<Message> Updates { get; set; }
    }
}
