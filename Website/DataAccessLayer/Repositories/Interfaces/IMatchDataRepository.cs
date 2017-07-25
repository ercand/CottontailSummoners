using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IMatchDataRepository : IRepositoryBase<MatchData>
    {
        MatchData FindMatch(long riotMatchId, int platform);
        IEnumerable<MatchData> FindMatch(List<long> riotMatchId, int platform);
        IEnumerable<MatchData> FindMatchBySummonerId(long riotSummonerId, int platform);
    }
}
