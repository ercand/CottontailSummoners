using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class MatchData
    {
        public MatchData()
        {
        }

        [Key]
        public long ID { get; set; }
        public long RiotMatchID { get; set; }
        public int MapID { get; set; }
        public long MatchCreation { get; set; }
        public long MatchDuration { get; set; }

        /// <summary>
        /// Match type (Legal values: CUSTOM_GAME, MATCHED_GAME, TUTORIAL_GAME)
        /// </summary>
        public string MatchMode { get; set; }
        public string MatchVersion { get; set; }

        /// <summary>
        /// Match queue type (Legal values: CUSTOM, NORMAL_5x5_BLIND, RANKED_SOLO_5x5, RANKED_PREMADE_5x5, BOT_5x5, NORMAL_3x3, RANKED_PREMADE_3x3, NORMAL_5x5_DRAFT, ODIN_5x5_BLIND, 
        /// ODIN_5x5_DRAFT, BOT_ODIN_5x5, BOT_5x5_INTRO, BOT_5x5_BEGINNER, BOT_5x5_INTERMEDIATE, RANKED_TEAM_3x3, RANKED_TEAM_5x5, BOT_TT_3x3, GROUP_FINDER_5x5, ARAM_5x5, ONEFORALL_5x5, 
        /// FIRSTBLOOD_1x1, FIRSTBLOOD_2x2, SR_6x6, URF_5x5, ONEFORALL_MIRRORMODE_5x5, BOT_URF_5x5, NIGHTMARE_BOT_5x5_RANK1, NIGHTMARE_BOT_5x5_RANK2, NIGHTMARE_BOT_5x5_RANK5, ASCENSION_5x5, 
        /// HEXAKILL, BILGEWATER_ARAM_5x5, KING_PORO_5x5, COUNTER_PICK, BILGEWATER_5x5, TEAM_BUILDER_DRAFT_UNRANKED_5x5, TEAM_BUILDER_DRAFT_RANKED_5x5)
        /// </summary>
        public int QueueId { get; set; }
        public int Platform { get; set; }

        /// <summary>
        /// Season match was played (Legal values: PRESEASON3, SEASON3, PRESEASON2014, SEASON2014, PRESEASON2015, SEASON2015, PRESEASON2016, SEASON2016)
        /// </summary>
        public int SeasonId { get; set; }

        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        /*
         * platformId	string	Platform ID of the match
         * teams	List[Team]	Team information
         * Timeline	Match timeline data (not included by default)
         */

        public virtual ICollection<MatchDataParticipant> DataParticipant { get; set; }
        public virtual ICollection<MatchDataTeam> DataTeam { get; set; }
        public virtual ICollection<MatchDataParticipantStats> DataParticipantStats { get; set; }
    }
}