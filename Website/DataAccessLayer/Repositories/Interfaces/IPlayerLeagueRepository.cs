using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IPlayerLeagueRepository : IRepositoryBase<PlayerLeague>
    {
        /// <summary>
        /// Cerca la League di un summoner in base all'ID della primary key della tabella summoner
        /// </summary>
        /// <param name="databaseSummonerId"></param>
        /// <returns></returns>
        PlayerLeague FindSummonerLeagueFromDatabaseId(long databaseSummonerId);
        IEnumerable<PlayerLeague> FindSummonerLeagueFromDatabaseId(List<long> databaseSummonerId);

        IEnumerable<PlayerLeague> FindSummonerLeague(long riotSummonerId, int platform);
        IEnumerable<PlayerLeague> FindSummonerLeague(List<long> riotSummonerId, int platform);

     //   IEnumerable<PlayerLeague> FindSummonerLeague(string summonerName, string region);
        IEnumerable<PlayerLeague> FindSummonerLeague(List<string> summonerName, int platform);
    }
}