using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.Game;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class Game : IGame
    {
        private string ApiKey { get; set; }
        
        private BaseRiotApiCaller caller { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public Game(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }


        public RecentGamesDto GetRecentGames(Enums.Region region, long summonerId)
        {
            string url = PrepareString(region, summonerId);

            var json = caller.MakeApiCall(url, region);

            RecentGamesDto result = JsonConvert.DeserializeObject<RecentGamesDto>(json);

            return result;
        }
        public async Task<RecentGamesDto> GetRecentGamesAsync(Enums.Region region, long summonerId) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private string PrepareString(Enums.Region region, long summonerId)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/api/lol/{1}/v1.3/game/by-summoner/{2}/recent?api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), summonerId, ApiKey);
        }
    }
}
