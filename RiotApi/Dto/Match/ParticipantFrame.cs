﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Match
{
    /// <summary>
    /// This object contains participant frame information
    /// </summary>
    public class ParticipantFrame
    {
        /// <summary>
        /// Participant's current gold
        /// </summary>
        [JsonProperty("currentGold")]
        public int CurrentGold { get; set; }

        /// <summary>
        /// Dominion score of the participant
        /// </summary>
        [JsonProperty("dominionScore")]
        public int DominionScore { get; set; }

        /// <summary>
        /// Number of jungle minions killed by participant
        /// </summary>
        [JsonProperty("jungleMinionsKilled")]
        public int JungleMinionsKilled { get; set; }
        
        /// <summary>
        /// Participant's current level
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }
        
        /// <summary>
        /// Number of minions killed by participant
        /// </summary>
        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }
        
        /// <summary>
        /// Participant ID
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }
        
        /// <summary>
        /// Participant's position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Team score of the participant
        /// </summary>
        [JsonProperty("teamScore")]
        public int TeamScore { get; set; }

        /// <summary>
        /// Participant's total gold
        /// </summary>
        [JsonProperty("totalGold")]
        public int TotalGold { get; set; }

        /// <summary>
        /// Experience earned by participant
        /// </summary>
        [JsonProperty("xp")]
        public int Xp { get; set; }
    }
}
