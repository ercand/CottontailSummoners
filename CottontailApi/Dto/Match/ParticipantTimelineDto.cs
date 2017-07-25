using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class ParticipantTimelineDto
    {
        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("csDiffPerMinDeltas")]
        public Dictionary<string, float> CsDiffPerMinDeltas { get; set; }

        [JsonProperty("goldPerMinDeltas")]
        public Dictionary<string, float> GoldPerMinDeltas { get; set; }

        [JsonProperty("xpDiffPerMinDeltas")]
        public Dictionary<string, float> XpDiffPerMinDeltas { get; set; }

        [JsonProperty("creepsPerMinDeltas")]
        public Dictionary<string, float> CreepsPerMinDeltas { get; set; }

        [JsonProperty("xpPerMinDeltas")]
        public Dictionary<string, float> XpPerMinDeltas { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("damageTakenDiffPerMinDeltas")]
        public Dictionary<string, float> DamageTakenDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenPerMinDeltas")]
        public Dictionary<string, float> DamageTakenPerMinDeltas { get; set; }
    }
}
