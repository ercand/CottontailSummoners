using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.Stats;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class Stats : IStats
    {
        private string ApiKey { get; set; }

        private BaseRiotApiCaller caller { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public Stats(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        public RiotApi.Dto.Stats.RankedStatsDto GetRankedStatsBySummonerId(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season)
        {
            string url = PrepareRankedStatsString(region, summonerId, season);

            var json = caller.MakeApiCall(url, region);

            RankedStatsDto result = JsonConvert.DeserializeObject<RankedStatsDto>(json);

            return result;
        }
        public async Task<RiotApi.Dto.Stats.RankedStatsDto> GetRankedStatsBySummonerIdAsync(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season)
        {
            string url = PrepareRankedStatsString(region, summonerId, season);

            var json = await caller.MakeApiCallAsync(url, region);

            RankedStatsDto result = JsonConvert.DeserializeObject<RankedStatsDto>(json);

            return result;
        }

        public RiotApi.Dto.Stats.PlayerStatsSummaryListDto GetPlayerStatsBySummonerId(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season)
        {
            string url = PreparePlayerStatsString(region, summonerId, season);

            var json = caller.MakeApiCall(url, region);

            PlayerStatsSummaryListDto result = JsonConvert.DeserializeObject<PlayerStatsSummaryListDto>(json);

            return result;
        }
        public Task<RiotApi.Dto.Stats.PlayerStatsSummaryListDto> GetPlayerStatsBySummonerIdAsync(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season) { throw new NotImplementedException(); }

        private string PrepareRankedStatsString(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v1.3/stats/by-summoner/{2}/ranked?season={3}&api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), summonerId, GenericConverter.SeasonNoPreSeasonTypeToString(season), ApiKey);
        }

        private string PreparePlayerStatsString(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season)
        {
            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            return String.Format("https://{0}/api/lol/{1}/v1.3/stats/by-summoner/{2}/summary?season={3}&api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), summonerId, GenericConverter.SeasonNoPreSeasonTypeToString(season), ApiKey);
        }
    }
}
