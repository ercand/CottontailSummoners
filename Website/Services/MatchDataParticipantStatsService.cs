using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CottontailApi;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Services.Interfaces;

namespace Website.Services
{
    public class MatchDataParticipantStatsService : IMatchDataParticipantStatsService
    {
        IMatchDataParticipantStatsRepository _matchDataParticipantStatsRepository;
        IUnitOfWork _unitOfWork;
        IRiotApiClient _riotApiClient;

        public MatchDataParticipantStatsService(IMatchDataParticipantStatsRepository matchDataParticipantStatsRepository, IUnitOfWork unitOfWork, IRiotApiClient riotApiClient)
        {
            this._matchDataParticipantStatsRepository = matchDataParticipantStatsRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }

        public IEnumerable<MatchDataParticipantStats> Find() { throw new NotImplementedException(); }
        public IEnumerable<MatchDataParticipantStats> GetAll()
        {
            return this._matchDataParticipantStatsRepository.GetAll();
        }
        public void AddEntity(List<CottontailApi.Dto.Match.ParticipantDto> listParticipantsStats, long matchDatabaseId, int platform)
        {
            int participantID = 1;
            foreach (var statParticipant in listParticipantsStats)
            {
                var stat = statParticipant.Stats;
                Entities.MatchDataParticipantStats tempStats = new MatchDataParticipantStats()
                {
                    ChampionLevel = (int)stat.ChampLevel,
                    CombatPlayerScore = (int)stat.CombatPlayerScore,
                    DoubleKills = (int)stat.DoubleKills,
                    FirstBloodAssist = stat.FirstBloodAssist,
                    FirstBloodKill = stat.FirstBloodKill,
                    FirstInhibitorAssist = stat.FirstInhibitorAssist,
                    FirstInhibitorKill = stat.FirstInhibitorKill,
                    FirstTowerAssist = stat.FirstTowerAssist,
                    FirstTowerKill = stat.FirstTowerKill,
                    GoldSpent = (int)stat.GoldSpent,
                    InhibitorKills = (int)stat.InhibitorKills,
                    KillingSprees = (int)stat.KillingSprees,
                    LargestCriticalStrike = (int)stat.LargestCriticalStrike,
                    LargestKillingSpree = (int)stat.LargestKillingSpree,
                    LargestMultiKill = (int)stat.LargestMultiKill,
                    MagicDamageDealt = (int)stat.MagicDamageDealt,
                    MagicDamageDealtToChampions = (int)stat.MagicDamageDealtToChampions,
                    MagicDamageTaken = (int)stat.MagicalDamageTaken,
                    NodeCapture = (int)stat.NodeCapture,
                    NodeCaptureAssist = (int)stat.NodeCaptureAssist,
                    NodeNeutralize = (int)stat.NodeNeutralize,
                    NodeNeutralizeAssist = (int)stat.NodeNeutralizeAssist,
                    ObjectivePlayerScore = (int)stat.ObjectivePlayerScore,
                    PentaKills = (int)stat.PentaKills,
                    PhysicalDamageDealt = (int)stat.PhysicalDamageDealt,
                    PhysicalDamageDealtToChampions = (int)stat.PhysicalDamageDealtToChampions,
                    PhysicalDamageTaken = (int)stat.PhysicalDamageTaken,
                    QuadraKills = (int)stat.QuadraKills,
                    SightWardsBoughtInGame = (int)stat.SightWardsBoughtInGame,
                    TeamObjective = (int)stat.TeamObjective,
                    TotalDamageDealt = (int)stat.TotalDamageDealt,
                    TotalDamageDealtToChampions = (int)stat.TotalDamageDealtToChampions,
                    TotalDamageTaken = (int)stat.TotalDamageTaken,
                    TotalHeal = (int)stat.TotalHeal,
                    TotalPlayerScore = (int)stat.TotalPlayerScore,
                    TotalScoreRank = (int)stat.TotalScoreRank,
                    TotalTimeCrowdControlDealt = (int)stat.TotalTimeCrowdControlDealt,
                    TotalUnitsHealed = (int)stat.TotalUnitsHealed,
                    TowerKills = (int)stat.TurretKills,
                    TripleKills = (int)stat.TripleKills,
                    TrueDamageDealt = (int)stat.TrueDamageDealt,
                    TrueDamageDealtToChampions = (int)stat.TrueDamageDealtToChampions,
                    TrueDamageTaken = (int)stat.TrueDamageTaken,
                    UnrealKills = (int)stat.UnrealKills,
                    VisionWardsBoughtInGame = (int)stat.VisionWardsBoughtInGame,
                    WardsKilled = (int)stat.WardsKilled,
                    WardsPlaced = (int)stat.WardsPlaced,
                    ParticipantId = participantID,
                    TimeCCingOthers = (int)stat.TimeCCingOthers,
                    Uid = ((long)matchDatabaseId*100+ platform) * 100 + (long)(participantID)
                };

                tempStats.FK_MatchDataID = matchDatabaseId;

                participantID++;
                Save(tempStats);
            }

            //return newTeamData;
        }
        public void Save(MatchDataParticipantStats matchDataParticipantStats)
        {
            this.Save(new List<MatchDataParticipantStats>() { matchDataParticipantStats });
        }
        public void Save(IEnumerable<MatchDataParticipantStats> matchDataParticipantStats)
        {
            foreach (var match in matchDataParticipantStats)
            {
                if (match.ID == default(int))
                {
                    this._matchDataParticipantStatsRepository.Insert(match);
                }
                else
                {
                    this._matchDataParticipantStatsRepository.Update(match);
                    // il metodo update non dovrebbe mai essere usato. Almeno per l'attuale versione del sito lancio un'eccezione
                    throw new Exception("MatchDataParticipantStatsService.Save() sezione update().Questo metodo non dovrebbe essere evocato");
                }
            }

            this._matchDataParticipantStatsRepository.Save();
        }
        public void Delete(MatchDataParticipantStats matchDataParticipantStats) { throw new NotImplementedException(); }
        public void Delete(IList<MatchDataParticipantStats> matchDataParticipantStats) { throw new NotImplementedException(); }
    }
}