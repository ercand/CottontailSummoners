using RiotApi.Commons;
using RiotApi.Dto.Summoner;
using RiotApi.EndPoints;
using RiotApi.Interfaces;
using RiotApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotApi.Dto.League;
using RiotApi.Dto.Stats;
using RiotApi.Commons.Exceptions;

namespace RiotApi
{
    public class RiotApiClient : IRiotApiClient
    {
        BaseRiotApiCaller caller;

        /// <summary>
        /// champion-v1.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public IChampion Champion { get; set; }
        /// <summary>
        /// current-game-v1.0 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, PBE, RU, TR] 
        /// </summary>
        public ICurrentGame CurrentGame { get; set; }
        /// <summary>
        /// featured-games-v1.0 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, PBE, RU, TR] 
        /// </summary>
        public IFeaturedGames FeaturedGames { get; set; }
        /// <summary>
        /// game-v1.3 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public IGame Game { get; set; }
        /// <summary>
        /// league-v2.5 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public ILeague League { get; set; }
        /// <summary>
        /// lol-static-data-v1.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, PBE, RU, TR]
        /// </summary>
        public ILolStaticData LolStaticData { get; set; }
        /// <summary>
        /// lol-status-v1.0 [BR, EUNE, EUW, LAN, LAS, NA, OCE, PBE, RU, TR]
        /// </summary>
        public ILolStatus LolStatus { get; set; }
        /// <summary>
        /// match-v2.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public IMatch Match { get; set; }
        /// <summary>
        /// matchlist-v2.2 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public IMatchList MatchList { get; set; }
        /// <summary>
        /// stats-v1.3 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public IStats Stats { get; set; }
        /// <summary>
        /// summoner-v1.4 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public ISummoner Summoner { get; set; }
        /// <summary>
        /// team-v2.4 [BR, EUNE, EUW, KR, LAN, LAS, NA, OCE, RU, TR]
        /// </summary>
        public ITeam Team { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public RiotApiClient(string apiKey)
        {
            caller = RateLimitedRiotApiCaller.GetInstance();

            IChampion champion = new Champion(caller, apiKey);
            ICurrentGame currentGame = new CurrentGame(caller, apiKey);
            IFeaturedGames featuredGames = new FeaturedGames(caller, apiKey);
            IGame game = new Game(caller, apiKey);
            ILeague league = new League(caller, apiKey);
            ILolStaticData lolStaticData = new LolStaticData(apiKey);
#warning Bisogna Cambiare l'inizializzazione di LolStatus
            ILolStatus lolStatus = new LolStatus(caller, apiKey);
            IMatch match = new Match(caller, apiKey);
            IMatchList matchList = new MatchList(caller, apiKey);
            IStats stats = new Stats(caller, apiKey);
            ISummoner summoner = new Summoner(caller, apiKey);
            ITeam team = new Team(caller, apiKey);

            this.Champion = champion;
            this.CurrentGame = currentGame;
            this.FeaturedGames = featuredGames;
            this.Game = game;
            this.League = league;
            this.LolStaticData = lolStaticData;
            this.LolStatus = lolStatus;
            this.Match = match;
            this.MatchList = matchList;
            this.Stats = stats;
            this.Summoner = summoner;
            this.Team = team;
        }

        /// <summary>
        /// Constructs a Riot Client with given implemented service for each Riot service group.
        /// </summary>
        /// <param name="champion">The champion.</param>
        /// <param name="currentGame">The current game.</param>
        /// <param name="featuredGames">The featured games.</param>
        /// <param name="game">The game.</param>
        /// <param name="league">The league.</param>
        /// <param name="lolStaticData">The lol static data.</param>
        /// <param name="lolStatus">The lol status.</param>
        /// <param name="match">The match.</param>
        /// <param name="matchList">The match list.</param>
        /// <param name="stats">The stats.</param>
        /// <param name="summoner">The summoner.</param>
        /// <param name="team">The team.</param>
        public RiotApiClient(IChampion champion, ICurrentGame currentGame, IFeaturedGames featuredGames, IGame game, ILeague league, ILolStaticData lolStaticData,
            ILolStatus lolStatus, IMatch match, IMatchList matchList, IStats stats, ISummoner summoner, ITeam team)
        {
            this.Champion = champion;
            this.CurrentGame = currentGame;
            this.FeaturedGames = featuredGames;
            this.Game = game;
            this.League = league;
            this.LolStaticData = lolStaticData;
            this.LolStatus = lolStatus;
            this.Match = match;
            this.MatchList = matchList;
            this.Stats = stats;
            this.Summoner = summoner;
            this.Team = team;
        }

        #region Summoner

        public Dictionary<long, SummonerDto> GetSummonersById(RiotApi.Commons.Enums.Region region, List<int> summonerIds)
        {
            var split = summonerIds.Select(x => (long)x).Split(40);

            Dictionary<long, SummonerDto> result = new Dictionary<long, SummonerDto>();

            try
            {
                foreach (var item in split)
                {
                    var temp = Summoner.GetSummonersById(region, item.ToArray());
                    foreach (var summoner in temp)
                    {
                        result.Add(summoner.Key, summoner.Value);
                    }
                }
            }
            catch (RiotApiException riotEx)
            { }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }
        public async Task<Dictionary<long, SummonerDto>> GetSummonersByIdAsync(RiotApi.Commons.Enums.Region region, List<int> summonerIds)
        {
            throw new NotImplementedException();
            var split = summonerIds.Cast<long>().ToList<long>().Split(40);
            /*  List<SummonerDto> result = new List<SummonerDto>();

              foreach (var item in split)
              {
                  var tempResult = await Summoner.GetSummonersByIdAsync(region, item.ToArray<long>());
                  result.AddRange(tempResult.Values);
              }

              return result;*/
        }

        public Dictionary<string, SummonerDto> GetSummonersByName(RiotApi.Commons.Enums.Region region, List<string> summonerNames)
        {
            var split = summonerNames.Split(40);
            Dictionary<string, SummonerDto> result = new Dictionary<string, SummonerDto>();

            try
            {
                foreach (var item in split)
                {
                    var temp = Summoner.GetSummonersByName(region, item.ToArray());
                    foreach (var summoner in temp)
                    {
                        result.Add(summoner.Key, summoner.Value);
                    }
                }
            }
            catch (RiotApiException riotEx)
            { }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
        public async Task<Dictionary<string, SummonerDto>> GetSummonersByNameAsync(RiotApi.Commons.Enums.Region region, List<string> summonerNames) { throw new NotImplementedException(); }

        public Dictionary<string, RunePagesDto> GetSummonersRunesById(RiotApi.Commons.Enums.Region region, int[] summonerIds)
        {
            var split = summonerIds.Select(x => (long)x).Split(40);

            Dictionary<string, RunePagesDto> result = new Dictionary<string, RunePagesDto>();

            try
            {
                foreach (var item in split)
                {
                    var temp = Summoner.GetSummonersRunesById(region, item.ToArray());
                    foreach (var summoner in temp)
                    {
                        result.Add(summoner.Key, summoner.Value);
                    }
                }
            }
            catch (RiotApiException riotEx)
            { }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }
        public Task<Dictionary<string, RunePagesDto>> GetSummonersRunesByIdAsync(RiotApi.Commons.Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        public Dictionary<string, MasteryPagesDto> GetSummonersMasteryById(RiotApi.Commons.Enums.Region region, int[] summonerIds)
        {
            var split = summonerIds.Select(x => (long)x).Split(40);

            Dictionary<string, MasteryPagesDto> result = new Dictionary<string, MasteryPagesDto>();

            try
            {
                foreach (var item in split)
                {
                    var temp = Summoner.GetSummonerMasteryBySummonersId(region, item.ToArray());
                    foreach (var summoner in temp)
                    {
                        result.Add(summoner.Key, summoner.Value);
                    }
                }
            }
            catch (RiotApiException riotEx)
            { }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }
        public async Task<Dictionary<string, MasteryPagesDto>> GetSummonersMasteryByIdAsync(RiotApi.Commons.Enums.Region region, long[] summonerIds) { throw new NotImplementedException(); }

        #endregion

        #region League Methods

        public Dictionary<long, List<LeagueDto>> GetSummonersLeagues(RiotApi.Commons.Enums.Region region, List<int> summonerIds)
        {
            var listID = summonerIds.Select(i => (long)i).ToList().Split(10);
            Dictionary<long, List<LeagueDto>> result = new Dictionary<long, List<LeagueDto>>();


            foreach (var league in listID)
            {
                try
                {
                    var temp = League.GetSummonerLeagueEntriesByIds(region, league.ToArray());

                    foreach (var summoner in temp)
                    {
                        result.Add(summoner.Key, summoner.Value);
                    }
                }
                catch (RiotApi.Commons.Exceptions.RiotApiException riotEx)
                {
                }
                catch (Exception ex)
                {

                }
            }


            return result;
        }
        public async Task<Dictionary<long, List<LeagueDto>>> GetSummonersLeaguesAsync(RiotApi.Commons.Enums.Region region, List<int> summonerIds)
        { throw new NotImplementedException(); }


        public LeagueDto GetChallengerLeague(Enums.Region region, Enums.LeagueQueueType queueType)
        {
            try
            {
                return this.League.GetChallengerLeague(region, queueType);
            }
            catch (RiotApi.Commons.Exceptions.RiotApiException riotEx)
            {
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        #endregion

        #region Stats Methods

        public RankedStatsDto GetRankedStatsBySummonerId(RiotApi.Commons.Enums.Region region, long summonerId, RiotApi.Commons.Enums.SeasonNoPreSeasonType season)
        {
            RankedStatsDto result = null;

            try
            {
                result = Stats.GetRankedStatsBySummonerId(region, summonerId, season);
            }
            catch (RiotApiException riotEx)
            {
                // Error 404 - Stats data not found
                if (riotEx.RiotErrorCode == Enums.RiotApiErrorCode.NOT_FOUND)
                {
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                    result = new RankedStatsDto();
                    result.SummonerId = summonerId;
                    result.ModifyDate = Convert.ToInt64((DateTime.UtcNow - epoch).TotalMilliseconds);

                    result.Champions = new List<ChampionStatsDto>();
                    result.Champions.Add(new ChampionStatsDto() { ChampionId = 0, Stats = new AggregatedStatsDto() });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public async Task<RiotApi.Dto.Stats.RankedStatsDto> GetRankedStatsBySummonerIdAsync(RiotApi.Commons.Enums.Region region, long summonerId, RiotApi.Commons.Enums.SeasonNoPreSeasonType season)
        {
            RankedStatsDto result = null;

            try
            {
                result = await Stats.GetRankedStatsBySummonerIdAsync(region, summonerId, season);
            }
            catch (RiotApiException riotEx)
            {
                int edd = 3;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        #endregion

        #region Static Data
        public Dto.LolStaticData.ChampionListDto GetChampions()
        {
            Dto.LolStaticData.ChampionListDto result = null;
            try
            {
                result = this.LolStaticData.GetChampions();
            }
            catch (System.Exception ex)
            {

            }
            return result;
        }
        public Dto.LolStaticData.ItemListDto GetItems()
        {
            Dto.LolStaticData.ItemListDto result = null;
            try
            {
                result = this.LolStaticData.GetItems();
            }
            catch (System.Exception ex)
            {

            }
            return result;
        }
        public Dto.LolStaticData.MasteryListDto GetMasteries()
        {
            Dto.LolStaticData.MasteryListDto result = null;
            try
            {
                result = this.LolStaticData.GetMasteries();
            }
            catch (System.Exception ex)
            {

            }
            return result;
        }
        public Dto.LolStaticData.RealmDto GetRealm()
        {
            Dto.LolStaticData.RealmDto result = null;
            try
            {
                result = this.LolStaticData.Realm();
            }
            catch (System.Exception ex)
            {

            }
            return result;
        }
        public Dto.LolStaticData.RuneListDto GetRunes()
        {
            Dto.LolStaticData.RuneListDto result = null;
            try
            {
                result = this.LolStaticData.GetRunes();
            }
            catch (System.Exception ex)
            {

            }
            return result;
        }
        public Dto.LolStaticData.SummonerSpellListDto GetSummonerSpells()
        {
            Dto.LolStaticData.SummonerSpellListDto result = null;
            try
            {
                result = this.LolStaticData.GetSummonerSpells();
            }
            catch (System.Exception ex)
            {

            }
            return result;
        }

        #endregion
    }
}
