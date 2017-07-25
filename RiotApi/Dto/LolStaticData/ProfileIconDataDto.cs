using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotApi.Dto.LolStaticData
{
    public class ProfileIconDataDto
    {
        [JsonProperty("data")]
        public Dictionary<string, IconDataDto> Data { get; set; }
    }
}
