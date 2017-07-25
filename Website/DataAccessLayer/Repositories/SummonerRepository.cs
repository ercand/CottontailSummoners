using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class SummonerRepository : RepositoryBase<Summoner>, ISummonerRepository
    {
        public SummonerRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }

        public Summoner FindSummoner(long riotSummonerId, int platform)
        {
            var summoner = base.DataSource().Where(dbSummoner => dbSummoner.RiotSummonerID == riotSummonerId && dbSummoner.Platform == platform).SingleOrDefault();
            return summoner;
        }

        public IEnumerable<Summoner> FindSummoner(List<long> riotSummonerId, int platform)
        {
            // versione normale
            var summoner = base.DataSource().Join(riotSummonerId, dbSummoner => dbSummoner.RiotSummonerID, summonerToFind => summonerToFind, (up, summonerToFind) => up).Where(r => r.Platform == platform).Distinct();
            return summoner;

        }

        public IEnumerable<Summoner> FindSummoner(List<string> summonerName, int platform)
        {
            var summoner = base.DataSource().Join(summonerName, dbSummoner => dbSummoner.Name, summonerToFind => summonerToFind, (up, summonerToFind) => up).Where(r => r.Platform == platform).Distinct();
            return summoner;
        }
    }
}