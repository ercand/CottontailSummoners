using System.Collections.Generic;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IMasteryPageService
    {
        IEnumerable<MasteryPage> Find(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform);

        IEnumerable<MasteryPage> GetAll();
        void Save(MasteryPage runePage);
        void Save(IEnumerable<MasteryPage> runePages);
        void Delete(MasteryPage runePage);
        void Delete(IList<MasteryPage> runePages);
    }
}
