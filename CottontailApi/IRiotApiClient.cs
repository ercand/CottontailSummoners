using CottontailApi.Dto.Summoner;
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

namespace CottontailApi
{
    public interface IRiotApiClient
    {
        float GetApiUsage(Enums.Platform platform);

        #region Summoner-V3
        /// <summary>
        ///  Get a summoner by account ID.
        /// </summary>
        /// <param name="accountId">Summoner account id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Summoner data</returns>
        SummonerDto GetSummonerByAccountId(long accountId, Enums.Platform platform);

        /// <summary>
        /// Get a summoner by summoner name.
        /// </summary>
        /// <param name="summonerName">Summoner name</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Summoner data</returns>
        SummonerDto GetSummonerByName(string summonerName, Enums.Platform platform);

        /// <summary>
        /// Get a summoner by summoner ID.
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Summoner data</returns>
        SummonerDto GetSummonerById(long summonerId, Enums.Platform platform);
        #endregion

        #region Runes-V3

        /// <summary>
        /// Get rune pages for a given summoner ID
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Summoner Rune pages</returns>
        RunePagesDto GetRunePagesBySummonerId(long summonerId, Enums.Platform platform);

        #endregion

        #region Masteries-V3

        /// <summary>
        /// Get mastery pages for a given summoner ID
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Summoner Mastery pages</returns>
        MasteryPagesDto GetMasteryPagesBySummonerId(long summonerId, Enums.Platform platform);

        #endregion

        #region Champion-Mastery-V3

        /// <summary>
        /// Get all champion mastery entries sorted by number of champion points descending
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Champion Mastery information</returns>
        List<ChampionMasteryDto> GetChampionMasteriesBySummonerId(long summonerId, Enums.Platform platform);

        /// <summary>
        /// Get a champion mastery by player ID and champion ID.
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="championId">Champion id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Champion Mastery information</returns>
        ChampionMasteryDto GetChampionMasteriesByChampionId(long summonerId, long championId, Enums.Platform platform);

        /// <summary>
        /// Get a player's total champion mastery score, which is the sum of individual champion mastery levels.
        /// </summary>
        /// <param name="summonerId">Summoner id</param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Champion Mastery score</returns>
        int GetChampionMasteriesScore(long summonerId, Enums.Platform platform);

        #endregion

        #region Champion-V3

        /// <summary>
        /// Retrieve all champions.
        /// </summary>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Collection of champion information. </returns>
        ChampionListDto GetAllChampion(Enums.Platform platform);

        /// <summary>
        /// Retrieve champion by ID.
        /// </summary>
        /// <param name="championId"></param>
        /// <param name="platform">Summoner platform</param>
        /// <returns>Contains champion information</returns>
        ChampionDto GetChampionById(long championId, Enums.Platform platform);

        #endregion

        #region League-V3

        /// <summary>
        /// Get the challenger league for a given queue
        /// </summary>
        /// <param name="queue">Queue league to request</param>
        /// <param name="platform"></param>
        /// <returns></returns>
        LeagueListDto GetLeagueChallenger(Enums.LeagueQueueType queue, Enums.Platform platform);

        /// <summary>
        /// Get the master league for a given queue
        /// </summary>
        /// <param name="queue">Queue league to request</param>
        /// <param name="platform"></param>
        /// <returns></returns>
        LeagueListDto GetLeagueMaster(Enums.LeagueQueueType queue, Enums.Platform platform);

        /// <summary>
        /// Get leagues in all queues for a given summoner ID
        /// </summary>
        /// <param name="summonerId"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        List<LeagueListDto> GetLeaguesBySummonerId(long summonerId, Enums.Platform platform);

        /// <summary>
        /// Get league positions in all queues for a given summoner ID
        /// </summary>
        /// <param name="summonerId"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        List<LeaguePositionDto> GetLeaguePositionBySummonerId(long summonerId, Enums.Platform platform);

        #endregion

        #region Match-V3

        /// <summary>
        /// Get match by match ID.
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="platform"></param>
        /// <returns>Match information</returns>
        MatchDto GetMatchById(long matchId, Enums.Platform platform);

        MatchlistDto GetRankedMatchListByAccountId(long accountId, Enums.Platform platform, Enums.RankedMatchlistQueueType queue = Enums.RankedMatchlistQueueType.ALL);

        /// <summary>
        /// Get matchlist for last 20 matches played on given account ID and platform ID.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="platform"></param>
        /// <returns>Collection of match recently played</returns>
        MatchlistDto GetRecentMatchListByAccountId(long accountId, Enums.Platform platform);

        MatchTimelineDto GetMatchTimelineByMatchId(long matchId, Enums.Platform platform);

        #endregion

        #region Spectator-V3

        /// <summary>
        /// Get current game information for the given summoner ID.
        /// </summary>
        /// <param name="summonerId"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        CurrentGameInfo GetCurrentGameBySummonerId(long summonerId, Enums.Platform platform);

        /// <summary>
        /// Get list of featured games.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        FeaturedGames GetFeaturedGames(Enums.Platform platform);

        #endregion
    }
}
