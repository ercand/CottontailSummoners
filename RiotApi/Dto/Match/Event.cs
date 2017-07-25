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
    /// Class representing a particular event during a match (Match API).
    /// </summary>
    [Serializable]
    public class Event
    {
        /// <summary>
        /// The ascended type of the event. Only present if relevant.
        /// Note that CLEAR_ASCENDED refers to when a participants kills the ascended player.
        /// </summary>
        [JsonProperty("ascendedType")]
        [JsonConverter(typeof(AscendedTypeJsonConverter))]
        public RiotApi.Commons.Enums.AscendedType AscendedType { get; set; }

        /// <summary>
        /// The assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("assistingParticipantIds")]
        public List<int> AssistingParticipantIds { get; set; }

        /// <summary>
        /// The building type of the event (tower or inhibitor). Only present if relevant.
        /// </summary>
        [JsonProperty("buildingType")]
        [JsonConverter(typeof(BuildingTypeJsonConverter))]
        public RiotApi.Commons.Enums.BuildingType? BuildingType { get; set; }

        /// <summary>
        /// The creator ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("creatorId")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Event type (building kills, champion kills, ward placements, items purchases, etc).
        /// </summary>
        [JsonProperty("eventType")]
        [JsonConverter(typeof(EventTypeJsonConverter))]
        public RiotApi.Commons.Enums.EventType? EventType { get; set; }

        /// <summary>
        /// The ending item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemAfter")]
        public int ItemAfter { get; set; }

        /// <summary>
        /// The starting item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemBefore")]
        public int ItemBefore { get; set; }

        /// <summary>
        /// The item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// The killer ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("killerId")]
        public int KillerId { get; set; }

        /// <summary>
        /// The lane type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("laneType")]
        [JsonConverter(typeof(LaneTypeJsonConverter))]
        public RiotApi.Commons.Enums.LaneType? LaneType { get; set; }

        /// <summary>
        /// The level up type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("levelUpType")]
        [JsonConverter(typeof(LevelUpTypeJsonConverter))]
        public RiotApi.Commons.Enums.LevelUpType? LevelUpType { get; set; }

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("monsterType")]
        [JsonConverter(typeof(MonsterTypeJsonConverter))]
        public RiotApi.Commons.Enums.MonsterType? MonsterType { get; set; }

        /// <summary>
        /// The participant ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// The point captured in the event. Only present if relevant.
        /// </summary>
        [JsonProperty("pointCaptured")]
        [JsonConverter(typeof(CapturePointJsonConverter))]
        public RiotApi.Commons.Enums.CapturePoint PointCaptured { get; set; }

        /// <summary>
        /// The position of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The skill slot of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("skillSlot")]
        public int SkillSlot { get; set; }

        /// <summary>
        /// The team ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Represents how much time into the game the event occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// The tower type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("towerType")]
        [JsonConverter(typeof(TowerTypeJsonConverter))]
        public RiotApi.Commons.Enums.TowerType? TowerType { get; set; }

        /// <summary>
        /// The victim ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("victimId")]
        public int VictimId { get; set; }

        /// <summary>
        /// The ward type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("onsterType")]
        [JsonConverter(typeof(WardTypeJsonConverter))]
        public RiotApi.Commons.Enums.WardType? WardType { get; set; }
    }
}
