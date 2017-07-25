using Newtonsoft.Json;

namespace RiotApi.Dto.Match
{
    /// <summary>
    /// This object contains participant frame position information
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Coordinate X of Partecipant.
        /// </summary>
        [JsonProperty("x")]
        public int X{get;set;}

        /// <summary>
        /// Coordinate Y of Partecipant.
        /// </summary>
        [JsonProperty("y")]
        public int Y{get;set;}
    }
}
