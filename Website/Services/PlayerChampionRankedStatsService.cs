using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Services.Interfaces;
using Website.Helpers;
using System.Threading.Tasks;

namespace Website.Services
{
    public class PlayerChampionRankedStatsService : IPlayerChampionRankedStatsService
    {
        public static DateTime startTime;
        public static DateTime endTime;
        public static double timeFindDatabase = 0;
        public static double timeFindApiCall = 0;
        public static double timeCreateUpdate = 0;
        public static double timeSave = 0;
        IPlayerChampionRankedStatsRepository _playerChampionRankedStatsRepository;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public PlayerChampionRankedStatsService(IPlayerChampionRankedStatsRepository playerChampionRankedStatsRepository, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._playerChampionRankedStatsRepository = playerChampionRankedStatsRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        public IEnumerable<PlayerChampionRankedStats> FindChampionsStats(Entities.Summoner entitySummoner, CottontailApi.Commons.Enums.Platform platform, CottontailApi.Commons.Enums.SeasonNoPreSeasonType season)
        {
            return _playerChampionRankedStatsRepository.FindAllChampionStatsBySummonerId(entitySummoner.RiotSummonerID, Utility.Platform.PlatformToInt(platform), (int) season);
        }


        public IEnumerable<PlayerChampionRankedStats> FindAllSeasonChampionStats(Entities.Summoner entitySummoner, CottontailApi.Commons.Enums.Platform platform)
        {
            List<PlayerChampionRankedStats> result = new List<PlayerChampionRankedStats>();
            foreach (CottontailApi.Commons.Enums.SeasonNoPreSeasonType item in Enum.GetValues(typeof(CottontailApi.Commons.Enums.SeasonNoPreSeasonType)))
            {
                if (item != CottontailApi.Commons.Enums.SeasonNoPreSeasonType.UNKNOWN)
                {
                    var temp = FindChampionsStats(entitySummoner, platform, item).ToList();
                    result.AddRange(temp);
                }
            }
            return result;
        }
        public IEnumerable<PlayerChampionRankedStats> FindSingleChampionStats(Entities.Summoner entitySummoner, CottontailApi.Commons.Enums.Platform platform, List<int> championId, CottontailApi.Commons.Enums.SeasonNoPreSeasonType season) { throw new NotImplementedException(); }

        public IEnumerable<PlayerChampionRankedStats> FindAllPlayerChampionStats(List<Entities.Summoner> entitySummoner, CottontailApi.Commons.Enums.Platform platform, CottontailApi.Commons.Enums.SeasonNoPreSeasonType season)
        {
            throw new NotImplementedException();
#pragma warning Implementare skipUpdate e adattare alle api V3
            /*
            List<PlayerChampionRankedStats> toSave = new List<PlayerChampionRankedStats>();
            List<long> summonerId = entitySummoner.Select(id => id.RiotSummonerID).ToList();
            DateTime utcNowDt = DateTime.UtcNow;

            DateTime f1 = DateTime.Now;
            var statsFromDB = _playerChampionRankedStatsRepository.FindAllPlayerChampionStatsByRiotSummonerId(summonerId, region.RegionToInt(), season.SeasonToInt()).ToList();
            timeFindDatabase += (DateTime.Now - f1).TotalSeconds;

            // Divido i summoner in tre List. Quelli Aggiornati, quelli da aggiornare e quelli non presenti nel DB
            var summonerToNotUpdate = statsFromDB.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds < 3600.0f).ToList(); // Summoner nel DB che possono essere utilizzati subito
            var summonerToSearch = summonerId.Where(x => !statsFromDB.Select(summoner => summoner.RiotSummonerID).Contains(x)).ToList(); //Summoner non presenti nel DB
            var summonerToUpdate = statsFromDB.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds >= 3600.0f).ToList(); // Summoner gia presenti nel DB che devono essere aggiornati

            //
            var toSearch = summonerToSearch.Concat(summonerToUpdate.GroupBy(x => x.RiotSummonerID).Select(toUpdate => toUpdate.Key)).ToList();
            f1 = DateTime.Now;
            List<RiotApi.Dto.Stats.RankedStatsDto> allTask = new List<RiotApi.Dto.Stats.RankedStatsDto>();
            foreach (var item in toSearch)
            {
                allTask.Add(_riotApiClient.GetRankedStatsBySummonerId((RiotApi.Commons.Enums.Region)region, item, season));
            }

            var fine = (DateTime.Now - f1).TotalSeconds;

            f1 = DateTime.Now;
            foreach (var stat in allTask)
            {
                if (stat != null)
                {
                    var tempSummonerEntity = entitySummoner.Where(x => x.RiotSummonerID == stat.SummonerId).Single();
                    var tempToUpdate = summonerToUpdate.Where(x => x.RiotSummonerID == stat.SummonerId).ToList();

                    if (tempToUpdate.Count > 0)
                    {
                        foreach (var champStats in stat.Champions)
                        {
                            PlayerChampionRankedStats newStats;
                            var statToSave = tempToUpdate.Where(x => x.ChampionId == champStats.ChampionId).SingleOrDefault();
                            if (statToSave != null)
                            {
                                newStats = UpdateEntity(statToSave, champStats.Stats, utcNowDt);
                            }
                            else
                            {
                                newStats = CreateNewEntity(champStats.Stats, utcNowDt, 0, tempSummonerEntity.ID, champStats.ChampionId, (int)stat.SummonerId, region.RegionToInt(), season.SeasonToInt());
                            }
                            toSave.Add(newStats);
                        }
                    }
                    else
                    {
                        foreach (var champStats in stat.Champions)
                        {
                            PlayerChampionRankedStats newStats = CreateNewEntity(champStats.Stats, utcNowDt, 0, tempSummonerEntity.ID, champStats.ChampionId, (int)stat.SummonerId, region.RegionToInt(), season.SeasonToInt());
                            toSave.Add(newStats);
                        }
                    }
                }
                else
                {
                    int ddjkdjnd = 0;
                }
            }
            var timeCreateEntiry = (DateTime.Now - f1).TotalSeconds;
            f1 = DateTime.Now;
            Save(toSave);
            timeSave += (DateTime.Now - f1).TotalSeconds;
            System.Diagnostics.Debug.WriteLine("Tempo salvataggio entity:" + timeSave);
            List<PlayerChampionRankedStats> result = toSave.Concat(summonerToNotUpdate).ToList();

            return result;*/
        }

        /// <summary>
        /// Trova le statistiche dei champion elencati per ogni summoner. L'ID da passare quello che della colonna ID e non il SummonerID
        /// </summary>
        /// <param name="toSearch">Dizionario
        ///     <key>Valore del campo ID dell'entità <see cref="Entities.Summoner"/> del summoner che ci interessa</key>
        ///     <value>Lista che contiene gli ID dei champion di cui vogliamo le stats</value>
        /// </param>
        /// <returns></returns>
        public IEnumerable<PlayerChampionRankedStats> Find(Dictionary<int, List<int>> toSearch) { throw new NotImplementedException(); }

        public void AddChampionStats(List<CottontailApi.Dto.Match.ParticipantDto> stats, List<CottontailApi.Dto.Match.ParticipantIdentityDto> identitys, int platform, int queueId, int seasonId)
        {
            List<PlayerChampionRankedStats> toSave = new List<PlayerChampionRankedStats>();
            DateTime utcNowDt = DateTime.UtcNow;
            // Cerca tutti i summoner
            foreach (var playerIdentity in identitys)
            {
                PlayerChampionRankedStats newStats = null;
                var currentPlayerStats = stats.Where(s => s.ParticipantId == playerIdentity.ParticipantId).SingleOrDefault();
                var tempStat = _playerChampionRankedStatsRepository.FindSingleChampionStatsBySummonerId(playerIdentity.Player.SummonerId, platform, currentPlayerStats.ChampionId, seasonId);
                if (tempStat != null)
                {
                    // update
                    newStats = UpdateEntity(tempStat, currentPlayerStats.Stats, utcNowDt);
                }
                else
                {
                    newStats = CreateNewEntity(currentPlayerStats, utcNowDt, playerIdentity, platform, seasonId);
                }
                toSave.Add(newStats);
            }

            Save(toSave);
        }

        public IEnumerable<PlayerChampionRankedStats> GetAll() { throw new NotImplementedException(); }
        public void Save(PlayerChampionRankedStats summonerStats)
        {
            this.Save(new List<PlayerChampionRankedStats>() { summonerStats });
        }

        public void Save(IEnumerable<PlayerChampionRankedStats> summonerStats)
        {
            foreach (var stats in summonerStats)
            {
                if (stats.ID == default(int)) {
                    this._playerChampionRankedStatsRepository.Insert(stats);
                }
                else {
                    this._playerChampionRankedStatsRepository.Update(stats);
                }
            }

            this._playerChampionRankedStatsRepository.Save();
        }
        public void Delete(PlayerChampionRankedStats summoner) { throw new NotImplementedException(); }
        public void Delete(IList<PlayerChampionRankedStats> summoners) { throw new NotImplementedException(); }

        private PlayerChampionRankedStats CreateNewEntity(CottontailApi.Dto.Match.ParticipantDto stats, DateTime lastUpdate, CottontailApi.Dto.Match.ParticipantIdentityDto identitys, int platform, int season)
        {
            var t = stats.Stats;
            PlayerChampionRankedStats newStats = new PlayerChampionRankedStats()
            {
                DoubleKills = t.DoubleKills,
                TripleKills = t.TripleKills,
                QuadraKills = t.QuadraKills,
                PentaKills = t.PentaKills,
                UnrealKills = t.UnrealKills,

                GamePlayed = 1,
                Losses = t.Win == false ? 1 : 0,
                Wins = t.Win == true ? 1 : 0,
                Kills = t.Kills,
                Deaths = t.Deaths,
                Assists = t.Assists,

                DamageTaken = (int)t.TotalDamageTaken,
                DamageDealt = (int)t.TotalDamageDealt,
                PhysicalDamageDealt = (int)t.PhysicalDamageDealt,
                MagicDamageDealt = (int)t.MagicDamageDealt,

                MinionsKilled = (int)t.TotalMinionsKilled,
                TurretsKilled = (int)t.TurretKills,
                GoldEarned = (int)t.GoldEarned,
                MaxNumDeaths = t.Deaths,
                MaxChampionsKilled = t.Kills,

                TotalFirstBlood = t.FirstBloodKill == true ? 1 : 0,
                //toUpdate.MostSpellsCast += (int)t.MostSpellsCast,

                MaxLargestCriticalStrike = t.LargestCriticalStrike,
                MaxLargestKillingSpree = t.LargestKillingSpree,
                //  MaxTimePlayed = t.MaxTimePlayed,
                MaxTimeSpentLiving = t.LongestTimeSpentLiving,

                KillingSpree = t.KillingSprees,
                TotalHeal = (int)t.TotalHeal,
                NeutralMinionsKilled = t.NeutralMinionsKilled,

                //     toUpdate.RankedSoloGamesPlayed = t.RankedSoloGamesPlayed; // Sembra non funzionare - sempre = 0
                //   toUpdate.RankedPremadeGamesPlayed = t.RankedPremadeGamesPlayed;// Sembra non funzionare - sempre = 0
                //  toUpdate.NormalGamesPlayed = t.NormalGamesPlayed; // Sembra non funzionare - sempre = 0
                //  toUpdate.BotGamesPlayed = t.BotGamesPlayed;
                LastUpdate = lastUpdate
            };

            newStats.ChampionId = stats.ChampionId;
            newStats.RiotSummonerID = identitys.Player.SummonerId;
            newStats.Platform = platform;
            newStats.Season = season;
            newStats.Uid = ((identitys.Player.SummonerId * 100 + platform) * 100 + season) * 1000 + stats.ChampionId;


            return newStats;
        }

        private PlayerChampionRankedStats UpdateEntity(PlayerChampionRankedStats toUpdate, CottontailApi.Dto.Match.ParticipantStatsDto t, DateTime lastUpdate)
        {
            toUpdate.DoubleKills += t.DoubleKills;
            toUpdate.TripleKills += t.TripleKills;
            toUpdate.QuadraKills += t.QuadraKills;
            toUpdate.PentaKills += t.PentaKills;
            toUpdate.UnrealKills += t.UnrealKills;

            toUpdate.GamePlayed += 1;
            toUpdate.Losses += t.Win == false ? 1 : 0;
            toUpdate.Wins += t.Win == true ? 1 : 0;
            toUpdate.Kills += t.Kills;
            toUpdate.Deaths += t.Deaths;
            toUpdate.Assists += t.Assists;

            toUpdate.DamageTaken += (int)t.TotalDamageTaken;
            toUpdate.DamageDealt += (int)t.TotalDamageDealt;
            toUpdate.PhysicalDamageDealt += (int)t.PhysicalDamageDealt;
            toUpdate.MagicDamageDealt += (int)t.MagicDamageDealt;

            toUpdate.MinionsKilled += (int)t.TotalMinionsKilled;
            toUpdate.TurretsKilled += (int)t.TurretKills;
            toUpdate.GoldEarned += (int)t.GoldEarned;
            toUpdate.MaxNumDeaths = toUpdate.MaxNumDeaths > t.Deaths ? toUpdate.MaxNumDeaths : t.Deaths;
            toUpdate.MaxChampionsKilled = toUpdate.MaxChampionsKilled > t.Kills ? toUpdate.MaxNumDeaths : t.Kills;

            toUpdate.TotalFirstBlood += t.FirstBloodKill == true ? 1 : 0;
            //toUpdate.MostSpellsCast += (int)t.MostSpellsCast;

            toUpdate.MaxLargestCriticalStrike = toUpdate.MaxLargestCriticalStrike > t.LargestCriticalStrike ? toUpdate.MaxLargestCriticalStrike : t.LargestCriticalStrike;
            toUpdate.MaxLargestKillingSpree = toUpdate.MaxLargestKillingSpree > t.LargestKillingSpree ? toUpdate.MaxLargestKillingSpree : t.LargestKillingSpree;
            //  toUpdate.MaxTimePlayed = t.MaxTimePlayed;
            toUpdate.MaxTimeSpentLiving = toUpdate.MaxTimeSpentLiving > t.LongestTimeSpentLiving ? toUpdate.MaxTimeSpentLiving : t.LongestTimeSpentLiving;

            toUpdate.KillingSpree += t.KillingSprees;
            toUpdate.TotalHeal += (int)t.TotalHeal;
            toUpdate.NeutralMinionsKilled += t.NeutralMinionsKilled;

            //     toUpdate.RankedSoloGamesPlayed = t.RankedSoloGamesPlayed; // Sembra non funzionare - sempre = 0
            //   toUpdate.RankedPremadeGamesPlayed = t.RankedPremadeGamesPlayed;// Sembra non funzionare - sempre = 0
            //  toUpdate.NormalGamesPlayed = t.NormalGamesPlayed; // Sembra non funzionare - sempre = 0
            //  toUpdate.BotGamesPlayed = t.BotGamesPlayed;
            toUpdate.LastUpdate = lastUpdate;


            // Variabili se è una nuona entity

            //               if (fk_summonerId != null)
            //                           {
            //                               newStats.ID = id;
            //                               newStats.FK_SummonerID = fk_summonerId;
            //                               newStats.ChampionId = championId;
            //                               newStats.RiotSummonerID = riotSummonerId;
            //                               newStats.Region = region;
            //                               newStats.Season = season;
            //                           }

            return toUpdate;
        }
    }
}