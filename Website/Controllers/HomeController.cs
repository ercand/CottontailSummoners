using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CottontailApi.Commons;
using Website.DataAccessLayer.Repositories;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;
using Website.Helpers;
using Website.Models.ViewModels;
using Website.Services.Interfaces;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        CottontailApi.IRiotApiClient _riotClient;
        ISummonerService _summonerService;
        IPlayerLeagueService _playerLeagueService;
        IPlayerChampionRankedStatsService _playerChampionRankedStatsService;

        private HomeController()
        { }

        public HomeController(CottontailApi.IRiotApiClient riotClient, ISummonerService summonerService, IPlayerLeagueService playerLeagueRepository, IPlayerChampionRankedStatsService playerChampionRankedStatsService)
        {
            this._riotClient = riotClient;
            this._summonerService = summonerService;
            this._playerLeagueService = playerLeagueRepository;
            this._playerChampionRankedStatsService = playerChampionRankedStatsService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            foreach (var item in formCollection.AllKeys)
            {
                System.Diagnostics.Debug.WriteLine(formCollection[(string)item]);
            }

            return RedirectToAction("Index", "Summoner", new { region = formCollection["region"], name = formCollection["summonername"] }); ;
        }

        [HttpPost]
        public ActionResult FeatureGame()
        {
            CottontailApi.Commons.Enums.Platform platform = CottontailApi.Commons.Enums.Platform.NA1;
            CottontailApi.Dto.Spectator.FeaturedGames featureGame = null;

            try
            {
                featureGame = _riotClient.GetFeaturedGames(platform);
            }
            catch (Exception)
            {
                throw;
            }
            if (featureGame == null)
            { }

            List<string> listSummonersName = (from a in featureGame.GameList from b in a.Participants select b.SummonerName).ToList<string>();
            List<Summoner> featureGameSummoners = _summonerService.Find(listSummonersName, platform).ToList();

            List<long> listSummonerId = (from a in featureGameSummoners select a.RiotSummonerID).ToList();
            List<PlayerLeague> featureGamePlayerLeague = _playerLeagueService.Find(listSummonerId, platform).ToList();

            List<PlayerChampionRankedStats> summonersStats = new List<PlayerChampionRankedStats>();
            foreach (var sum in featureGameSummoners)
            {
                var r = _playerChampionRankedStatsService.FindChampionsStats(sum, platform, GlobalCustomConstants.CurrentSeasonNoPreseason);
                if (r != null) { summonersStats.AddRange(r); }
            }

            HomeFeatureGameViewModel model = new HomeFeatureGameViewModel(featureGame, featureGameSummoners, featureGamePlayerLeague, summonersStats);
            
            return PartialView("FeatureGame", model);
        }

        public ActionResult DownloadSpectator(string region, string encryptionKey, string matchID)
        {
            var reg = GenericConverter.StringToRegion(Request.QueryString["region"]);
            string EncryptionKey = Request.QueryString["encryptionKey"];
            string MatchID = Request.QueryString["matchID"];

            RiotSpectatorEndPoint.SpectatorEndPoint spectateEP = RiotSpectatorEndPoint.GetSpectatorEndPointByRegion(reg);
            string Port = spectateEP.Port;
            
            string PlatformID = spectateEP.PlatformID;
            string EndPoint = spectateEP.Host;

            var stream = new MemoryStream();
            string spectateString = "cd \"c:\\Riot Games\\League of Legends\\RADS\\solutions\\lol_game_client_sln\\releases\\\" & for /d %F in (*) do cd %F & start \"\" /D \"deploy\" \"League of Legends.exe\" \"8394\" \"LoLLauncher.exe\" \"\" \"spectator " + EndPoint + ":" + Port + " " + EncryptionKey + " " + MatchID + " " + PlatformID + "\"";
            var data = Encoding.UTF8.GetBytes(spectateString);
            stream.Write(data, 0, data.Length);
            return File(stream.GetBuffer(), "application/txt", "texto.bat");

            // Generate a browser prompt to open/save the PDF.
            Response.Clear();
            Response.ContentType = "application/bat";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "texto.bat"));
            Response.OutputStream.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
            Response.End();
            return File(stream.GetBuffer(), "application/txt", "texto.txt");

            /*
             * 
             * cd "c:\Riot Games\League of Legends\RADS\solutions\lol_game_client_sln\releases\" & for /d %F in (*) do cd %F & start "" /D "deploy" "League of Legends.exe" "8394" "LoLLauncher.exe" "" "spectator spectator.na.lol.riotgames.com:80 D12AmjkPnuoqQmBJ+BfQkR/v4SO7I8L8 2396086010 NA1"
             * */
        }
    }
}
