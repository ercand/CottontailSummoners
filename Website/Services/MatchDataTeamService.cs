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
    public class MatchDataTeamService : IMatchDataTeamService
    {
        IMatchDataTeamRepository _matchDataTeamRepository;
        IUnitOfWork _unitOfWork;
        IRiotApiClient _riotApiClient;

        public MatchDataTeamService(IMatchDataTeamRepository matchDataTeamRepository, IUnitOfWork unitOfWork, IRiotApiClient riotApiClient)
        {
            this._matchDataTeamRepository = matchDataTeamRepository;
            this._unitOfWork = unitOfWork;
            this._riotApiClient = riotApiClient;
        }


        public IEnumerable<MatchDataTeam> Find(long databaseMatchId) { throw new NotImplementedException(); }
        public IEnumerable<MatchDataTeam> Find(List<long> databaseMatchId) { throw new NotImplementedException(); }
        public IEnumerable<MatchDataTeam> GetAll()
        {
            return this._matchDataTeamRepository.GetAll();
        }
        public void AddEntity(List<CottontailApi.Dto.Match.TeamStatsDto> listTeamData, long matchDatabaseId, int platform)
        {
            foreach (var teamData in listTeamData)
            {
                string banString = "";

                if (teamData.Bans != null)
                {
                    foreach (var bans in teamData.Bans)
                    {
                        banString += bans.ChampionId + ":" + bans.PickTurn + ";";
                    }
                }
                Entities.MatchDataTeam newTeamData = new MatchDataTeam()
                {
                    BaronKills = teamData.BaronKills,
                    BanCode = banString,
                    DominionVictoryScore = (int)teamData.DominionVictoryScore,
                    DragonKills = teamData.DragonKills,
                    FirstBaron = teamData.FirstBaron,
                    FirstBlood = teamData.FirstBlood,
                    FirstDragon = teamData.FirstDragon,
                    FirstInhibitor = teamData.FirstInhibitor,
                    FirstRiftHerald = teamData.FirstRiftHerald,
                    FirstTower = teamData.FirstTower,
                    InhibitorKills = teamData.InhibitorKills,
                    RiftHeraldKills = teamData.RiftHeraldKills,
                    TeamId = teamData.TeamId,
                    TowerKills = teamData.TowerKills,
                    VilemawKills = teamData.VilemawKills,
                    Winner = teamData.Win=="Win"?true:false,
                    Uid = ((long)matchDatabaseId*100+platform) * 1000 + (long)teamData.TeamId
                };

                newTeamData.FK_MatchDataID = matchDatabaseId;
                Save(newTeamData);
            }


            //return newTeamData;
        }
        public void Save(MatchDataTeam matchDataTeam)
        {
            this.Save(new List<MatchDataTeam>() { matchDataTeam });
        }
        public void Save(IEnumerable<MatchDataTeam> matchDataTeams)
        {
            foreach (var match in matchDataTeams)
            {
                if (match.ID == default(int))
                {
                    this._matchDataTeamRepository.Insert(match);
                }
                else
                {
                    this._matchDataTeamRepository.Update(match);
                    // il metodo update non dovrebbe mai essere usato. Almeno per l'attuale versione del sito lancio un'eccezione
                    throw new Exception("MatchDataTeamService.Save() sezione update().Questo metodo non dovrebbe essere evocato");
                }
            }

            this._matchDataTeamRepository.Save();
        }
        public void Delete(MatchDataTeam matchDataTeam) { throw new NotImplementedException(); }
        public void Delete(IList<MatchDataTeam> matchDataTeams) { throw new NotImplementedException(); }
    }
}