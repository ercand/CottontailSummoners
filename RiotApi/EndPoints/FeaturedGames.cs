using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class FeaturedGames : IFeaturedGames
    {
        private string ApiKey { get; set; }
        
        private BaseRiotApiCaller caller { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public FeaturedGames(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        public Dto.FeaturedGames.FeaturedGames GetFeaturedGames(Enums.Region region)
        {
            string url = PrepareString(region);

            var json = caller.MakeApiCall(url, region);

            Dto.FeaturedGames.FeaturedGames result = JsonConvert.DeserializeObject<Dto.FeaturedGames.FeaturedGames>(json);

            return result;
        }
        public async Task<Dto.FeaturedGames.FeaturedGames> GetFeaturedGamesAsync(Enums.Region region) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private string PrepareString(Enums.Region region)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

            return String.Format("https://{0}/observer-mode/rest/featured?api_key={1}", regPoint.Host.ToLower(), ApiKey);
        }
    }
}
