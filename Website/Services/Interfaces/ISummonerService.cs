using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface ISummonerService
    {
        IEnumerable<Summoner> Find(string summonersName, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false);
        IEnumerable<Summoner> Find(List<string> summonersName, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false);
        IEnumerable<Summoner> Find(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false);
        IEnumerable<Summoner> Find(List<long> riotSummonerId, CottontailApi.Commons.Enums.Platform platform, bool skipUpdate = false);
        void RefreshLastRanked(long riotSummonerId, CottontailApi.Commons.Enums.Platform platform, long riotMatchId);
        IEnumerable<Summoner> GetAll();
        void Save(Summoner summoner);
        void Save(IEnumerable<Summoner> summoners);
        void Delete(Summoner summoner);
        void Delete(IList<Summoner> summoners);
    }
}