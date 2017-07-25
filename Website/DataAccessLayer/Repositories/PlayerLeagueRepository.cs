using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class PlayerLeagueRepository : RepositoryBase<PlayerLeague>, IPlayerLeagueRepository
    {
        public PlayerLeagueRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {
            
        }

        public PlayerLeague FindSummonerLeagueFromDatabaseId(long databaseSummonerId)
        {
            var playerLeague = base.DataSource().Where(dbPlayerLeague => dbPlayerLeague.ID == databaseSummonerId).SingleOrDefault();
            return playerLeague;
        }
        public IEnumerable<PlayerLeague> FindSummonerLeagueFromDatabaseId(List<long> databaseSummonerId)
        {
            var playerLeague = base.DataSource().Join(databaseSummonerId, dbPlayerLeague => dbPlayerLeague.ID, summonerToFind => summonerToFind, (dbPlayerLeague, summonerToFind) => dbPlayerLeague);
            return playerLeague;
        }

        public IEnumerable<PlayerLeague> FindSummonerLeague(long riotSummonerId, int platform)
        {
            var playerLeague = base.DataSource().Where(dbPlayerLeague => dbPlayerLeague.RiotSummonerID == riotSummonerId && dbPlayerLeague.Platform == platform);
            return playerLeague;
        }
        public IEnumerable<PlayerLeague> FindSummonerLeague(List<long> riotSummonerId, int platform)
        {
            var playerLeague = base.DataSource().Join(riotSummonerId, dbPlayerLeague => dbPlayerLeague.RiotSummonerID, summonerToFind => summonerToFind, (dbPlayerLeague, summonerToFind) => dbPlayerLeague).Where(dbPlayerLeague => dbPlayerLeague.Platform == platform);
            return playerLeague;
        }
        public IEnumerable<PlayerLeague> FindSummonerLeague(List<string> summonerName, int platform)
        {
            var playerLeague = base.DataSource().Join(summonerName, dbPlayerLeague => dbPlayerLeague.SummonerName, summonerToFind => summonerToFind, (dbPlayerLeague, summonerToFind) => dbPlayerLeague).Where(dbPlayerLeague => dbPlayerLeague.Platform == platform);
            return playerLeague;
        }
    }
}