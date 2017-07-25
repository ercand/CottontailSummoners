using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CottontailApi.Dto.League;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Services.Interfaces;
using Website.Helpers;

namespace Website.Services
{
    public class PlayerLeagueService : IPlayerLeagueService
    {
        IPlayerLeagueRepository _playerLeagueRepository;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public PlayerLeagueService(IPlayerLeagueRepository summonerRepository, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._playerLeagueRepository = summonerRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        public IEnumerable<PlayerLeague> Find(long summonersId, CottontailApi.Commons.Enums.Platform platform)
        {
            return this.Find(new List<long>() { summonersId }, platform);
        }
        public IEnumerable<PlayerLeague> Find(List<long> summonersId, CottontailApi.Commons.Enums.Platform platform)
        {
            int platformInt = Utility.Platform.PlatformToInt(platform);
            DateTime utcNowDt = DateTime.UtcNow;

            var leagueFromDb = _playerLeagueRepository.FindSummonerLeague(summonersId, platformInt).ToList();

            // Divido i summoner in tre List. Quelli Aggiornati, quelli da aggiornare e quelli non presenti nel DB
            var summonerToNotUpdate = leagueFromDb.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds < 3600.0f).ToList(); // Summoner nel DB che possono essere utilizzati subito
            var summonerToSearch = summonersId.Where(x => !leagueFromDb.Select(name => name.RiotSummonerID).Contains(x)).ToList(); //Summoner non presenti nel DB
            var summonerToUpdate = leagueFromDb.Where(time => (utcNowDt - time.LastUpdate).TotalSeconds >= 3600.0f).ToList(); // Summoner gia presenti nel DB che devono essere aggiornati

            // 
            var toSearch = summonerToSearch.Concat(summonerToUpdate.Select(toUpdate => toUpdate.RiotSummonerID)).ToList();
            Dictionary<long, List<LeaguePositionDto>> leaguesNewData = new Dictionary<long, List<LeaguePositionDto>>();
            foreach (var leaguePositionDto in toSearch)
            {
                var tslp=_riotApiClient.GetLeaguePositionBySummonerId(leaguePositionDto, platform);
                leaguesNewData.Add(leaguePositionDto, tslp);
            }

            List<PlayerLeague> toSave = new List<PlayerLeague>();
            List<PlayerLeague> result = null;

            // Aggiorna e crea le nuove League
            if (leaguesNewData.Count > 0)
            {
                foreach (var itemSummonerId in summonerToSearch)
                {
                    if (leaguesNewData.ContainsKey((long)itemSummonerId))
                    {
                        var tempListLeagueDto = leaguesNewData[(long)itemSummonerId];
                        foreach (var itemLeague in tempListLeagueDto)
                        {
                            if (itemLeague.QueueType == CottontailApi.Commons.Enums.LeagueQueueType.RANKED_SOLO_5x5)
                            {
                                var v = itemLeague;
                                long tmpSummonerId=long.Parse(v.PlayerOrTeamId);
                                var npl = new PlayerLeague((int)tmpSummonerId, v.PlayerOrTeamName, platformInt, itemLeague.LeagueName, v.LeaguePoints, v.FreshBlood, v.HotStreak, itemLeague.Tier.TierToInt(), Utility.RankedDivisionToInt(v.Rank), v.Inactive, v.Veteran, v.Losses, v.Wins, utcNowDt, tmpSummonerId*100 + platformInt);
                                npl.FK_SummonerID = _unitOfWork.Set<Summoner>().Single(s => (s.RiotSummonerID == tmpSummonerId && s.Platform == platformInt)).ID;
                                toSave.Add(npl);
                            }
                        } 
                    }
                    else
                    {
                     //   toSave.Add(new PlayerLeague(itemSummonerId, "ddddd", regionStr, "UNKNOWN", 0, false, false, "UNRANKED", "UNKNOWN", false, false, 0, 0, dt));
                    }

                }
                foreach (var itemPlayerLeagueToUpdate in summonerToUpdate)
                {
                    var tempListLeagueDto = leaguesNewData[(long)itemPlayerLeagueToUpdate.RiotSummonerID];
                    foreach (var itemLeague in tempListLeagueDto)
                    {
                        if (itemLeague.QueueType == CottontailApi.Commons.Enums.LeagueQueueType.RANKED_SOLO_5x5)
                        {
                            var v = itemLeague;
                            itemPlayerLeagueToUpdate.RiotSummonerID = Int32.Parse(v.PlayerOrTeamId);
                            itemPlayerLeagueToUpdate.SummonerName = v.PlayerOrTeamName;
                            itemPlayerLeagueToUpdate.Platform = platformInt;
                            itemPlayerLeagueToUpdate.LeagueName = itemLeague.LeagueName;
                            itemPlayerLeagueToUpdate.LeaguePoints = v.LeaguePoints;
                            itemPlayerLeagueToUpdate.IsFreshBlood = v.FreshBlood;
                            itemPlayerLeagueToUpdate.IsHotStreak = v.HotStreak;
                            itemPlayerLeagueToUpdate.Tier = itemLeague.Tier.TierToInt();
                            itemPlayerLeagueToUpdate.Division = Utility.RankedDivisionToInt(v.Rank);
                            itemPlayerLeagueToUpdate.IsInactive = v.Inactive;
                            itemPlayerLeagueToUpdate.IsVeteran = v.Veteran;
                            itemPlayerLeagueToUpdate.Losses = v.Losses;
                            itemPlayerLeagueToUpdate.Wins = v.Wins;
                            itemPlayerLeagueToUpdate.LastUpdate = utcNowDt;
                            toSave.Add(itemPlayerLeagueToUpdate);
                        }
                    }
                }
                this.Save(toSave);
            }

            // Crea la list aggiornata di tutti i summoner
            result = summonerToNotUpdate.Concat(toSave).ToList();

            return result;
        }
        public IEnumerable<PlayerLeague> GetAll() 
        {
            return this._playerLeagueRepository.GetAll();
        }
        public void Save(PlayerLeague playerLeague) 
        {
            this.Save(new List<PlayerLeague>() { playerLeague });
        }
        public void Save(IEnumerable<PlayerLeague> playerLeague)
        {
            foreach (var league in playerLeague)
            {
                if (league.ID == default(int))
                {
                    this._playerLeagueRepository.Insert(league);
                }
                else
                {
                    this._playerLeagueRepository.Update(league);
                }
            }

            this._playerLeagueRepository.Save();
        }
        public void Delete(PlayerLeague playerLeague) { throw new NotImplementedException(); }
        public void Delete(IList<PlayerLeague> playerLeague) { throw new NotImplementedException(); }
    }
}