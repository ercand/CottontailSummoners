using System.Collections.Generic;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IMasteryPageRepository : IRepositoryBase<MasteryPage>
    {
        IEnumerable<MasteryPage> FindMasteryPage(long riotSummonerId, int platform);
    }
}