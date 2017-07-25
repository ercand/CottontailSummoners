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
#warning Bisogna Cambiare l'ApiCaller in uno che non tenga conto del RateLimiter
    /// <summary>
    /// 
    /// </summary>
    public class LolStatus : ILolStatus
    {
        private string ApiKey { get; set; }

        private BaseRiotApiCaller caller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public LolStatus(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        public List<RiotApi.Dto.LolStatus.ShardDto> GetShards()
        {
            string url = "http://status.leagueoflegends.com/shards";

            var json = caller.MakeApiCall(url, Enums.Region.GLOBAL);

            List<RiotApi.Dto.LolStatus.ShardDto> result = JsonConvert.DeserializeObject<List<RiotApi.Dto.LolStatus.ShardDto>>(json);

            return result;
        }
        public Task<List<RiotApi.Dto.LolStatus.ShardDto>> GetShardsAsync() { throw new NotImplementedException(); }

        public RiotApi.Dto.LolStatus.ShardStatusDto GetShardByRegion(Enums.Region region)
        {
            string url = "http://status.leagueoflegends.com/shards/" + GenericConverter.RegionToString(region).ToLower();

            var json = caller.MakeApiCall(url, region);

            RiotApi.Dto.LolStatus.ShardStatusDto result = JsonConvert.DeserializeObject<RiotApi.Dto.LolStatus.ShardStatusDto>(json);

            return result;
        }
        public Task<RiotApi.Dto.LolStatus.ShardStatusDto> GetShardByRegionAsync(Enums.Region region) { throw new NotImplementedException(); }
    }
}
