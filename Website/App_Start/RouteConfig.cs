using System.Web.Mvc;
using System.Web.Routing;

namespace Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Leaderboards
            
            routes.MapRoute(
                name: "LeaderboardsDefault",
                url: "Leaderboards/{region}",
                defaults: new { controller = "Leaderboards", action = "Index", region = "" }
            );

            routes.MapRoute(
                name: "GetLeaderboardDefault",
                url: "GetLeaderboard",
                defaults: new { controller = "Leaderboards", action = "GetLeaderboard" }
            );

            #endregion


            #region Home page

            routes.MapRoute(
                name: "FeatureGameDefault",
                url: "FeatureGame",
                defaults: new { controller = "Home", action = "FeatureGame" }
            );

            routes.MapRoute(
                name: "DownloadSpectatorDefault",
                url: "DownloadSpectator/{region}/{encryptionKey}/{matchID}",
                defaults: new { controller = "Home", action = "DownloadSpectator", region = "", encryptionKey = "", matchID = "" }
            );

            #endregion


            #region Summoner Controller routers

            routes.MapRoute(
                name: "SummonerSummonerTestDefault",
                url: "Summoner/Test/{time}",
                defaults: new { controller = "Summoner", action = "Test", time = "" }
            );

            routes.MapRoute(
                name: "SummonerSummonerLiveGameDefault",
                url: "Summoner/SummonerLiveGame/{id}/{region}",
                defaults: new { controller = "Summoner", action = "SummonerLiveGame", id = "", region = "" }
            );

            routes.MapRoute(
                name: "SummonerGameUpdateRecentMatchDefault",
                url: "Summoner/UpdateRecentMatch/{accountId}/{region}",
                defaults: new { controller = "Summoner", action = "UpdateRecentMatch", accountId = "", region = "" }
            );

            routes.MapRoute(
                name: "SummonerGameFiltersDefault",
                url: "Summoner/SummonerGameFilters/{id}/{region}/{queueType}",
                defaults: new { controller = "Summoner", action = "SummonerGameFilters", id = "", region = "", queueType = "" }
            );
            
            routes.MapRoute(
                name: "LeagueDefault",
                url: "Summoner/League/{id}/{region}",
                defaults: new { controller = "Summoner", action = "League", id = "", region = "" }
            );

            routes.MapRoute(
                name: "ChampionStatsDefault",
                url: "Summoner/ChampionStats/{id}/{region}",
                defaults: new { controller = "Summoner", action = "ChampionStats", id = "", region = "" }
            );

            routes.MapRoute(
                name: "RecentMatchDefault",
                url: "Summoner/RecentMatch/{id}/{region}",
                defaults: new { controller = "Summoner", action = "RecentMatch", id = "", region = "" }
            );

            routes.MapRoute(
                name: "MatchDefault",
                url: "Summoner/Match/{id}/{region}",
                defaults: new { controller = "Summoner", action = "Match", id = "", region = "" }
            );

            routes.MapRoute(
                name: "RunePageDefault",
                url: "Summoner/RunePage/{id}/{region}",
                defaults: new { controller = "Summoner", action = "RunePage", id = "", region = "" }
            );

            routes.MapRoute(
                name: "MasteryPageDefault",
                url: "Summoner/MasteryPage/{id}/{region}",
                defaults: new { controller = "Summoner", action = "MasteryPage", id = "", region = "" }
            );

            routes.MapRoute(
                name: "SummonerDefault",
                url: "Summoner/{region}/{name}",
                defaults: new { controller = "Summoner", action = "Index", region = "", name = "" }
            );

            #endregion

            #region Error Page

            routes.MapRoute(
                name: "ErrorDefault",
                url: "Error/",
                defaults: new { controller = "Error", action = "Index" }
            );

            routes.MapRoute(
                name: "Errore404Default",
                url: "Error/e404",
                defaults: new { controller = "Error", action = "e404" }
            );

            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
