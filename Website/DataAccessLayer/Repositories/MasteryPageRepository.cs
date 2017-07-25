using System.Collections.Generic;
using System.Linq;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class MasteryPageRepository : RepositoryBase<MasteryPage>, IMasteryPageRepository
    {
        public MasteryPageRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }

        public IEnumerable<MasteryPage> FindMasteryPage(long riotSummonerId, int platform)
        {
            var runes = base.DataSource().Where(t => t.RiotSummonerID == riotSummonerId && t.Platform == platform);
            return runes;
        }
    }
}