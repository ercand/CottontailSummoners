using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotApi.Dto.Match
{
    /// <summary>
    /// Class representing a match's timeline (Match API).
    /// </summary>
    public class Timeline
    {
        /// <summary>
        /// Time between each returned frame.
        /// </summary>
        [JsonProperty("frameInterval")]
        public long FrameInterval { get; set; }

        /// <summary>
        /// List of timeline frames for the game.
        /// </summary>
        [JsonProperty("frames")]
        public List<Frame> Frames { get; set; }
    }
}
