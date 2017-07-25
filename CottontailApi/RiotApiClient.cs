using CottontailApi.Dto.Summoner;
using CottontailApi.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;
using CottontailApi.Dto.Champion;
using CottontailApi.Dto.ChampionMastery;
using CottontailApi.Dto.League;
using CottontailApi.Dto.Masteries;
using CottontailApi.Dto.Match;
using CottontailApi.Dto.Runes;
using CottontailApi.Dto.Spectator;
using CottontailApi.Http;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace CottontailApi
{
    public class RiotApiClient : IRiotApiClient
    {
        private const string SummonerRootUrl = "/lol/summoner/v3/summoners";
        private const string SummonerByAccountIdUrl = "/by-account/{0}";
        private const string SummonerByNameUrl = "/by-name/{0}";
        private const string SummonerBySummonerIdUrl = "/{0}";

        private const string RunesRootUrl = "/lol/platform/v3/runes/by-summoner";
        private const string RunesBySummonerId = "/{0}";

        private const string MasteriesRootUrl = "/lol/platform/v3/masteries/by-summoner";
        private const string MasteriesBySummonerId = "/{0}";

        private const string ChampionMasteryRootUrl = "/lol/champion-mastery/v3";
        private const string ChampionMasteryBySummonerIdUrl = "/champion-masteries/by-summoner/{0}";
        private const string ChampionMasteryByChampionIdUrl = "/champion-masteries/by-summoner/{0}/by-champion/{1}";
        private const string ChampionMasteryScoreUrl = "/scores/by-summoner/{0}";

        private const string ChampionRootUrl = "/lol/platform/v3/champions";
        private const string ChampionByChampionIdUrl = "/{0}";

        private const string LeagueRootUrl = "/lol/league/v3";
        private const string LeagueChallengerByQueueUrl = "/challengerleagues/by-queue/{0}";
        private const string LeagueMasterByQueueUrl = "/masterleagues/by-queue/{0}";
        private const string LeaguesBySummonerIdUrl = "/leagues/by-summoner/{0}";
        private const string LeaguePositionBySummonerIdUrl = "/positions/by-summoner/{0}";

        private const string MatchRootUrl = "/lol/match/v3";
        private const string MatchByMatchIdtUrl = "/matches/{0}";
        private const string MatchRankedListByAccountIdUrl = "/matchlists/by-account/{0}";
        private const string MatchRecentMatchListByAccountIdUrl = "/matchlists/by-account/{0}/recent";
        private const string MatchMatchTimelineByMatchIdUrl = "/timelines/by-match/{0}";

        private const string SpectatorRootUrl = "/lol/spectator/v3";
        private const string SpectatorCurrentGameBySummonerIdUrl = "/active-games/by-summoner/{0}";
        private const string SpectatorFeaturedGamesUrl = "/featured-games";

        private string ApiKeyUrl;
        private string ApiKey;
        private IRateLimitedRiotApiRequester requester;

        private LogManager.Logger Logger = LogManager.Logger.GetInstance();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public RiotApiClient(string apiKey)
        {
            Logger.Info("RiotApiClient Inizialized", LogManager.LogOutput.Console);

            requester = RateLimitedRiotApiRequester.GetInstance();

            if (String.IsNullOrEmpty(apiKey) == false && String.IsNullOrWhiteSpace(apiKey) == false)
            {
                this.ApiKey = apiKey;
                this.ApiKeyUrl = "api_key=" + apiKey;
            }
            else
                Logger.Error("Api Key is null o empty", LogManager.LogOutput.File);
        }

        /// <summary>
        /// Real time Api usage 
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public float GetApiUsage(Enums.Platform platform)
        {
            return this.requester.GetRateLimiterUsage(platform);
        }
        #region Summoner-V3
        public SummonerDto GetSummonerByAccountId(long accountId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(SummonerRootUrl + SummonerByAccountIdUrl, accountId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(SummonerRootUrl + SummonerByAccountIdUrl, ""));
            var result = JsonConvert.DeserializeObject<SummonerDto>(summoner);

            return result;
        }

        public SummonerDto GetSummonerById(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, summonerId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(SummonerRootUrl + SummonerBySummonerIdUrl, ""));
            var result = JsonConvert.DeserializeObject<SummonerDto>(summoner);

            return result;
        }

        public SummonerDto GetSummonerByName(string summonerName, Enums.Platform platform)
        {
            string relativeUrl = string.Format(SummonerRootUrl + SummonerByNameUrl, summonerName) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(SummonerRootUrl + SummonerByNameUrl, ""));
            var result = JsonConvert.DeserializeObject<SummonerDto>(summoner);

            return result;
        }
        #endregion

        #region Runes-V3

        public RunePagesDto GetRunePagesBySummonerId(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(RunesRootUrl + RunesBySummonerId, summonerId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(RunesRootUrl + RunesBySummonerId, ""));
            var result = JsonConvert.DeserializeObject<RunePagesDto>(summoner);

            return result;
        }

        #endregion

        #region Masteries-V3

        public MasteryPagesDto GetMasteryPagesBySummonerId(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(MasteriesRootUrl + MasteriesBySummonerId, summonerId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(MasteriesRootUrl + MasteriesBySummonerId, ""));
            var result = JsonConvert.DeserializeObject<MasteryPagesDto>(summoner);

            return result;
        }

        #endregion

        #region Champion-Mastery-V3

        /// <summary>
        /// Get all champion mastery entries sorted by number of champion points descending
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Champion Mastery information</returns>
        public List<ChampionMasteryDto> GetChampionMasteriesBySummonerId(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(ChampionMasteryRootUrl + ChampionMasteryBySummonerIdUrl, summonerId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(ChampionMasteryRootUrl + ChampionMasteryBySummonerIdUrl, ""));
            var result = JsonConvert.DeserializeObject<List<ChampionMasteryDto>>(summoner);

            return result;
        }

        /// <summary>
        /// Get a champion mastery by player ID and champion ID.
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="championId">Champion id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Champion Mastery information</returns>
        public ChampionMasteryDto GetChampionMasteriesByChampionId(long summonerId, long championId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(ChampionMasteryRootUrl + ChampionMasteryByChampionIdUrl, summonerId, championId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(ChampionMasteryRootUrl + ChampionMasteryByChampionIdUrl, "", ""));
            var result = JsonConvert.DeserializeObject<ChampionMasteryDto>(summoner);

            return result;
        }

        /// <summary>
        /// Get a player's total champion mastery score, which is the sum of individual champion mastery levels.
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Champion Mastery score</returns>
        public int GetChampionMasteriesScore(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(ChampionMasteryRootUrl + ChampionMasteryScoreUrl, summonerId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(ChampionMasteryRootUrl + ChampionMasteryScoreUrl, ""));
            var result = JsonConvert.DeserializeObject<int>(summoner);

            return result;
        }

        #endregion

        #region Champion-V3

        public ChampionListDto GetAllChampion(Enums.Platform platform)
        {
            string relativeUrl = ChampionRootUrl + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, ChampionRootUrl);
            var result = JsonConvert.DeserializeObject<ChampionListDto>(summoner);

            return result;
        }

        public ChampionDto GetChampionById(long championId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(ChampionRootUrl + ChampionByChampionIdUrl, championId) + "?" + ApiKeyUrl;
            var summoner = requester.GetRequestApiCall(relativeUrl, platform, string.Format(ChampionRootUrl + ChampionByChampionIdUrl, ""));
            var result = JsonConvert.DeserializeObject<ChampionDto>(summoner);

            return result;
        }

        #endregion

        #region League-V3

        public LeagueListDto GetLeagueChallenger(Enums.LeagueQueueType queue, Enums.Platform platform)
        {
            string relativeUrl = string.Format(LeagueRootUrl + LeagueChallengerByQueueUrl, GenericConverter.LeagueQueueTypeToString(queue)) + "?" + ApiKeyUrl;
            var league = requester.GetRequestApiCall(relativeUrl, platform, string.Format(LeagueRootUrl + LeagueChallengerByQueueUrl, ""));
            var result = JsonConvert.DeserializeObject<LeagueListDto>(league);

            return result;
        }

        public LeagueListDto GetLeagueMaster(Enums.LeagueQueueType queue, Enums.Platform platform)
        {
            string relativeUrl = string.Format(LeagueRootUrl + LeagueMasterByQueueUrl, GenericConverter.LeagueQueueTypeToString(queue)) + "?" + ApiKeyUrl;
            var league = requester.GetRequestApiCall(relativeUrl, platform, string.Format(LeagueRootUrl + LeagueMasterByQueueUrl, ""));
            var result = JsonConvert.DeserializeObject<LeagueListDto>(league);

            return result;
        }

        public List<LeagueListDto> GetLeaguesBySummonerId(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(LeagueRootUrl + LeaguesBySummonerIdUrl, summonerId) + "?" + ApiKeyUrl;
            var league = requester.GetRequestApiCall(relativeUrl, platform, string.Format(LeagueRootUrl + LeaguesBySummonerIdUrl, ""));
            var result = JsonConvert.DeserializeObject<List<LeagueListDto>>(league);

            return result;
        }

        public List<LeaguePositionDto> GetLeaguePositionBySummonerId(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(LeagueRootUrl + LeaguePositionBySummonerIdUrl, summonerId) + "?" + ApiKeyUrl;
            var league = requester.GetRequestApiCall(relativeUrl, platform, string.Format(LeagueRootUrl + LeaguePositionBySummonerIdUrl, ""));
            var result = JsonConvert.DeserializeObject<List<LeaguePositionDto>>(league);

            return result;
        }

        #endregion

        #region Match-V3

        public MatchDto GetMatchById(long matchId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(MatchRootUrl + MatchByMatchIdtUrl, matchId) + "?" + ApiKeyUrl;
            var match = requester.GetRequestApiCall(relativeUrl, platform, string.Format(MatchRootUrl + MatchByMatchIdtUrl, ""));
            var result = JsonConvert.DeserializeObject<MatchDto>(match);

            return result;
        }

        public MatchlistDto GetRankedMatchListByAccountId(long accountId, Enums.Platform platform, Enums.RankedMatchlistQueueType queue = Enums.RankedMatchlistQueueType.ALL)
        {
            string parameters = "";

            if (queue != Enums.RankedMatchlistQueueType.ALL)
            {
                parameters += "queue=" + (int)queue + "&";
            }

            string relativeUrl = string.Format(MatchRootUrl + MatchRankedListByAccountIdUrl, accountId) + "?" + parameters + ApiKeyUrl;
            var match = requester.GetRequestApiCall(relativeUrl, platform, string.Format(MatchRootUrl + MatchRankedListByAccountIdUrl, ""));
            var result = JsonConvert.DeserializeObject<MatchlistDto>(match);

            return result;
        }

        public MatchlistDto GetRecentMatchListByAccountId(long accountId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(MatchRootUrl + MatchRecentMatchListByAccountIdUrl, accountId) + "?" + ApiKeyUrl;
            var match = requester.GetRequestApiCall(relativeUrl, platform, string.Format(MatchRootUrl + MatchRecentMatchListByAccountIdUrl, ""));
            var result = JsonConvert.DeserializeObject<MatchlistDto>(match);

            return result;
        }

        public MatchTimelineDto GetMatchTimelineByMatchId(long matchId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(MatchRootUrl + MatchMatchTimelineByMatchIdUrl, matchId) + "?" + ApiKeyUrl;
            var match = requester.GetRequestApiCall(relativeUrl, platform, string.Format(MatchRootUrl + MatchMatchTimelineByMatchIdUrl, ""));
            var result = JsonConvert.DeserializeObject<MatchTimelineDto>(match);

            return result;
        }
        #endregion

        #region Spectator-V3

        public CurrentGameInfo GetCurrentGameBySummonerId(long summonerId, Enums.Platform platform)
        {
            string relativeUrl = string.Format(SpectatorRootUrl + SpectatorCurrentGameBySummonerIdUrl, summonerId) + "?" + ApiKeyUrl;
            var currentGame = requester.GetRequestApiCall(relativeUrl, platform, string.Format(SpectatorRootUrl + SpectatorCurrentGameBySummonerIdUrl, ""));
            var result = JsonConvert.DeserializeObject<CurrentGameInfo>(currentGame);

            return result;
        }
        public FeaturedGames GetFeaturedGames(Enums.Platform platform)
        {
            string relativeUrl = SpectatorRootUrl + SpectatorFeaturedGamesUrl + "?" + ApiKeyUrl;
            var featuredGames = requester.GetRequestApiCall(relativeUrl, platform, SpectatorRootUrl + SpectatorFeaturedGamesUrl);
            var result = JsonConvert.DeserializeObject<FeaturedGames>(featuredGames);

            return result;
        }
        #endregion

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
