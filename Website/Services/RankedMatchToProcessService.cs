using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Helpers;
using Website.Services.Interfaces;

namespace Website.Services
{
    public class RankedMatchToProcessService : IRankedMatchToProcessService
    {
        IRankedMatchToProcessRepository _toProcessRepository;
        IMatchService _matchService;
        ISummonerService _summonerService;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public RankedMatchToProcessService(IRankedMatchToProcessRepository toProcessRepository, IMatchService matchService, ISummonerService summonerService, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._toProcessRepository = toProcessRepository;
            this._matchService = matchService;
            this._summonerService = summonerService;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        public IEnumerable<RankedMatchToProcess> GetRecent(int count, CottontailApi.Commons.Enums.Platform platform)
        {
            return this._toProcessRepository.GetLast(count, Utility.Platform.PlatformToInt(platform));
        }

        public void Add(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform)
        {
            int toProcessCount = 10;
            var s = _summonerService.Find(riotSummonerId, platform).Single();
            var t = _riotApiClient.GetRankedMatchListByAccountId(s.AccountId, platform, CottontailApi.Commons.Enums.RankedMatchlistQueueType.TEAM_BUILDER_RANKED_SOLO);
            var existMatch = this._toProcessRepository.ContainMatch(t.Matches.Select(m => m.GameId).ToList(), Utility.Platform.PlatformToInt(platform)).ToList();

            // Add new match only if no match in queue
            if (existMatch.Count() > 0)
            {
                List<RankedMatchToProcess> toSave = new List<RankedMatchToProcess>();
                foreach (var item in existMatch)
                {
                    item.Score = item.Score+1;
                    toSave.Add(item);
                }
                Save(toSave);
            }
            else
            {
                List<CottontailApi.Dto.Match.MatchReferenceDto> toProcess = new List<CottontailApi.Dto.Match.MatchReferenceDto>();
                List<RankedMatchToProcess> toSave = new List<RankedMatchToProcess>();
                if (s.LastRankedMatchRiotId != 0)
                {
                    int currentIndex = t.Matches.IndexOf(t.Matches.Where(m => m.GameId == s.LastRankedMatchRiotId).Single());
                    if (t.Matches.Count - currentIndex > 1)
                    {
                        int index = Math.Max(0, currentIndex - toProcessCount);
                        int maxElement = Math.Min(currentIndex, toProcessCount);
                        toProcess = t.Matches.GetRange(index, maxElement);
                    }
                }
                else
                {
                    int start = Math.Max(0, t.Matches.Count - toProcessCount);
                    int maxElemnt = Math.Min(t.Matches.Count - start, toProcessCount);
                    toProcess = t.Matches.GetRange(start, maxElemnt);
                }


                foreach (var tempMatch in toProcess)
                {
                    RankedMatchToProcess tp = new RankedMatchToProcess()
                    {
                        Platform = Utility.Platform.PlatformToInt(platform),
                        RiotMatchID = tempMatch.GameId,
                        Season = tempMatch.Season
                    };
                    toSave.Add(tp);
                }

                if (toSave.Count > 0)
                {
                    _summonerService.RefreshLastRanked(riotSummonerId, platform, toSave[0].RiotMatchID);
                }
                Save(toSave);
            }
        }
        public IEnumerable<RankedMatchToProcess> GetAll()
        {
            return this._toProcessRepository.GetAll();
        }
        public void Save(RankedMatchToProcess toProcess)
        {
            this.Save(new List<RankedMatchToProcess>() { toProcess });
        }
        public void Save(IEnumerable<RankedMatchToProcess> toProcess)
        {
            foreach (var summoner in toProcess)
            {
                if (summoner.ID == default(int))
                {
                    this._toProcessRepository.Insert(summoner);
                }
                else
                {
                    this._toProcessRepository.Update(summoner);
                }
            }

            this._toProcessRepository.Save();
        }
        public void Delete(RankedMatchToProcess toProcess)
        {
            this._toProcessRepository.Delete(toProcess);
            this._toProcessRepository.Save();
        }
        public void Delete(IList<RankedMatchToProcess> toProcess) { throw new NotImplementedException(); }
    }
}