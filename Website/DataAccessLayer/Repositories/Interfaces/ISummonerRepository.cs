
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface ISummonerRepository : IRepositoryBase<Summoner>
    {
        Summoner FindSummoner(long riotSummonerId, int platform);
        IEnumerable<Summoner> FindSummoner(List<long> riotSummonerId, int platform);

  //      Summoner FindSummoner(string summonerName, int region);
        IEnumerable<Summoner> FindSummoner(List<string> summonerName, int platform);
    }
}