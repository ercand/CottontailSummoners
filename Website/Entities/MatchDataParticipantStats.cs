using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class MatchDataParticipantStats
    {
        public MatchDataParticipantStats()
        {
        }

        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Participant ID
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Champion level achieved
        /// </summary>
        public int ChampionLevel { get; set; }

        /// <summary>
        /// If game was a dominion game, player's combat score, otherwise 0
        /// </summary>
        public int CombatPlayerScore { get; set; }

        

        /// <summary>
        /// Number of double kills
        /// </summary>
        public int DoubleKills { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on first blood
        /// </summary>
        public bool FirstBloodAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first blood
        /// </summary>
        public bool FirstBloodKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on the first inhibitor
        /// </summary>
        public bool FirstInhibitorAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant destroyed the first inhibitor
        /// </summary>
        public bool FirstInhibitorKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on the first tower
        /// </summary>
        public bool FirstTowerAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant destroyed the first tower
        /// </summary>
        public bool FirstTowerKill { get; set; }
        public int GoldSpent { get; set; }
        public int InhibitorKills { get; set; }
        public int KillingSprees { get; set; }
        public int LargestCriticalStrike { get; set; }
        public int LargestKillingSpree { get; set; }
        public int LargestMultiKill { get; set; }
        public int MagicDamageDealt { get; set; }
        public int MagicDamageDealtToChampions { get; set; }
        public int MagicDamageTaken { get; set; }
        
        public int NodeCapture { get; set; }
        public int NodeCaptureAssist { get; set; }
        public int NodeNeutralize { get; set; }
        public int NodeNeutralizeAssist { get; set; }
        public int ObjectivePlayerScore { get; set; }
        public int PentaKills { get; set; }
        public int PhysicalDamageDealt { get; set; }
        public int PhysicalDamageDealtToChampions { get; set; }
        public int PhysicalDamageTaken { get; set; }
        public int QuadraKills { get; set; }
        public int SightWardsBoughtInGame { get; set; }
        public int TeamObjective { get; set; }
        public int TotalDamageDealt { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int TotalPlayerScore { get; set; }
        public int TotalScoreRank { get; set; }
        public int TotalTimeCrowdControlDealt { get; set; }
        public int TotalUnitsHealed { get; set; }
        public int TowerKills { get; set; }
        public int TripleKills { get; set; }
        public int TrueDamageDealt { get; set; }
        public int TrueDamageDealtToChampions { get; set; }
        public int TrueDamageTaken { get; set; }
        public int UnrealKills { get; set; }
        public int VisionWardsBoughtInGame { get; set; }
        public int WardsKilled { get; set; }
        public int WardsPlaced { get; set; }
        public int TimeCCingOthers { get; set; }

        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public long FK_MatchDataID { get; set; }

        [ForeignKey("FK_MatchDataID")]
        public virtual MatchData MatchData { get; set; }
    }
}