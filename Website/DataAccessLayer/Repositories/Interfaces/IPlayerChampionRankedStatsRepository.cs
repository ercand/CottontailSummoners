using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IPlayerChampionRankedStatsRepository : IRepositoryBase<PlayerChampionRankedStats>
    {/**
        PlayerChampionRankedStats FindSingleChampionStatsById(int summonerDatabaseId, int championId, int season);
        IEnumerable<PlayerChampionRankedStats> FindChampionsStatsById(int summonerDatabaseId, List<int> championsId, int season);
        IEnumerable<PlayerChampionRankedStats> FindAllChampionStatsById(int summonerDatabaseId, int season);
        */



        // Metodi che richiedono l'ID del RiotSummoner
        PlayerChampionRankedStats FindSingleChampionStatsBySummonerId(long riotSummonerId, int platform, int championId, int season);
        IEnumerable<PlayerChampionRankedStats> FindChampionsStatsBySummonerId(long riotSummonerId, int platform, List<int> championsId, int season);
        IEnumerable<PlayerChampionRankedStats> FindAllChampionStatsBySummonerId(long riotSummonerId, int platform, int season);

        IEnumerable<PlayerChampionRankedStats> FindAllPlayerChampionStatsByRiotSummonerId(List<long> riotSummonerId, int platform, int season);
    }
}