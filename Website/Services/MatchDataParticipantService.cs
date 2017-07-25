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
    public class MatchDataParticipantService : IMatchDataParticipantService
    {
        IMatchDataParticipantRepository _matchDataParticipantRepository;
        IUnitOfWork _unitOfWork;
        CottontailApi.IRiotApiClient _riotApiClient;

        public MatchDataParticipantService(IMatchDataParticipantRepository matchDataParticipantRepository, IUnitOfWork unitOfWork, CottontailApi.IRiotApiClient riotApiClient)
        {
            this._matchDataParticipantRepository = matchDataParticipantRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }
        public IEnumerable<MatchDataParticipant> Find()
        { throw new NotImplementedException(); }
        public IEnumerable<MatchDataParticipant> GetAll()
        {
            return this._matchDataParticipantRepository.GetAll();
        }
        public void AddEntity(List<CottontailApi.Dto.Match.ParticipantDto> listParticipants, List<Tuple<int, int, int, int, int>> participantRiotSummonerIdList, long matchDatabaseId)
        {
            // Summoner sconosciuto già usati
            List<Tuple<int, int, int, int, int>> unknowSummonerUsed = participantRiotSummonerIdList.Where(s => s.Item1 == -1 && s.Item5 == -1).ToList();

            foreach (var participant in listParticipants)
            {
                var tempTuple = participantRiotSummonerIdList.Where(s => s.Item3 == participant.ChampionId && s.Item4 == participant.TeamId && s.Item5 == participant.Stats.TotalDamageDealt).SingleOrDefault();
                Entities.MatchDataParticipant tempEntitie = null;
                if (tempTuple != default(Tuple<int, int, int, int, int>))
                {
                    tempEntitie = new MatchDataParticipant()
                    {
                        ChampionId = participant.ChampionId,
                        Assists = (int)participant.Stats.Assists,
                        Deaths = (int)participant.Stats.Deaths,
                        GoldEarned = (int)participant.Stats.GoldEarned,
                        Item0 = (int)participant.Stats.Item0,
                        Item1 = (int)participant.Stats.Item1,
                        Item2 = (int)participant.Stats.Item2,
                        Item3 = (int)participant.Stats.Item3,
                        Item4 = (int)participant.Stats.Item4,
                        Item5 = (int)participant.Stats.Item5,
                        Item6 = (int)participant.Stats.Item6,
                        Kills = (int)participant.Stats.Kills,
                        MinionsKilled = (int)participant.Stats.TotalMinionsKilled,
                        NeutralMinionsKilled = (int)participant.Stats.NeutralMinionsKilled,
                        NeutralMinionsKilledEnemyJungle = (int)participant.Stats.NeutralMinionsKilledEnemyJungle,
                        NeutralMinionsKilledTeamJungle = (int)participant.Stats.NeutralMinionsKilledTeamJungle,
                        Spell1Id = participant.Spell1Id,
                        Spell2Id = participant.Spell2Id,
                        TeamId = participant.TeamId,
                        MasteryCode = Utility.Mastery.ToMasteyPageCode(participant.Masteries),
                        RuneCode = Utility.Rune.ToRunePageCode(participant.Runes),
                        Winner = participant.Stats.Win,
                        Role = participant.Timeline.Role,
                        Lane = participant.Timeline.Lane,

                        Uid = (long)matchDatabaseId * 100 + (long)tempTuple.Item1,
                        FK_MatchDataID = matchDatabaseId,
                        ParticipantId = tempTuple.Item1,
                        RiotSummonerID = tempTuple.Item2
                        //RiotAccountID = identitys.Where(s => s.ParticipantId == participant.ParticipantId).Single().Player.CurrentAccountId
                    };
                }
                else if (unknowSummonerUsed.Count > 0)
                {
                    var tempUnknown = unknowSummonerUsed.First();
                    tempEntitie = new MatchDataParticipant();
                    tempEntitie.FK_MatchDataID = matchDatabaseId;
                    tempEntitie.RiotSummonerID = tempUnknown.Item2;
                    tempEntitie.TeamId = tempUnknown.Item4;
                    tempEntitie.ChampionId = tempUnknown.Item3;
                    unknowSummonerUsed.Remove(tempUnknown);
                }

                if (tempEntitie != null)
                    Save(tempEntitie);
            }
        }

        public void AddEntity(List<CottontailApi.Dto.Match.ParticipantDto> listParticipants, List<CottontailApi.Dto.Match.ParticipantIdentityDto> identitys, long matchDatabaseId)
        {
            foreach (var participant in listParticipants)
            {
                Entities.MatchDataParticipant tempEntitie = null;

                tempEntitie = new MatchDataParticipant()
                {
                    ChampionId = participant.ChampionId,
                    Assists = (int)participant.Stats.Assists,
                    Deaths = (int)participant.Stats.Deaths,
                    GoldEarned = (int)participant.Stats.GoldEarned,
                    Item0 = (int)participant.Stats.Item0,
                    Item1 = (int)participant.Stats.Item1,
                    Item2 = (int)participant.Stats.Item2,
                    Item3 = (int)participant.Stats.Item3,
                    Item4 = (int)participant.Stats.Item4,
                    Item5 = (int)participant.Stats.Item5,
                    Item6 = (int)participant.Stats.Item6,
                    Kills = (int)participant.Stats.Kills,
                    MinionsKilled = (int)participant.Stats.TotalMinionsKilled,
                    NeutralMinionsKilled = (int)participant.Stats.NeutralMinionsKilled,
                    NeutralMinionsKilledEnemyJungle = (int)participant.Stats.NeutralMinionsKilledEnemyJungle,
                    NeutralMinionsKilledTeamJungle = (int)participant.Stats.NeutralMinionsKilledTeamJungle,
                    Spell1Id = participant.Spell1Id,
                    Spell2Id = participant.Spell2Id,
                    TeamId = participant.TeamId,
                    MasteryCode = Utility.Mastery.ToMasteyPageCode(participant.Masteries),
                    RuneCode = Utility.Rune.ToRunePageCode(participant.Runes),
                    Winner = participant.Stats.Win,
                    Role = participant.Timeline.Role,
                    Lane = participant.Timeline.Lane,

                    Uid = (long)matchDatabaseId * 100 + participant.ParticipantId,
                    FK_MatchDataID = matchDatabaseId,
                    ParticipantId = participant.ParticipantId,
                    RiotSummonerID = identitys.Where(s => s.ParticipantId == participant.ParticipantId).Single().Player.SummonerId,
                    RiotAccountID = identitys.Where(s => s.ParticipantId == participant.ParticipantId).Single().Player.CurrentAccountId
                };
                Save(tempEntitie);
            }
        }

        public void Save(MatchDataParticipant matchDataParticipant)
        {
            this.Save(new List<MatchDataParticipant>() { matchDataParticipant });
        }
        public void Save(IEnumerable<MatchDataParticipant> matchDataParticipant)
        {
            foreach (var match in matchDataParticipant)
            {
                if (match.ID == default(int))
                {
                    this._matchDataParticipantRepository.Insert(match);
                }
                else
                {
                    this._matchDataParticipantRepository.Update(match);
                    // il metodo update non dovrebbe mai essere usato. Almeno per l'attuale versione del sito lancio un'eccezione
                    throw new Exception("MatchDataParticipantService.Save() sezione update().Questo metodo non dovrebbe essere evocato");
                }
            }

            this._matchDataParticipantRepository.Save();
        }
        public void Delete(MatchDataParticipant matchDataParticipant) { throw new NotImplementedException(); }
        public void Delete(IList<MatchDataParticipant> matchDataParticipant) { throw new NotImplementedException(); }
    }
}