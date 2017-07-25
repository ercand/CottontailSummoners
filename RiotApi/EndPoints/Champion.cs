using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.Champion;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class Champion : IChampion
    {
        private string ApiKey { get; set; }

        private BaseRiotApiCaller caller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public Champion(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        public ChampionListDto GetChampions(Enums.Region region, bool freeToPlay = false) 
        {
            string url = PrepareString(region, freeToPlay);

            var json = caller.MakeApiCall(url, region);

            ChampionListDto result = JsonConvert.DeserializeObject<ChampionListDto>(json);

            return result;
        }
        public Task<ChampionListDto> GetChampionsAsync(Enums.Region region, bool freeToPlay = false) { throw new NotImplementedException(); }
        public ChampionDto GetChampion(Enums.Region region, int championId) 
        {
            string url = PrepareString(region, championId);

            var json = caller.MakeApiCall(url, region);

            ChampionDto result = JsonConvert.DeserializeObject<ChampionDto>(json);

            return result;
        }
        public Task<ChampionDto> GetChampionAsync(Enums.Region region, int championId) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="freeToPlay"></param>
        /// <returns></returns>
        private string PrepareString(Enums.Region region, bool freeToPlay)
        {
            string strFreeToPlay = freeToPlay ? "true" : "false";
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v1.2/champion?freeToPlay={2}&api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), strFreeToPlay, ApiKey);
        }

        private string PrepareString(Enums.Region region, long championId)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v1.2/champion/{2}?api_key={3}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), championId, ApiKey);
        }
    }
}
