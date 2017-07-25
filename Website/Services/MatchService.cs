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
    public class MatchService : IMatchService
    {
        IMatchDataRepository _matchRepository;
        IMatchDataTeamService _matchDataTeamService;
        IMatchDataParticipantStatsService _matchDataParticipantStatsService;
        IMatchDataParticipantService _matchDataParticipantService;
        private IPlayerChampionRankedStatsService _playerChampionRankedStatsService;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public MatchService(IMatchDataRepository matchRepository, IMatchDataTeamService matchDataTeamService, IMatchDataParticipantService matchDataParticipantService, IMatchDataParticipantStatsService matchDataParticipantStatsService, IPlayerChampionRankedStatsService playerChampionRankedStats, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._matchRepository = matchRepository;
            this._matchDataParticipantService = matchDataParticipantService;
            this._matchDataParticipantStatsService = matchDataParticipantStatsService;
            this._matchDataTeamService = matchDataTeamService;
            this._playerChampionRankedStatsService = playerChampionRankedStats;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        private MatchData AddRankedMatchToDatabase(CottontailApi.Dto.Match.MatchDto tempMatch, CottontailApi.Commons.Enums.Platform platform, int queue, int season)
        {
            int platformInt = Utility.Platform.PlatformToInt(platform);
            var tempEntity = CreateMatchDataEntity(tempMatch, platform);
            // result.Add(tempEntity);
            Save(tempEntity);
            long tempEntityId = tempEntity.ID;

            if (tempEntityId != 0)
            {
                // Team data
                _matchDataTeamService.AddEntity(tempMatch.Teams, tempEntityId, platformInt);

                // Participant data
                _matchDataParticipantService.AddEntity(tempMatch.Participants, tempMatch.ParticipantIdentities, tempEntityId);

                // Participant stats data
                _matchDataParticipantStatsService.AddEntity(tempMatch.Participants, tempEntityId, platformInt);

                // Aggiunsgi stats dei champion
                if (Utility.IsRankedSolo((CottontailApi.Commons.Enums.GameQueueType)queue))
                    _playerChampionRankedStatsService.AddChampionStats(tempMatch.Participants, tempMatch.ParticipantIdentities, platformInt, queue, season);
            }

            return tempEntity;
        }

        public IEnumerable<MatchData> Find(CottontailApi.Dto.Match.MatchlistDto recentGame, CottontailApi.Commons.Enums.Platform platform)
        {
            List<MatchData> result = new List<MatchData>();
            int platformInt = Utility.Platform.PlatformToInt(platform);

            foreach (var currentRecentGame in recentGame.Matches)
            {
                if (Utility.IsRankedGame((CottontailApi.Commons.Enums.GameQueueType)currentRecentGame.Queue))
                {
                    // Controlla sei il match è gia presente nel database
                    var matchFromDb = _matchRepository.FindMatch(currentRecentGame.GameId, platformInt);

                    if (matchFromDb != null)
                    {
                        result.Add(matchFromDb);
                    }
                    else // Match non presente nel database. Creiamo il nuovo record nel database
                    {
                        var tempMatch = _riotApiClient.GetMatchById(currentRecentGame.GameId, platform);
                        if (tempMatch != null)
                        {
                            result.Add(AddRankedMatchToDatabase(tempMatch, platform, currentRecentGame.Queue, currentRecentGame.Season));

                        }

                    }
                }
            }
            return result;
        }

        public IEnumerable<MatchData> FindBySummonerRiotId(long summonerRiotId, CottontailApi.Commons.Enums.Platform platform)
        {
            int platformInt = Utility.Platform.PlatformToInt(platform);
            return _matchRepository.FindMatchBySummonerId(summonerRiotId, platformInt);
        }


        public MatchData Find(long riotMatchId, CottontailApi.Commons.Enums.Platform platform)
        {
            int platformInt = Utility.Platform.PlatformToInt(platform);

            // Controlla sei il match è gia presente nel database
            var matchFromDb = _matchRepository.FindMatch(riotMatchId, platformInt);

            if (matchFromDb != null)
            {
                return matchFromDb;
            }
            else
            {
                var tempMatch = _riotApiClient.GetMatchById(riotMatchId, platform);
                if (tempMatch != null)
                {
                    if (Utility.IsRankedGame((CottontailApi.Commons.Enums.GameQueueType)tempMatch.QueueId))
                    {
                        return AddRankedMatchToDatabase(tempMatch, platform, tempMatch.QueueId, tempMatch.SeasonId);

                    }
                }
            }
            return null;
        }
        public IEnumerable<MatchData> GetAll()
        {
            return this._matchRepository.GetAll();
        }
        public void Save(MatchData matchData)
        {
            this.Save(new List<MatchData>() { matchData });
        }
        public void Save(IEnumerable<MatchData> matchData)
        {
            foreach (var match in matchData)
            {
                if (match.ID == default(int))
                {
                    this._matchRepository.Insert(match);
                }
                else
                {
                    this._matchRepository.Update(match);
                    // il metodo update non dovrebbe mai essere usato. Almeno per l'attuale versione del sito lancio un'eccezione
                    throw new Exception("MatchService.Save() sezione update().Questo metodo non dovrebbe essere evocato");
                }
            }

            this._matchRepository.Save();
        }
        public void Delete(MatchData matchData)
        {
            throw new NotImplementedException();
        }
        public void Delete(IList<MatchData> matchData)
        {
            throw new NotImplementedException();
        }


        private Entities.MatchData CreateMatchDataEntity(CottontailApi.Dto.Match.MatchDto match, CottontailApi.Commons.Enums.Platform platform)
        {
            Entities.MatchData newEntitie;

            newEntitie = new MatchData()
            {
                MapID = match.MapId,
                MatchMode = CottontailApi.Commons.GenericConverter.GameModeTypeToString(match.GameMode),
                SeasonId = match.SeasonId,
                RiotMatchID = match.GameId,
                Platform = Utility.Platform.PlatformToInt(platform),
                MatchVersion = match.GameVersion,
                QueueId = match.QueueId,
                MatchCreation = match.GameCreation,
                MatchDuration = match.GameDuration,
                Uid = match.GameId * 100 + Utility.Platform.PlatformToInt(match.PlatformId)
            };

            return newEntitie;
        }
    }
}