using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class MatchDataTeam
    {
        public MatchDataTeam()
        {
        }

        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Stringa che rappresenta i ban di entrambi i team {champion id:ban turn},{champion id:ban turn},{champion id:ban turn}
        /// </summary>
        public string BanCode { get; set; }

        public int BaronKills { get; set; }

        /// <summary>
        /// If game was a dominion game, specifies the points the team had at game end, otherwise null
        /// </summary>
        public int DominionVictoryScore { get; set; }
        public int DragonKills { get; set; }
        public bool FirstBaron { get; set; }
        public bool FirstBlood { get; set; }
        public bool FirstDragon { get; set; }
        public bool FirstInhibitor { get; set; }
        public bool FirstRiftHerald { get; set; }
        public bool FirstTower { get; set; }
        public int InhibitorKills { get; set; }
        public int RiftHeraldKills { get; set; }
        public int TeamId { get; set; }
        public int TowerKills { get; set; }
        public int VilemawKills { get; set; }
        public bool Winner { get; set; }

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