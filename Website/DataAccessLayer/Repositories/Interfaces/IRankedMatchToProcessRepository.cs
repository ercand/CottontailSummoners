using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IRankedMatchToProcessRepository : IRepositoryBase<RankedMatchToProcess>
    {
        IEnumerable<RankedMatchToProcess> ContainMatch(List<long> riotMatchID, long platform);
        IEnumerable<RankedMatchToProcess> GetLast(int count, long platform);

    }
}
