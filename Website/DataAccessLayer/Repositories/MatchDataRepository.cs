using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class MatchDataRepository : RepositoryBase<MatchData>, IMatchDataRepository
    {
        public MatchDataRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }

        public MatchData FindMatch(long riotMatchId, int platform)
        {
            var match = base.DataSource().Where(dbMatchData => dbMatchData.RiotMatchID == riotMatchId && dbMatchData.Platform == platform).SingleOrDefault();
            return match;
        }

        public IEnumerable<MatchData> FindMatch(List<long> riotMatchId, int platform)
        {
            var matchList = base.DataSource().Join(riotMatchId, dbMatchData => dbMatchData.RiotMatchID, matchToFind => matchToFind, (resultMatchData, resultMatchId) => resultMatchData).Where(r => r.Platform == platform).Distinct();
            return matchList;
        }

        public IEnumerable<MatchData> FindMatchBySummonerId(long riotSummonerId, int platform)
        {
            var matchList = base.DataSource().Where(r => r.DataParticipant.Any(s => s.RiotSummonerID == riotSummonerId) && r.Platform == platform);
            return matchList;
        }
    }
}