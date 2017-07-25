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
    public class MatchList : IMatchList
    {
        private string ApiKey { get; set; }
        
        private BaseRiotApiCaller caller { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiCaller"></param>
        /// <param name="apiKey"></param>
        public MatchList(BaseRiotApiCaller apiCaller, string apiKey)
        {
            ApiKey = apiKey;
            caller = apiCaller;
        }

        /// <summary>
        /// Get the list of matches of a specific summoner synchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="summonerId">Summoner ID for which you want to retrieve the match list.</param>
        /// <param name="championIds">List of champion IDS to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        ///  will be ignored.</param>
        /// <param name="seasons">List of seasons for which to filter the match list by.</param>
        /// <param name="beginTime">The earliest date you wish to get matches from.</param>
        /// <param name="endTime">The latest date you wish to get matches from.</param>
        /// <param name="beginIndex">The begin index to use for fetching matches.</param>
        /// <param name="endIndex">The end index to use for fetching matches.</param>
        /// <returns>A list of Match references object.</returns>
        public RiotApi.Dto.Matchlist.MatchListDto GetMatchList(Enums.Region region, long summonerId,
            List<long> championIds = null, List<Enums.MatchlistQueueType> rankedQueues = null, List<Enums.SeasonType> seasons = null,
            DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            string url = PrepareString(region, summonerId);
            
            var json = caller.MakeApiCall(url, region);

            RiotApi.Dto.Matchlist.MatchListDto result = JsonConvert.DeserializeObject<RiotApi.Dto.Matchlist.MatchListDto>(json);

            return result;
            
        }

        /// <summary>
        /// Get the list of matches of a specific summoner synchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="summonerId">Summoner ID for which you want to retrieve the match list.</param>
        /// <param name="championIds">List of champion IDS to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        ///  will be ignored.</param>
        /// <param name="seasons">List of seasons for which to filter the match list by.</param>
        /// <param name="beginTime">The earliest date you wish to get matches from.</param>
        /// <param name="endTime">The latest date you wish to get matches from.</param>
        /// <param name="beginIndex">The begin index to use for fetching matches.</param>
        /// <param name="endIndex">The end index to use for fetching matches.</param>
        /// <returns>A list of Match references object.</returns>
        public async Task<RiotApi.Dto.Matchlist.MatchListDto> GetMatchListAsync(Enums.Region region, long summonerId,
            List<long> championIds = null, List<Enums.MatchlistQueueType> rankedQueues = null, List<Enums.SeasonType> seasons = null,
            DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null) { throw new NotImplementedException(); }


        private string PrepareString(Enums.Region region, long summonerId,
            List<long> championIds = null, List<Enums.MatchlistQueueType> rankedQueues = null, List<Enums.SeasonType> seasons = null,
            DateTime? beginTime = null, DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string> {
                    string.Format("beginIndex={0}", beginIndex),
                    string.Format("endIndex={0}", endIndex),
            };
            if (beginTime != null)
            {
                TimeSpan span = (DateTime)beginTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                addedArguments.Add(string.Format("beginTime={0}", (long)span.TotalMilliseconds));
            }
            if (endTime != null)
            {
                var span = (DateTime)endTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                addedArguments.Add(string.Format("endTime={0}", (long)span.TotalMilliseconds));
            }
            if (championIds != null)
            {
                string str = string.Join(",", championIds.ToArray());
                addedArguments.Add(string.Format("championIds={0}", str));
            }
            if (rankedQueues != null)
            {
                string str = string.Join(",", rankedQueues.ToArray());
                addedArguments.Add(string.Format("rankedQueues={0}", str));
            }
            if (seasons != null)
            {
                string str = string.Join(",", seasons.ToArray());
                addedArguments.Add(string.Format("seasons={0}", str));
            }

            RiotRegionalEndPoint.RegionalEndPoint regPoint = RiotRegionalEndPoint.GetRegionalEndPointByRegion(region);
            //          https://na.api.pvp.net/api/lol/na/v2.2/matchlist/by-summoner/23748066?championIds=266,103,84&rankedQueues=RANKED_SOLO_5x5,RANKED_TEAM_3x3&seasons=PRESEASON3,SEASON3,PRESEASON2014,SEASON2014&beginIndex=0&endIndex=1&api_key=452b549c-c123-40f4-ae57-b22d8912c3ec
            return String.Format("https://{0}/api/lol/{1}/v2.2/matchlist/by-summoner/{2}?{3}&api_key={4}", regPoint.Host.ToLower(), regPoint.Region.ToLower(), summonerId, String.Join("&", addedArguments), ApiKey);
        }
    }
}
