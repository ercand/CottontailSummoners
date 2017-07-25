using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Commons.Exceptions;
using RiotApi.Dto.League;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class League : ILeague
    {
        private string ApiKey { get; set; }

        private BaseRiotApiCaller caller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public League(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }
        public Dictionary<long, List<LeagueDto>> GetSummonerLeaguesByIds(Enums.Region region, long[] summonerIds)
        {
            string url = PrepareString(region, false, summonerIds);

            var json = caller.MakeApiCall(url, region);

            Dictionary<long, List<LeagueDto>> result = JsonConvert.DeserializeObject<Dictionary<long, List<LeagueDto>>>(json);

            return result;
        }
        public Task<Dictionary<long, List<LeagueDto>>> GetSummonerLeaguesByIdsAsync(Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }


        public Dictionary<long, List<LeagueDto>> GetSummonerLeagueEntriesByIds(Enums.Region region, long[] summonerIds)
        {
            string url = PrepareString(region, true, summonerIds);

            var json = caller.MakeApiCall(url, region);

            Dictionary<long, List<LeagueDto>> result = JsonConvert.DeserializeObject<Dictionary<long, List<LeagueDto>>>(json);

            return result;
        }
        public Task<Dictionary<long, List<LeagueDto>>> GetSummonerLeagueEntriesByIdsAsync(Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        public Dictionary<string, List<LeagueDto>> GetTeamLeagueByIds(Enums.Region region, string[] teamIds)
        {
            if (teamIds.Length > 10)
            {
                throw new RiotApiException("E' consentito passare solo 10 Team ID - Ne sono stato passati:" + teamIds.Length, Enums.RiotApiErrorCode.BAD_REQUEST);
            }

            string url = PrepareTeamLeagueString(region, false, teamIds);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, List<LeagueDto>> result = JsonConvert.DeserializeObject<Dictionary<string, List<LeagueDto>>>(json);

            return result;
        }
        public Task<Dictionary<string, List<LeagueDto>>> GetTeamLeagueByIdsAsync(Enums.Region region, string[] teamIds) { throw new NotImplementedException(); }

        public Dictionary<string, List<LeagueDto>> GetTeamLeagueEntriesByIds(Enums.Region region, string[] teamIds)
        {
            if (teamIds.Length > 10)
            {
                throw new RiotApiException("E' consentito passare solo 10 Team ID - Ne sono stato passati:" + teamIds.Length, Enums.RiotApiErrorCode.BAD_REQUEST);
            }

            string url = PrepareTeamLeagueString(region, true, teamIds);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, List<LeagueDto>> result = JsonConvert.DeserializeObject<Dictionary<string, List<LeagueDto>>>(json);

            return result;
        }
        public Task<Dictionary<string, List<LeagueDto>>> GetTeamLeagueEntriesByIdsAsync(Enums.Region region, string[] teamIds) { throw new NotImplementedException(); }

        public LeagueDto GetChallengerLeague(Enums.Region region, Enums.LeagueQueueType queue)
        {
            string url = PrepareChallengerLeagueString(region, queue);

            var json = caller.MakeApiCall(url, region);

            LeagueDto result = JsonConvert.DeserializeObject<LeagueDto>(json);

            return result;
        }
        public Task<LeagueDto> GetChallengerLeagueAsync(Enums.Region region, Enums.LeagueQueueType queue) { throw new NotImplementedException(); }
        public LeagueDto GetMasterLeague(Enums.Region region, Enums.LeagueQueueType queue)
        {
            string url = PrepareMasterLeagueString(region, queue);

            var json = caller.MakeApiCall(url, region);

            LeagueDto result = JsonConvert.DeserializeObject<LeagueDto>(json);

            return result;
        }
        public Task<LeagueDto> GetMasterLeagueAsync(Enums.Region region, Enums.LeagueQueueType queue) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="entry"></param>
        /// <param name="summonerIds"></param>
        /// <returns></returns>
        private string PrepareString(Enums.Region region, bool entry, long[] summonerIds)
        {
            string summonerString = String.Join(",", summonerIds);
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/api/lol/{1}/v2.5/league/by-summoner/{2}{3}?api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), summonerString, entry ? "/entry" : "", ApiKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="entry"></param>
        /// <param name="teamIds"></param>
        /// <returns></returns>
        private string PrepareTeamLeagueString(Enums.Region region, bool entry, string[] teamIds)
        {
            string teamString = String.Join(",", teamIds);
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/api/lol/{1}/v2.5/league/by-team/{2}{3}?api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), teamString, entry ? "/entry" : "", ApiKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        private string PrepareChallengerLeagueString(Enums.Region region, Enums.LeagueQueueType queue)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/api/lol/{1}/v2.5/league/challenger?type={2}&api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), GenericConverter.LeagueQueueTypeToString(queue), ApiKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        private string PrepareMasterLeagueString(Enums.Region region, Enums.LeagueQueueType queue)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/api/lol/{1}/v2.5/league/master?type={2}&api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), GenericConverter.LeagueQueueTypeToString(queue), ApiKey);
        }
    }
}
