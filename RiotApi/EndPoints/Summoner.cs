using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.Summoner;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    /// <summary>
    /// 
    /// </summary>
    public class Summoner : ISummoner
    {
        private enum RequestTypeInternal
        {
            MASTERY,
            RUNE,
            SUMMONER,
            SUMMONER_NAME
        }
        private string ApiKey { get; set; }

        private BaseRiotApiCaller caller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public Summoner(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        /// <summary>
        /// Get summoner objects mapped by standardized summoner name for a given list of summoner names.
        /// Implementation Notes
        /// The response object contains the summoner objects mapped by the standardized summoner name, 
        /// which is the summoner name in all lower case and with spaces removed.
        /// Use this version of the name when checking if the returned object contains the data for a given summoner.
        /// This API will also accept standardized summoner names as valid parameters, although they are not required.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerNames">Comma-separated list of summoner names or standardized summoner names associated with summoners to retrieve. Maximum allowed at once is 40.</param>
        /// <returns> Map[string, SummonerDto] SummonerDto - This object contains summoner information.</returns>
        public Dictionary<string, SummonerDto> GetSummonersByName(Enums.Region region, string[] summonerNames)
        {
            string url = PrepareGetSummonersByNames(region, summonerNames);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, SummonerDto> result = JsonConvert.DeserializeObject<Dictionary<string, SummonerDto>>(json);

            return result;
        }
        public Task<Dictionary<string, SummonerDto>> GetSummonersByNameAsync(Enums.Region region, string[] summonerNames) { throw new NotImplementedException(); }

        /// <summary>
        /// Get summoner objects mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with summoners to retrieve. Maximum allowed at once is 40.</param>
        /// <returns>Return Value: Map[string, SummonerDto] SummonerDto - This object contains summoner information.</returns>
        public Dictionary<long, SummonerDto> GetSummonersById(Enums.Region region, long[] summonerIds)
        {
            string url = PrepareString(region, summonerIds, RequestTypeInternal.SUMMONER);

            var json = caller.MakeApiCall(url, region);

            Dictionary<long, SummonerDto> result = JsonConvert.DeserializeObject<Dictionary<long, SummonerDto>>(json);

            return result;
        }
        public Task<Dictionary<long, SummonerDto>> GetSummonersByIdAsync(Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        /// <summary>
        /// Get mastery pages mapped by summoner ID for a given list of summoner IDs
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with masteries to retrieve. Maximum allowed at once is 40.</param>
        /// <returns></returns>
        public Dictionary<string, MasteryPagesDto> GetSummonerMasteryBySummonersId(Enums.Region region, long[] summonerIds)
        {
            string url = PrepareString(region, summonerIds, RequestTypeInternal.MASTERY);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, MasteryPagesDto> result = JsonConvert.DeserializeObject<Dictionary<string, MasteryPagesDto>>(json);

            return result;
        }
        public Task<Dictionary<string, MasteryPagesDto>> GetSummonerMasteryBySummonersIdAsync(Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        /// <summary>
        /// Get summoner names mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with summoner names to retrieve. Maximum allowed at once is 40.</param>
        /// <returns>Return Value: Map[string, string]</returns>
        public Dictionary<string, string> GetSummonersNameById(Enums.Region region, long[] summonerIds)
        {
            string url = PrepareString(region, summonerIds, RequestTypeInternal.SUMMONER_NAME);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return result;
        }
        public Task<Dictionary<string, string>> GetSummonersNameByIdAsync(Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        /// <summary>
        /// Get rune pages mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with runes to retrieve. Maximum allowed at once is 40.</param>
        /// <returns>Return Value: Map[string, RunePagesDto] RunePagesDto - This object contains rune pages information.</returns>
        public Dictionary<string, RunePagesDto> GetSummonersRunesById(Enums.Region region, long[] summonerIds)
        {
            string url = PrepareString(region, summonerIds, RequestTypeInternal.RUNE);

            var json = caller.MakeApiCall(url, region);

            Dictionary<string, RunePagesDto> result = JsonConvert.DeserializeObject<Dictionary<string, RunePagesDto>>(json);

            return result;
        }
        public Task<Dictionary<string, RunePagesDto>> GetSummonersRunesByIdAsync(Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        string PrepareGetSummonersByNames(Enums.Region region, string[] summonerNames)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v1.4/summoner/by-name/{2}?api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), String.Join(",", summonerNames), ApiKey);
        }
        string PrepareString(Enums.Region region, long[] summonerIds, RequestTypeInternal requestType)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            string argumentString = "";


            switch (requestType)
            {
                case RequestTypeInternal.MASTERY:
                    argumentString = "/masteries";
                    break;
                case RequestTypeInternal.SUMMONER:
                    argumentString = "";
                    break;
                case RequestTypeInternal.SUMMONER_NAME:
                    argumentString = "/name";
                    break;
                case RequestTypeInternal.RUNE:
                    argumentString = "/runes";
                    break;
                default:
                    break;
            }
            return String.Format("https://{0}/api/lol/{1}/v1.4/summoner/{2}{3}?api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), String.Join(",", summonerIds), argumentString, ApiKey);
        }
    }
}
