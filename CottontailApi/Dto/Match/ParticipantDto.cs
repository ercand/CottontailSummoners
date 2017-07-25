using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class ParticipantDto
    {
        [JsonProperty("stats")]
        public ParticipantStatsDto Stats { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("runes")]
        public List<RuneDto> Runes { get; set; }

        [JsonProperty("timeline")]
        public ParticipantTimelineDto Timeline { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonProperty("masteries")]
        public List<MasteryDto> Masteries { get; set; }

        [JsonProperty("highestAchievedSeasonTier")]
        public string HighestAchievedSeasonTier { get; set; }

        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }
    }
}
