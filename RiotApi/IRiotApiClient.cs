using RiotApi.Dto.League;
using RiotApi.Dto.Summoner;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi
{
    public interface IRiotApiClient
    {
        #region Properties
        /// <summary>
        /// champion-v1.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        IChampion Champion { get; set; }
        /// <summary>
        /// current-game-v1.0 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, PBE, RU, TR] 
        /// </summary>
        ICurrentGame CurrentGame { get; set; }
        /// <summary>
        /// featured-games-v1.0 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, PBE, RU, TR] 
        /// </summary>
        IFeaturedGames FeaturedGames { get; set; }
        /// <summary>
        /// game-v1.3 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        IGame Game { get; set; }
        /// <summary>
        /// league-v2.5 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        ILeague League { get; set; }
        /// <summary>
        /// lol-static-data-v1.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, PBE, RU, TR]
        /// </summary>
        ILolStaticData LolStaticData { get; set; }
        /// <summary>
        /// lol-status-v1.0 [BR, EUNE, EUW, LAN, LAS, NA, OCE, PBE, RU, TR]
        /// </summary>
        ILolStatus LolStatus { get; set; }
        /// <summary>
        /// match-v2.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        IMatch Match { get; set; }
        /// <summary>
        /// matchlist-v2.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        IMatchList MatchList { get; set; }
        /// <summary>
        /// stats-v1.3 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        IStats Stats { get; set; }
        /// <summary>
        /// summoner-v1.4 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        ISummoner Summoner { get; set; }
        /// <summary>
        /// team-v2.4 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        ITeam Team { get; set; }
        #endregion

        #region Summoner Methods
        //   SummonerDto GetSummoner(RiotApi.Commons.Enums.Region region, int summonerId);
    //    Task<SummonerDto> GetSummonerAsync(RiotApi.Commons.Enums.Region region, int summonerId);
        Dictionary<long, SummonerDto> GetSummonersById(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
        Task<Dictionary<long, SummonerDto>> GetSummonersByIdAsync(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
    //    SummonerDto GetSummoner(RiotApi.Commons.Enums.Region region, string summonerName);
    //    Task<SummonerDto> GetSummonerAsync(RiotApi.Commons.Enums.Region region, string summonerName);
        Dictionary<string, SummonerDto> GetSummonersByName(RiotApi.Commons.Enums.Region region, List<string> summonerNames);
        Task<Dictionary<string, SummonerDto>> GetSummonersByNameAsync(RiotApi.Commons.Enums.Region region, List<string> summonerNames);
        /*     SummonerBase GetSummonerName(RiotApi.Commons.Enums.Region region, int summonerId);
             Task<SummonerBase> GetSummonerNameAsync(RiotApi.Commons.Enums.Region region, int summonerId);
             List<SummonerBase> GetSummonersNames(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
             Task<List<SummonerBase>> GetSummonersNamesAsync(RiotApi.Commons.Enums.Region region, List<int> summonerIds);*/
        Dictionary<string, RunePagesDto> GetSummonersRunesById(RiotApi.Commons.Enums.Region region, int[] summonerIds);
        Task<Dictionary<string, RunePagesDto>> GetSummonersRunesByIdAsync(RiotApi.Commons.Enums.Region region, long[] summonerIds);

        Dictionary<string, MasteryPagesDto> GetSummonersMasteryById(RiotApi.Commons.Enums.Region region, int[] summonerIds);
        Task<Dictionary<string, MasteryPagesDto>> GetSummonersMasteryByIdAsync(RiotApi.Commons.Enums.Region region, long[] summonerIds);
        
        #endregion

        #region League Methods
        Dictionary<long, List<LeagueDto>> GetSummonersLeagues(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
        Task<Dictionary<long, List<LeagueDto>>> GetSummonersLeaguesAsync(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
   /*     Dictionary<long, List<LeagueDto>> GetSummonersEntireLeagues(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
        Task<Dictionary<long, List<LeagueDto>>> GetSummonersEntireLeaguesAsync(RiotApi.Commons.Enums.Region region, List<int> summonerIds);
        Dictionary<string, List<LeagueDto>> GetTeamsLeagues(RiotApi.Commons.Enums.Region region, List<string> teamIds);
        Task<Dictionary<string, List<LeagueDto>>> GetTeamsLeaguesAsync(RiotApi.Commons.Enums.Region region, List<string> teamIds);
        Dictionary<string, List<LeagueDto>> GetTeamsEntireLeagues(RiotApi.Commons.Enums.Region region, List<string> teamIds);
        Task<Dictionary<string, List<LeagueDto>>> GetTeamsEntireLeaguesAsync(RiotApi.Commons.Enums.Region region, List<string> teamIds);
        LeagueDto GetChallengerLeague(RiotApi.Commons.Enums.Region region, RiotApi.Commons.Enums.LeagueQueueType queue);
        Task<LeagueDto> GetChallengerLeagueAsync(RiotApi.Commons.Enums.Region region, RiotApi.Commons.Enums.LeagueQueueType queue);
        LeagueDto GetMasterLeague(RiotApi.Commons.Enums.Region region, RiotApi.Commons.Enums.LeagueQueueType queue);
        Task<LeagueDto> GetMasterLeagueAsync(RiotApi.Commons.Enums.Region region, RiotApi.Commons.Enums.LeagueQueueType queue);*/
        #endregion

        #region Stats Methods
        RiotApi.Dto.Stats.RankedStatsDto GetRankedStatsBySummonerId(RiotApi.Commons.Enums.Region region, long summonerId, RiotApi.Commons.Enums.SeasonNoPreSeasonType season);
        Task<RiotApi.Dto.Stats.RankedStatsDto> GetRankedStatsBySummonerIdAsync(RiotApi.Commons.Enums.Region region, long summonerId, RiotApi.Commons.Enums.SeasonNoPreSeasonType season);
        LeagueDto GetChallengerLeague(RiotApi.Commons.Enums.Region region, RiotApi.Commons.Enums.LeagueQueueType queueType);
        #endregion

        #region Static Data
        
        Dto.LolStaticData.ChampionListDto GetChampions();
        Dto.LolStaticData.ItemListDto GetItems();
        Dto.LolStaticData.MasteryListDto GetMasteries();
        Dto.LolStaticData.RealmDto GetRealm();
        Dto.LolStaticData.RuneListDto GetRunes();
        Dto.LolStaticData.SummonerSpellListDto GetSummonerSpells();

        #endregion
    }
}
