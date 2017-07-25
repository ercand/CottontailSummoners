using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.Team;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class Team : ITeam
    {
        private string ApiKey { get; set; }

        private BaseRiotApiCaller caller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public Team(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        /// <summary>
        /// Get teams mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">The region of the summoner.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs. Maximum allowed at once is 10.</param>
        /// <returns>Return Value: Map[string, List[TeamDto]] TeamDto - This object contains team information.</returns>
        public Dictionary<string, List<TeamDto>> GetTeamBySummonerIds(Enums.Region region, List<long> summonerIds)
        {
            string url = PrepareSummonerIdsString(region, summonerIds);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, List<RiotApi.Dto.Team.TeamDto>> result = JsonConvert.DeserializeObject<Dictionary<string, List<RiotApi.Dto.Team.TeamDto>>>(json);

            return result;
        }
        public Task<Dictionary<string, List<TeamDto>>> GetTeamBySummonerIdsAsync(Enums.Region region, List<long> summonerIds) { throw new NotImplementedException(); }

        /// <summary>
        /// Get teams mapped by team ID for a given list of team IDs.
        /// </summary>
        /// <param name="region">The region of the summoner.</param>
        /// <param name="teamIds">Comma-separated list of team IDs. Maximum allowed at once is 10.</param>
        /// <returns>Return Value: Map[string, TeamDto] TeamDto - This object contains team information.</returns>
        public Dictionary<string, TeamDto> GetTeamByTeamIds(Enums.Region region, List<string> teamIds)
        {
            string url = PrepareTeamIdsString(region, teamIds);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, TeamDto> result = JsonConvert.DeserializeObject<Dictionary<string, TeamDto>>(json);

            return result;
        }
        public Task<Dictionary<string, TeamDto>> GetTeamByTeamIdsAsync(Enums.Region region, List<string> teamIds) { throw new NotImplementedException(); }

        private string PrepareTeamIdsString(Enums.Region region, List<string> teamIds)
        {
            string str = string.Join(",", teamIds.ToArray());
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v2.4/team/{2}?api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), str, ApiKey);
        }

        private string PrepareSummonerIdsString(Enums.Region region, List<long> summonerIds)
        {
            string str = string.Join(",", summonerIds.ToArray());
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v2.4/team/by-summoner/{2}?api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), str, ApiKey);
        }
    }
}
