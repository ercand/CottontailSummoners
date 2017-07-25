using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.CurrentGame;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class CurrentGame : ICurrentGame
    {
        private string ApiKey { get; set; }
        
        private BaseRiotApiCaller caller { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public CurrentGame(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        /// <summary>
        /// Get current game information for the given summoner ID
        /// </summary>
        /// <param name="region">The platform ID for which to fetch data.</param>
        /// <param name="summonerId">The ID of the summoner.</param>
        /// <returns>CurrentGameInfo</returns>
        public CurrentGameInfo GetCurrentGame(Enums.Region region, long summonerId)
        {
            string url = PrepareString(region, summonerId);
            
            var json = caller.MakeApiCall(url, region);

            CurrentGameInfo result = JsonConvert.DeserializeObject<CurrentGameInfo>(json);

            return result;
        }

        /// <summary>
        /// Get current game information for the given summoner ID
        /// </summary>
        /// <param name="region">The platform ID for which to fetch data.</param>
        /// <param name="summonerId">The ID of the summoner.</param>
        /// <returns>CurrentGameInfo</returns>
        public async Task<CurrentGameInfo> GetCurrentGameAsync(Enums.Region region, long summonerId)
        { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformId"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        private string PrepareString(Enums.Region region, long summonerId)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/observer-mode/rest/consumer/getSpectatorGameInfo/{1}/{2}?api_key={3}", regPoint.Host.ToLower(), regPoint.PlatformID, summonerId, ApiKey);
        }
    }
}
