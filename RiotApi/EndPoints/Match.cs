using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.Match;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class Match : IMatch
    {
        private string ApiKey { get; set; }
        
        private BaseRiotApiCaller caller { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public Match(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        public MatchDetail GetMatchById(Enums.Region region, long matchId, bool timeLine)
        {
            string url = PrepareString(region, matchId, timeLine);

            var json = caller.MakeApiCall(url, region);

            MatchDetail result = JsonConvert.DeserializeObject<MatchDetail>(json);

            return result;
        }
        public async Task<MatchDetail> GetMatchByIdAsync(Enums.Region region, long matchId, bool timeLine) { throw new NotImplementedException(); }

        private string PrepareString(Enums.Region region, long matchId, bool timeLine)
        {
      //  https://na.api.pvp.net/api/lol/na/v2.2/match/443333333?includeTimeline=true&api_key=452b549c-c123-40f4-ae57-b22d8912c3ec
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);

        return String.Format("https://{0}/api/lol/{1}/v2.2/match/{2}?includeTimeline={3}&api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), matchId, timeLine ?"true":"false", ApiKey);
        }
    }
}
