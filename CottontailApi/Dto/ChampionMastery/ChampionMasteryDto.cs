﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.ChampionMastery
{
    /// <summary>
    /// This object contains single Champion Mastery information for player and champion combination.
    /// </summary>
    public class ChampionMasteryDto
    {
        /// <summary>
        /// Is chest granted for this champion or not in current season.
        /// </summary>
        [JsonProperty("chestGranted")]
        public bool ChestGranted { get; set; }

        /// <summary>
        /// Champion level for specified player and champion combination.
        /// </summary>
        [JsonProperty("championLevel")]
        public int ChampionLevel { get; set; }

        /// <summary>
        /// Total number of champion points for this player and champion combination - they are used to determine championLevel.
        /// </summary>
        [JsonProperty("championPoints")]
        public int ChampionPoints { get; set; }

        /// <summary>
        /// Champion ID for this entry.
        /// </summary>
        [JsonProperty("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// Player ID for this entry.
        /// </summary>
        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        /// <summary>
        /// Number of points needed to achieve next level. Zero if player reached maximum champion level for this champion.
        /// </summary>
        [JsonProperty("championPointsUntilNextLevel")]
        public long ChampionPointsUntilNextLevel { get; set; }

        /// <summary>
        /// Number of points earned since current level has been achieved. Zero if player reached maximum champion level for this champion.
        /// </summary>
        [JsonProperty("championPointsSinceLastLevel")]
        public long ChampionPointsSinceLastLevel { get; set; }

        /// <summary>
        /// Last time this champion was played by this player - in Unix milliseconds time format. 
        /// </summary>
        [JsonProperty("lastPlayTime")]
        public long LastPlayTime { get; set; }
    }
}
