using RiotApi.Commons;
using RiotApi.Dto.Champion;
using RiotApi.Dto.CurrentGame;
using RiotApi.Dto.Game;
using RiotApi.Dto.League;
using RiotApi.Dto.Match;
using RiotApi.EndPoints;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVari
{
    class Program
    {
        private static readonly CottontailApi.IRiotApiClient api = new CottontailApi.RiotApiClient("452b549c-c123-40f4-ae57-b22d8912c3ec");
        static int summonerID = 23748066;
        static int dyrus = 26667724;
        static string ACCETeamID = "TEAM-640be967-811d-48ab-854c-e543be47b70a";
        //static string api_key = "452b549c-c123-40f4-ae57-b22d8912c3ec"; //na
        static string api_key = "da950e09-cdc2-44c4-9ae1-029573141c5d";// secondo account NA Ercanduslol
        //static string api_key = "bd429c81-60c8-4f74-8b32-81aa1c866992"; //eu
        static BaseRiotApiCaller caller;
        static void Main(string[] args)
        {
            caller = RateLimitedRiotApiCaller.GetInstance();

            List<Task> allTask = new List<Task>();
            for (int i = 0; i < 2000; i++)
            {
             //   allTask.Add(Test1Async());
            }
          //  Task.WhenAll(allTask).Wait();

            for (int i = 1; i < 12000; i++)
            {
                //Test1Async();
                  Test1(i);
                //    CurrentGameInfo currentGame = TestCurrentGame();
                //     Console.WriteLine(i);

                //   ChampionListDto r = TestGetChampions();

                //   ChampionDto r = TestGetChampion(103);

                //                RiotWeb.Dto.FeaturedGames.FeaturedGames featuredGames = TestGetFeaturedGames();

                //     var recentGames = TestGetRecentGames();
                //     var summonerLeagues = TestGetSummonerLeagues();

                //     var challengerLeague = TestGetChallengerLeagues();
                //     var masterLeague = TestGetMasterLeagues();
              //  var match = TestGetMatch();
                //     var matchList = TestGetMatchList();

                //     var rankedStats = GetRankedPlayerStats();
                //     var playerStats = GetPlayerStats();

                //      var teamBySummonerIds = GetTeamBySummonerIds();
                //      var teamByTeamIDs = GetTeamByTeamIds();

                //    var shards = GetShards();
                //   var shardsByRegion = GetShardByRegion();

                //                 var summonerByName = GetSummonerByName();
                //                 var summonerByIds = GetSummonerByIds();
                //                 var summonerMastery = GetSummonerMastery();
                //                 var summonerRune = GetSummonerRune();
                //                 var summonerNameByIds = GetSummonerName();
            }


            Console.ReadLine();
        }

        static void Test1(int i)
        {
            if (i%9==0)
            {
              //  Console.WriteLine("Start Serie:" + i + " time: " + DateTime.Now.ToString("h:mm:ss:fff"));
            }
            /*
            //api_key += "0";//attiviamo questa linea per generare una eccezzione nella GetResponse()

            BaseRiotApiCaller caller = RateLimitedRiotApiCaller.GetInstance();

            string result = "";
            result = caller.MakeApiCall("https://na.api.pvp.net/api/lol/na/v2.2/matchlist/by-summoner/" + summonerID + "?rankedQueues=RANKED_SOLO_5x5&seasons=SEASON2015&api_key=" + api_key, Enums.Region.NA);

            
            */
            api.GetAllChampion(CottontailApi.Commons.Enums.Platform.NA1);
         //  Console.WriteLine("end:"+i+ " time: "+ DateTime.Now.ToString("h:mm:ss:fff")); 
        }

        static async Task Test1Async()
        {
            //api_key += "0";attiviamo questa linea per generare una eccezzione nella GetResponse()

            BaseRiotApiCaller caller = RateLimitedRiotApiCaller.GetInstance();

            string result = await caller.MakeApiCallAsync("https://na.api.pvp.net/api/lol/na/v2.2/matchlist/by-summoner/" + summonerID + "?rankedQueues=RANKED_SOLO_5x5&seasons=SEASON2015&api_key=" + api_key, Enums.Region.NA);

            Console.WriteLine("Tast1Async");
        }

        static CurrentGameInfo TestCurrentGame()
        {
            ICurrentGame c = new CurrentGame(caller, api_key);

            CurrentGameInfo result = c.GetCurrentGame(Enums.Region.NA, dyrus);

            return result;
        }

        static ChampionListDto TestGetChampions()
        {
            IChampion c = new Champion(caller, api_key);

            ChampionListDto result = c.GetChampions(Enums.Region.NA);

            return result;
        }

        static ChampionDto TestGetChampion(int champID)
        {
            IChampion c = new Champion(caller, api_key);

            ChampionDto result = c.GetChampion(Enums.Region.NA, 103);

            return result;
        }

        static RiotApi.Dto.FeaturedGames.FeaturedGames TestGetFeaturedGames()
        {
            IFeaturedGames c = new FeaturedGames(caller, api_key);

            RiotApi.Dto.FeaturedGames.FeaturedGames result = c.GetFeaturedGames(Enums.Region.NA);

            return result;
        }

        static RecentGamesDto TestGetRecentGames()
        {
            IGame c = new Game(caller, api_key);

            RecentGamesDto result = c.GetRecentGames(Enums.Region.NA, summonerID);

            return result;
        }

   /*     static Dictionary<string, List<LeagueDto>> TestGetSummonerLeagues()
        {
            ILeague c = new League(caller, api_key);

            Dictionary<string, List<LeagueDto>> result = c.GetSummonerLeaguesByIds(Enums.Region.NA, new long[] { summonerID, dyrus });

            return result;
        }*/

        static LeagueDto TestGetChallengerLeagues()
        {
            ILeague c = new League(caller, api_key);

            LeagueDto result = c.GetChallengerLeague(Enums.Region.NA, Enums.LeagueQueueType.RANKED_SOLO_5x5);

            return result;
        }

        static LeagueDto TestGetMasterLeagues()
        {
            ILeague c = new League(caller, api_key);

            LeagueDto result = c.GetMasterLeague(Enums.Region.NA, Enums.LeagueQueueType.RANKED_SOLO_5x5);

            return result;
        }

        static MatchDetail TestGetMatch()
        {
            IMatch c = new Match(caller, api_key);

            MatchDetail result = c.GetMatchById(Enums.Region.NA, 1991598166, true);

            return result;
        }

   /*     static RiotApi.Dto.Matchlist.MatchListDto TestGetMatchList()
        {
            IMatchList c = new MatchList(caller, api_key);

            RiotApi.Dto.Matchlist.MatchListDto result = c.GetMatchList(Enums.Region.NA, summonerID);

            return result;
        }*/

        static RiotApi.Dto.Stats.RankedStatsDto GetRankedPlayerStats()
        {
            IStats c = new Stats(caller, api_key);

            RiotApi.Dto.Stats.RankedStatsDto result = c.GetRankedStatsBySummonerId(Enums.Region.NA, summonerID, Enums.SeasonNoPreSeasonType.SEASON2015);

            return result;
        }

        static RiotApi.Dto.Stats.PlayerStatsSummaryListDto GetPlayerStats()
        {
            IStats c = new Stats(caller, api_key);

            RiotApi.Dto.Stats.PlayerStatsSummaryListDto result = c.GetPlayerStatsBySummonerId(Enums.Region.NA, summonerID, Enums.SeasonNoPreSeasonType.SEASON2015);

            return result;
        }

        static Dictionary<string, List<RiotApi.Dto.Team.TeamDto>> GetTeamBySummonerIds()
        {
            ITeam c = new RiotApi.EndPoints.Team(caller, api_key);

            Dictionary<string, List<RiotApi.Dto.Team.TeamDto>> result = c.GetTeamBySummonerIds(Enums.Region.NA, new List<long>() { summonerID });

            return result;
        }

        static Dictionary<string, RiotApi.Dto.Team.TeamDto> GetTeamByTeamIds()
        {
            ITeam c = new RiotApi.EndPoints.Team(caller, api_key);

            Dictionary<string, RiotApi.Dto.Team.TeamDto> result = c.GetTeamByTeamIds(Enums.Region.NA, new List<string>() { ACCETeamID });

            return result;
        }

        static List<RiotApi.Dto.LolStatus.ShardDto> GetShards()
        {
            ILolStatus c = new RiotApi.EndPoints.LolStatus(caller, api_key);

            List<RiotApi.Dto.LolStatus.ShardDto> result = c.GetShards();

            return result;
        }
/*
        static RiotWeb.Dto.LolStatus.ShardStatusDto GetShardByRegion()
        {
            ILolStatus c = new RiotWeb.EndPoints.LolStatus(caller, api_key);

            RiotWeb.Dto.LolStatus.ShardStatusDto result = c.GetShardByRegion(Enums.Region.NA);

            return result;
        }

        static Dictionary<string, RiotWeb.Dto.Summoner.SummonerDto> GetSummonerByName()
        {
            ISummoner c = new RiotWeb.EndPoints.Summoner(caller, api_key);

            Dictionary<string, RiotWeb.Dto.Summoner.SummonerDto> result = c.GetSummonersByNames(Enums.Region.NA, new string[] { "ercand", "xalukardx" });

            return result;
        }

        static Dictionary<string, RiotWeb.Dto.Summoner.SummonerDto> GetSummonerByIds()
        {
            ISummoner c = new RiotWeb.EndPoints.Summoner(caller, api_key);

            Dictionary<string, RiotWeb.Dto.Summoner.SummonerDto> result = c.GetSummonersByIds(Enums.Region.NA, new long[] { summonerID });

            return result;
        }

        static Dictionary<string, RiotWeb.Dto.Summoner.MasteryPagesDto> GetSummonerMastery()
        {
            ISummoner c = new RiotWeb.EndPoints.Summoner(caller, api_key);

            Dictionary<string, RiotWeb.Dto.Summoner.MasteryPagesDto> result = c.GetSummonerMasteryBySummonerIds(Enums.Region.NA, new long[] { summonerID });

            return result;
        }

        static Dictionary<string, RiotWeb.Dto.Summoner.RunePagesDto> GetSummonerRune()
        {
            ISummoner c = new RiotWeb.EndPoints.Summoner(caller, api_key);

            Dictionary<string, RiotWeb.Dto.Summoner.RunePagesDto> result = c.GetSummonerRunesBySummonerIds(Enums.Region.NA, new long[] { summonerID });

            return result;
        }

        static Dictionary<string, string> GetSummonerName()
        {
            ISummoner c = new RiotWeb.EndPoints.Summoner(caller, api_key);

            Dictionary<string, string> result = c.GetSummonerNamesBySummonerId(Enums.Region.NA, new long[] { summonerID });

            return result;
        }*/
    }
}
