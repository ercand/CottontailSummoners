using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Team
{
    /// <summary>
    /// Information about team members (Team API).
    /// </summary>
    public class TeamMemberInfo
    {
        /// <summary>
        /// Date this team member was invited.
        /// </summary>
        [JsonProperty("inviteDate")]
        public long InviteDate { get; set; }

        /// <summary>
        /// Date this team member joined the team.
        /// </summary>
        [JsonProperty("joinDate")]
        public long JoinDate { get; set; }

        /// <summary>
        /// Id of the team member.
        /// </summary>
        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        /// <summary>
        /// Status of the team member (owner, member, etc).
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
