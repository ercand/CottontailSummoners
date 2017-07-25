using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class MatchDataParticipant
    {
        public MatchDataParticipant()
        {
            RuneCode = "";
            MasteryCode = "";
        }

        [Key]
        public long ID { get; set; }

        public long RiotSummonerID { get; set; }
        public long RiotAccountID { get; set; }
        public int ChampionId { get; set; }

        /// <summary>
        /// Participant ID
        /// </summary>
        public int ParticipantId { get; set; }

        public string Role { get; set; }
        public string Lane{ get; set; }

        /// <summary>
        /// First summoner spell ID
        /// </summary>
        public int Spell1Id { get; set; }

        /// <summary>
        /// Second summoner spell ID
        /// </summary>
        public int Spell2Id { get; set; }

        /// <summary>
        /// Team ID
        /// </summary>
        public int TeamId { get; set; }

        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }
        public int Item6 { get; set; }

        public int GoldEarned { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public bool Winner { get; set; }

        /// <summary>
        /// Minion killed in lane
        /// </summary>
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Total minion killed in jungle(team and enemy jungle)
        /// </summary>
        public int NeutralMinionsKilled { get; set; }
        public int NeutralMinionsKilledEnemyJungle { get; set; }
        public int NeutralMinionsKilledTeamJungle { get; set; }
        public string RuneCode { get; set; }
        public string MasteryCode { get; set; }

        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public long FK_MatchDataID { get; set; }

        [ForeignKey("FK_MatchDataID")]
        public virtual MatchData MatchData { get; set; }
    }
    /*
     
highestAchievedSeasonTier	string	Highest ranked tier achieved for the previous season, if any, otherwise null. Used to display border in game loading screen. (Legal values: CHALLENGER, MASTER, DIAMOND, PLATINUM, GOLD, SILVER, BRONZE, UNRANKED)
masteries	List[Mastery]	List of mastery information

runes	List[Rune]	List of rune information

stats	ParticipantStats	Participant statistics

timeline	ParticipantTimeline	Timeline data. Delta fields refer to values for the specified period (e.g., the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game. Diffs fields refer to the deltas versus the calculated lane opponent(s). 
     */
}