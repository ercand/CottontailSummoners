using RiotApi.Commons;
using RiotApi.Dto.League;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface ILeague
    {
        /// <summary>
        /// Get leagues mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="summonerIds"></param>
        /// <returns></returns>
        Dictionary<long, List<LeagueDto>> GetSummonerLeaguesByIds(Enums.Region region, long[] summonerIds);
        Task<Dictionary<long, List<LeagueDto>>> GetSummonerLeaguesByIdsAsync(Enums.Region region, long[] summonerIds);


        Dictionary<long, List<LeagueDto>> GetSummonerLeagueEntriesByIds(Enums.Region region, long[] summonerIds);
        Task<Dictionary<long, List<LeagueDto>>> GetSummonerLeagueEntriesByIdsAsync(Enums.Region region, long[] summonerIds);

        Dictionary<string, List<LeagueDto>> GetTeamLeagueByIds(Enums.Region region, string[] teamIds);
        Task<Dictionary<string, List<LeagueDto>>> GetTeamLeagueByIdsAsync(Enums.Region region, string[] teamIds);

        Dictionary<string, List<LeagueDto>> GetTeamLeagueEntriesByIds(Enums.Region region, string[] teamIds);
        Task<Dictionary<string, List<LeagueDto>>> GetTeamLeagueEntriesByIdsAsync(Enums.Region region, string[] teamIds);


        LeagueDto GetChallengerLeague(Enums.Region region, Enums.LeagueQueueType queue);
        Task<LeagueDto> GetChallengerLeagueAsync(Enums.Region region, Enums.LeagueQueueType queue);
        LeagueDto GetMasterLeague(Enums.Region region, Enums.LeagueQueueType queue);
        Task<LeagueDto> GetMasterLeagueAsync(Enums.Region region, Enums.LeagueQueueType queue);
    }
}
