using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;
using Newtonsoft.Json;

namespace CottontailApi.Dto.Match
{
    public class MatchEventDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// The tower type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("towerType")]
        public string TowerType { get; set; }

        /// <summary>
        /// The team ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        
        /// <summary>
        /// The ascended type of the event. Only present if relevant.
        /// Note that CLEAR_ASCENDED refers to when a participants kills the ascended player.
        /// </summary>
        [JsonProperty("ascendedType")]
        public string AscendedType { get; set; }

        /// <summary>
        /// The killer ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("killerId")]
        public int KillerId { get; set; }

        /// <summary>
        /// The level up type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("levelUpType")]
        public string LevelUpType { get; set; }

        /// <summary>
        /// The point captured in the event. Only present if relevant.
        /// </summary>
        [JsonProperty("pointCaptured")]
        public string PointCaptured { get; set; }
        
        /// <summary>
        /// The assisting participant IDs of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("assistingParticipantIds")]
        public List<int> AssistingParticipantIds { get; set; }

        /// <summary>
        /// The ward type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("onsterType")]
        public string WardType { get; set; }

        /// <summary>
        /// The monster type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("monsterType")]
        public string MonsterType { get; set; }

        /// <summary>
        /// Legal values: CHAMPION_KILL, WARD_PLACED, WARD_KILL, BUILDING_KILL, ELITE_MONSTER_KILL, ITEM_PURCHASED, ITEM_SOLD, ITEM_DESTROYED, ITEM_UNDO, SKILL_LEVEL_UP, ASCENDED_EVENT, CAPTURE_POINT, PORO_KING_SUMMON
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The skill slot of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("skillSlot")]
        public int SkillSlot { get; set; }

        /// <summary>
        /// The victim ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("victimId")]
        public int VictimId { get; set; }

        /// <summary>
        /// Represents how much time into the game the event occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        
        /// <summary>
        /// The ending item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("afterId")]
        public int AfterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("monsterSubType")]
        public string MonsterSubType { get; set; }

        /// <summary>
        /// The lane type of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("laneType")]
        public string LaneType { get; set; }

        /// <summary>
        /// The item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// The participant ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }
        
        /// <summary>
        /// The building type of the event (tower or inhibitor). Only present if relevant.
        /// </summary>
        [JsonProperty("buildingType")]
        public string BuildingType { get; set; }
        /// <summary>
        /// The creator ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("creatorId")]
        public int CreatorId { get; set; }

        /// <summary>
        /// The position of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("position")]
        public MatchPositionDto Position { get; set; }
        
        /// <summary>
        /// The starting item ID of the event. Only present if relevant.
        /// </summary>
        [JsonProperty("beforeId")]
        public int BeforeId { get; set; }
    }
}
