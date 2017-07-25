using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IPlayerLeagueService
    {
        IEnumerable<PlayerLeague> Find(long summonersId, CottontailApi.Commons.Enums.Platform platform);
        IEnumerable<PlayerLeague> Find(List<long> summonersId, CottontailApi.Commons.Enums.Platform platform);
        IEnumerable<PlayerLeague> GetAll();
        void Save(PlayerLeague playerLeague);
        void Save(IEnumerable<PlayerLeague> playerLeague);
        void Delete(PlayerLeague playerLeague);
        void Delete(IList<PlayerLeague> playerLeague);
    }
}