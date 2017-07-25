using System.Collections.Generic;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IRunePageRepository : IRepositoryBase<RunePage>
    {
        IEnumerable<RunePage> FindRunePage(long riotSummonerId, int platform);
    }
}
