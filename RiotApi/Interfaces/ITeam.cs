using RiotApi.Commons;
using RiotApi.Dto.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface ITeam
    {
        /// <summary>
        /// Get teams mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">The region of the summoner.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs. Maximum allowed at once is 10.</param>
        /// <returns>Return Value: Map[string, List[TeamDto]] TeamDto - This object contains team information.</returns>
        Dictionary<string, List<TeamDto>> GetTeamBySummonerIds(Enums.Region region, List<long> summonerIds);
        Task<Dictionary<string, List<TeamDto>>> GetTeamBySummonerIdsAsync(Enums.Region region, List<long> summonerIds);

        /// <summary>
        /// Get teams mapped by team ID for a given list of team IDs.
        /// </summary>
        /// <param name="region">The region of the summoner.</param>
        /// <param name="teamIds">Comma-separated list of team IDs. Maximum allowed at once is 10.</param>
        /// <returns>Return Value: Map[string, TeamDto] TeamDto - This object contains team information.</returns>
        Dictionary<string, TeamDto> GetTeamByTeamIds(Enums.Region region, List<string> teamIds);
        Task<Dictionary<string, TeamDto>> GetTeamByTeamIdsAsync(Enums.Region region, List<string> teamIds);
    }
}
