using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class Summoner
    {
        private Summoner() { }

        public Summoner(long riotSummonerID, string name, long accountId, int profileIcon, long revisionDate, int level, int platform, int score, string viewsInfo, DateTime lastUpdate, long riotIdregion_uid)
        {
            this.RiotSummonerID = riotSummonerID;
            this.Name = name;
            this.AccountId = accountId;
            this.ProfileIconId = profileIcon;
            this.RevisionDate = revisionDate;
            this.Level = level;
            this.Platform = platform;
            this.Score = score;
            this.Viewsinfo = viewsInfo;
            this.LastRankedMatchRiotId = 0;
            this.LastUpdate = lastUpdate;
            this.RecordDateTimeCreate = DateTime.UtcNow;
            this.Uid = riotIdregion_uid;
        }

        [Key]
        public long ID { get; set; }
        public long RiotSummonerID { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public int Level { get; set; }
        public int Platform { get; set; }
        public int Score { get; set; }
        public string Viewsinfo { get; set; }
        public long LastRankedMatchRiotId { get; set; }
        public DateTime LastUpdate { get; set; }
        //    public int LeaguePoint { get; set; }

        public DateTime RecordDateTimeCreate { get; set; } // Questa variabile la creo durante la fase di sviluppo. Forse potrebbe essere comoda anche in fase finale
        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }


        public virtual ICollection<MasteryPage> MasteryPages { get; set; }
        public virtual ICollection<RunePage> RunePages { get; set; }
        public virtual ICollection<PlayerLeague> PlayerLeague { get; set; }
        public virtual ICollection<PlayerChampionRankedStats> PlayerChampionStats { get; set; }
    }
}