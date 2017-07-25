using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Team
{
    public class TeamDto
    {
        /// <summary>
        /// Date of the team creation.
        /// </summary>
        [JsonProperty("createDate")]
        public long CreateDate { get; set; }

        /// <summary>
        /// Team id.
        /// </summary>
        [JsonProperty("fullId")]
        public string FullId { get; set; }

        /// <summary>
        /// Date of the last game.
        /// </summary>
        [JsonProperty("lastGameDate")]
        public long LastGameDate { get; set; }

        /// <summary>
        /// Date when the last member joined the team.
        /// </summary>
        [JsonProperty("lastJoinDate")]
        public long LastJoinDate { get; set; }

        /// <summary>
        /// Date when the team last joined their queue.
        /// </summary>
        [JsonProperty("lastJoinedRankedTeamQueueDate")]
        public long LastJoinedRankedTeamQueueDate { get; set; }

        /// <summary>
        /// Match history.
        /// </summary>
        [JsonProperty("matchHistory")]
        public List<MatchHistorySummaryDto> MatchHistory { get; set; }

        /// <summary>
        /// Last time the team was modified.
        /// </summary>
        [JsonProperty("modifyDate")]
        public long ModifyDate { get; set; }

        /// <summary>
        /// Name of the team.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Roster of the team.
        /// </summary>
        [JsonProperty("roster")]
        public RosterDto Roster { get; set; }

        /// <summary>
        /// Date when the second last member joined the team..
        /// </summary>
        [JsonProperty("secondLastJoinDate")]
        public long SecondLastJoinDate { get; set; }

        /// <summary>
        /// Status of the team.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Tag of the team.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Stat summary of the team.
        /// </summary>
        [JsonProperty("teamStatDetails")]
        public List<TeamStatDetailDto> TeamStatDetails { get; set; }

        /// <summary>
        /// Date when the third last member joined the team.
        /// </summary>
        [JsonProperty("thirdLastJoinDate")]
        public long ThirdLastJoinDate { get; set; }
    }
}
