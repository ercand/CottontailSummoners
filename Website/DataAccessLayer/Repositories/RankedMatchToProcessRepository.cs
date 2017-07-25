using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class RankedMatchToProcessRepository : RepositoryBase<RankedMatchToProcess>, IRankedMatchToProcessRepository
    {
        public RankedMatchToProcessRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }

        public IEnumerable<RankedMatchToProcess> ContainMatch(List<long> riotMatchID, long platform)
        {
            var r = base.DataSource().Join(riotMatchID, innKey => innKey.RiotMatchID, outKey => outKey, (a, b) => a).Where(res => res.Platform == platform);
            return r;
        }

        public IEnumerable<RankedMatchToProcess> GetLast(int count, long platform)
        {
            var r = base.DataSource().Where(m => m.Platform == platform).Take(count);
            return r;
        }
    }
}