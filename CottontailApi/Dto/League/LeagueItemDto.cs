using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons.CustomJsonConverter;
using Newtonsoft.Json;

namespace CottontailApi.Dto.League
{
    /// <summary>
    /// 
    /// </summary>
    public class LeagueItemDto
    {
        /// <summary>
        /// The league division of the participant.
        /// </summary>
        [JsonProperty("rank")]
        public string Rank { get; set; }

        /// <summary>
        /// Specifies if the participant is on a hot streak.
        /// </summary>
        [JsonProperty("hotStreak")]
        public bool HotStreak { get; set; }

        /// <summary>
        /// Mini series data for the participant. Only present if the participant is currently in a mini series.
        /// </summary>
        [JsonProperty("miniSeries")]
        public MiniSeriesDto MiniSeries { get; set; }

        /// <summary>
        /// The number of wins for the participant.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// Specifies if the participant is a veteran.
        /// </summary>
        [JsonProperty("Veteran")]
        public bool Veteran { get; set; }

        /// <summary>
        /// The number of losses for the participant.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// The ID of the participant (i.e., summoner or team) represented by this entry.
        /// </summary>
        [JsonProperty("playerOrTeamId")]
        public string PlayerOrTeamId { get; set; }

        /// <summary>
        /// The name of the the participant (i.e., summoner or team) represented by this entry.
        /// </summary>
        [JsonProperty("playerOrTeamName")]
        public string PlayerOrTeamName { get; set; }

        /// <summary>
        /// Specifies if the participant is inactive.
        /// </summary>
        [JsonProperty("inactive")]
        public bool Inactive { get; set; }

        /// <summary>
        /// Specifies if the participant is fresh blood.
        /// </summary>
        [JsonProperty("freshBlood")]
        public bool FreshBlood { get; set; }

        /// <summary>
        /// The league points of the participant.
        /// </summary>
        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }
    }
}
