using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class PlayerChampionRankedStatsRepository : RepositoryBase<PlayerChampionRankedStats>, IPlayerChampionRankedStatsRepository
    {
        public PlayerChampionRankedStatsRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }

        public PlayerChampionRankedStats FindSingleChampionStatsBySummonerId(long riotSummonerId, int platform, int championId, int season)
        {
            var stats = base.DataSource().Where(s => s.RiotSummonerID == riotSummonerId && s.Platform == platform && s.ChampionId == championId && s.Season == season).SingleOrDefault();
            return stats;
        }
        public IEnumerable<PlayerChampionRankedStats> FindChampionsStatsBySummonerId(long riotSummonerId, int platform, List<int> championsId, int season)
        {
            var stats = base.DataSource().Where(x => x.RiotSummonerID == riotSummonerId && x.Platform == platform && x.Season == season).Join(championsId, x => x.ChampionId, s => s, (x, s) => x);
            return stats;
        }
        public IEnumerable<PlayerChampionRankedStats> FindAllChampionStatsBySummonerId(long riotSummonerId, int platform, int season)
        {
            var stats = base.DataSource().Where(x => x.RiotSummonerID == riotSummonerId && x.Platform == platform && x.Season == season);
            return stats;
        }

        public IEnumerable<PlayerChampionRankedStats> FindAllPlayerChampionStatsByRiotSummonerId(List<long> riotSummonerId, int platform, int season)
        {
            var stats = base.DataSource().Join(riotSummonerId, x => x.RiotSummonerID, y => y, (x, y) => x).Where(x => x.Platform == platform && x.Season == season);
            return stats;
        }
    }
}