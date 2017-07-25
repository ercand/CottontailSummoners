using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class RunePage
    {
        [Key]
        public long ID { get; set; }
        public int IdRunePage { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public string RuneCode { get; set; }
        public long RiotSummonerID { get; set; }
        public int Platform { get; set; }
        public DateTime LastUpdate { get; set; }

        public long FK_SummonerID { get; set; }

        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("FK_SummonerID")]
        public virtual Summoner Summoner { get; set; }
    }
}