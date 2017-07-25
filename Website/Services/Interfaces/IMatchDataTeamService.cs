using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IMatchDataTeamService
    {
        IEnumerable<MatchDataTeam> Find(long databaseMatchId);
        IEnumerable<MatchDataTeam> Find(List<long> databaseMatchId);
        IEnumerable<MatchDataTeam> GetAll();
        void AddEntity(List<CottontailApi.Dto.Match.TeamStatsDto> teamData, long matchDatabaseId, int platform);
        void Save(MatchDataTeam matchDataTeam);
        void Save(IEnumerable<MatchDataTeam> matchDataTeams);
        void Delete(MatchDataTeam matchDataTeam);
        void Delete(IList<MatchDataTeam> matchDataTeams);
    }
}
