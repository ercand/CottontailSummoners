using System.Collections.Generic;
using System.Linq;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class RunePageRepository : RepositoryBase<RunePage> ,IRunePageRepository
    {
        public RunePageRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }

        public IEnumerable<RunePage> FindRunePage(long riotSummonerId, int platform)
        {
            var runes = base.DataSource().Where(t => t.RiotSummonerID == riotSummonerId && t.Platform == platform);
            return runes;
        }
    }
}