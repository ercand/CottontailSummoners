using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons.CustomJsonConverter;

namespace CottontailApi.Dto.League
{
    /// <summary>
    /// This object contains league participant information representing a summoner or team.
    /// </summary>
    public class LeaguePositionDto
    {
        /// <summary>
        /// The league division of the participant.
        /// </summary>
        [JsonProperty("rank")]
        public string Rank { get; set; }

        /// <summary>
        /// The league's queue type. (Legal values: RANKED_SOLO_5x5, RANKED_TEAM_3x3, RANKED_TEAM_5x5)
        /// </summary>
        [JsonProperty("queueType")]
        [JsonConverter(typeof(LeagueQueueTypeJsonConverter))]
        public CottontailApi.Commons.Enums.LeagueQueueType QueueType { get; set; }

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
        /// The league division of the participant.
        /// </summary>
        [JsonProperty("leagueName")]
        public string LeagueName { get; set; }

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
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierTypeJsonConverter))]
        public CottontailApi.Commons.Enums.TierType Tier { get; set; }
        
        /// <summary>
        /// The league points of the participant.
        /// </summary>
        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }
    }
}
