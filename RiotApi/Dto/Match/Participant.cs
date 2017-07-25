using Newtonsoft.Json;
using RiotApi.Commons.CustomJsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Dto.Match
{
    /// <summary>
    /// Class representing a participant in a match (Match API).
    /// </summary>
    [Serializable]
    public class Participant
    {
        internal Participant() { }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// List of mastery information.
        /// </summary>
        [JsonProperty("masteries")]
        public List<Mastery> Masteries { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// List of rune information.
        /// </summary>
        [JsonProperty("runes")]
        public List<Rune> Runes { get; set; }

        /// <summary>
        /// First summoner spell ID.
        /// </summary>
        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }

        /// <summary>
        /// Second summoner spell ID.
        /// </summary>
        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        /// <summary>
        /// Participant statistics.
        /// </summary>
        [JsonProperty("stats")]
        public ParticipantStats Stats { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Timeline data. Delta fields refer to values for the specified period (e.g., the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game. Diffs fields refer to the deltas versus the calculated lane opponent(s).
        /// </summary>
        [JsonProperty("timeline")]
        public ParticipantTimeline Timeline { get; set; }

        /// <summary>
        /// Highest ranked tier achieved for the previous season, if any, otherwise null. Used to display border in game loading screen. (Legal values: CHALLENGER, MASTER, DIAMOND, PLATINUM, GOLD, SILVER, BRONZE, UNRANKED)
        /// </summary>
        [JsonProperty("highestAchievedSeasonTier")]
        [JsonConverter(typeof(TierTypeJsonConverter))]
        public RiotApi.Commons.Enums.TierType HighestAchievedSeasonTier { get; set; }
    }
}
