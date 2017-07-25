using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IRunePageService
    {
        IEnumerable<RunePage> Find(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform);

        IEnumerable<RunePage> GetAll();
        void Save(RunePage runePage);
        void Save(IEnumerable<RunePage> runePages);
        void Delete(RunePage runePage);
        void Delete(IList<RunePage> runePages);
    }
}
