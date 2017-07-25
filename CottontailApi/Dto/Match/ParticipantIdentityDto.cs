using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class ParticipantIdentityDto
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("player")]
        public PlayerDto Player { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }
    }
}
