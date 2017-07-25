using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class MatchFrameDto
    {
        /// <summary>
        /// Represents how much time into the game the frame occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Map of each participant ID to the participant's information for the frame.
        /// </summary>
        [JsonProperty("participantFrames")]
        public Dictionary<int, MatchParticipantFrameDto> ParticipantFrames { get; set; }

        /// <summary>
        /// List of events for this frame.
        /// </summary>
        [JsonProperty("events")]
        public List<MatchEventDto> Events { get; set; }
    }
}
