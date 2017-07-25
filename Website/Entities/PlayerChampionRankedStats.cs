using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class PlayerChampionRankedStats
    {
        [Key]        
        public long ID { get; set; }

        public long RiotSummonerID { get; set; }
        public int Platform { get; set; }
        public int ChampionId { get; set; }
        public int Season { get; set; }

        // Statistiche sulle Double Kill e oltre
        public int DoubleKills { get; set; }
        public int TripleKills { get; set; }
        public int QuadraKills { get; set; }
        public int PentaKills { get; set; }
        public int UnrealKills { get; set; }


        // Statistiche sulle partite giocate e K/D/A
        public int GamePlayed { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }


        // Statistiche sui danni
        public int DamageTaken { get; set; }
        public int DamageDealt { get; set; }
        public int PhysicalDamageDealt { get; set; }
        public int MagicDamageDealt { get; set; }


        // Statistiche varie
        public int MinionsKilled { get; set; }
        public int TurretsKilled { get; set; }
        public int GoldEarned { get; set; }
        public int MaxNumDeaths { get; set; }
        public int MaxChampionsKilled { get; set; }
        //public int MostChampionKillsPerSession { get; set; }// Non conoscno il significato di questo dato. Ha un valore sempre uguale a MaxChampionsKilled

        public int TotalFirstBlood { get; set; } // Sembra non funzionare - sempre = 0
        public int MostSpellsCast { get; set; }// Sembra non funzionare - sempre = 0

        //***************************************************************/
        // Qui di seguito valori che si trovano solo per ChampionId=0
        //***************************************************************/

        public int MaxLargestCriticalStrike { get; set; }
        public int MaxLargestKillingSpree { get; set; }
        public int MaxTimePlayed { get; set; }
        public int MaxTimeSpentLiving { get; set; }


        public int KillingSpree { get; set; }
        public int TotalHeal { get; set; }
        public int NeutralMinionsKilled { get; set; }


        public int RankedSoloGamesPlayed { get; set; } // Sembra non funzionare - sempre = 0
        public int RankedPremadeGamesPlayed { get; set; } // Sembra non funzionare - sempre = 0
        public int NormalGamesPlayed { get; set; } // Sembra non funzionare - sempre = 0
        public int BotGamesPlayed { get; set; } // Sembra non funzionare - sempre = 0

        public DateTime LastUpdate { get; set; }

        // Concurrency property
        [Index(IsUnique = true)]
        public long Uid { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

  /*      [ForeignKey("Summoner")]
        public long FK_SummonerID { get; set; }


        // Navigation Property
        public virtual Summoner Summoner { get; set; }*/

     //   private PlayerChampionRankedStats() { }

        public PlayerChampionRankedStats() { }
    }
}