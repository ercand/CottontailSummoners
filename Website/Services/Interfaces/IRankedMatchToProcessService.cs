using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IRankedMatchToProcessService
    {
        IEnumerable<RankedMatchToProcess> GetRecent(int count, CottontailApi.Commons.Enums.Platform platform);
        void Add(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform);
         void Delete(RankedMatchToProcess toProcess);
    }
}
