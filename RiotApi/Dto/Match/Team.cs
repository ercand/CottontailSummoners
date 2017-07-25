using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Match
{
    /// <summary>
    /// Class representing a team in a match (Match API).
    /// </summary>
    public class Team
    {
        /// <summary>
        /// If game was draft mode, contains banned champion data, otherwise null.
        /// </summary>
        [JsonProperty("bans")]
        public List<BannedChampion> Bans { get; set; }

        /// <summary>
        /// Number of times the team killed baron.
        /// </summary>
        [JsonProperty("baronKills")]
        public int BaronKills { get; set; }

        /// <summary>
        /// If game was a dominion game, specifies the points the team had at game end, otherwise null.
        /// </summary>
        [JsonProperty("dominionVictoryScore")]
        public long DominionVictoryScore { get; set; }

        /// <summary>
        /// Number of times the team killed dragon.
        /// </summary>
        [JsonProperty("dragonKills")]
        public int DragonKills { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got the first baron kill.
        /// </summary>
        [JsonProperty("firstBaron")]
        public bool FirstBaron { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got first blood.
        /// </summary>
        [JsonProperty("firstBlood")]
        public bool FirstBlood { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got the first dragon kill.
        /// </summary>
        [JsonProperty("firstDragon")]
        public bool FirstDragon { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team destroyed the first inhibitor.
        /// </summary>
        [JsonProperty("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team got the first rift herald kill
        /// </summary>
        [JsonProperty("firstRiftHerald")]
        public bool FirstRiftHerald { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team destroyed the first tower.
        /// </summary>
        [JsonProperty("firstTower")]
        public bool FirstTower { get; set; }

        /// <summary>
        /// Number of inhibitors the team destroyed.
        /// </summary>
        [JsonProperty("inhibitorKills")]
        public int InhibitorKills { get; set; }

        /// <summary>
        /// Number of times the team killed rift herald
        /// </summary>
        [JsonProperty("riftHeraldKills")]
        public int RiftHeraldKills { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Number of towers the team destroyed.
        /// </summary>
        [JsonProperty("towerKills")]
        public int TowerKills { get; set; }

        /// <summary>
        /// Number of times the team killed vilemaw.
        /// </summary>
        [JsonProperty("vilemawKills")]
        public int VilemawKills { get; set; }

        /// <summary>
        /// Flag indicating whether or not the team won.
        /// </summary>
        [JsonProperty("winner")]
        public bool Winner { get; set; }
    }
}
