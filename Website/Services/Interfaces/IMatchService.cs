using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IMatchService
    {
        IEnumerable<MatchData> Find(CottontailApi.Dto.Match.MatchlistDto recentGame, CottontailApi.Commons.Enums.Platform platform);
        MatchData Find(long riotMatchId, CottontailApi.Commons.Enums.Platform platform);
        IEnumerable<MatchData> FindBySummonerRiotId(long summonerRiotId, CottontailApi.Commons.Enums.Platform platform);
        IEnumerable<MatchData> GetAll();
        void Save(MatchData matchData);
        void Save(IEnumerable<MatchData> matchData);
        void Delete(MatchData matchData);
        void Delete(IList<MatchData> matchData);
    }
}
