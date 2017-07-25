using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class PlayerLeague
    {
        [Key]
        public long ID { get; set; }

        public long RiotSummonerID { get; set; }
        //"playerOrTeamId": "23748066", non so se mettere questo dato nella tabella
        public string SummonerName { get; set; }
        public int Platform { get; set; }
        public string LeagueName { get; set; }
        public int LeaguePoints { get; set; }
        public bool IsFreshBlood { get; set; }
        public bool IsHotStreak { get; set; }
        public int Tier { get; set; }
        public int Division { get; set; }
        public bool IsInactive { get; set; }
        public bool IsVeteran { get; set; }
        public int Losses { get; set; }        
        public int Wins { get; set; }
        public DateTime LastUpdate { get; set; }

        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public long FK_SummonerID { get; set; }

        [ForeignKey("FK_SummonerID")]
        public virtual Summoner Summoner { get; set; }

        private PlayerLeague() { }

        public PlayerLeague(long riotSummonerID, string summonerName, int platform, string leagueName, int leaguePoints, bool isFreshBlood, bool isHotStreak, int tier, int division, bool isInactive, bool isVeteran, int losses, int win, DateTime lastUpdate, long uid) 
        {
            this.RiotSummonerID = riotSummonerID;
            this.SummonerName = summonerName;
            this.Platform = platform;
            this.LeagueName = leagueName;
            this.LeaguePoints = leaguePoints;
            this.IsFreshBlood = isFreshBlood;
            this.IsHotStreak = isHotStreak;
            this.Tier = tier;
            this.Division = division;
            this.IsInactive = isInactive;
            this.IsVeteran = isVeteran;
            this.Losses = losses;
            this.Wins = win;
            this.LastUpdate = lastUpdate;
            this.Uid = uid;
        }
    }
}