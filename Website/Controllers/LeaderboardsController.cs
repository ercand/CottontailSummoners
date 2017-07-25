using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models.ViewModels;
using Website.Services.Interfaces;

namespace Website.Controllers
{
    public class LeaderboardsController : Controller
    {
        CottontailApi.IRiotApiClient _riotClient;
        ISummonerService _summonerService;

        private LeaderboardsController()
        { }
        public LeaderboardsController(CottontailApi.IRiotApiClient riotClient, ISummonerService summonerService)
        {
            this._riotClient = riotClient;
            this._summonerService = summonerService;
        }
        // GET: Leaderboards
        public ActionResult Index()
        {
            var league = this._riotClient.GetLeagueChallenger(CottontailApi.Commons.Enums.LeagueQueueType.RANKED_SOLO_5x5, CottontailApi.Commons.Enums.Platform.NA1);
            var allSummoner = league.Entries.Select(s => long.Parse(s.PlayerOrTeamId)).ToList();
            var summonerFromDB = this._summonerService.Find(allSummoner, CottontailApi.Commons.Enums.Platform.NA1).ToList();

            LeaderboardsViewModel model = new LeaderboardsViewModel(league, summonerFromDB);
            return View(model);
        }

        [HttpPost]
        public ActionResult GetLeaderboard(string region)
        {
            var platform = CottontailApi.Commons.GenericConverter.RegionToPlatfomrId(CottontailApi.Commons.GenericConverter.StringToRegion(region));
            var league = this._riotClient.GetLeagueChallenger(CottontailApi.Commons.Enums.LeagueQueueType.RANKED_SOLO_5x5, platform);
            var allSummoner = league.Entries.Select(s => long.Parse(s.PlayerOrTeamId)).ToList();
            var summonerFromDB = this._summonerService.Find(allSummoner, platform).ToList();

            LeaderboardsViewModel model = new LeaderboardsViewModel(league, summonerFromDB);
            return PartialView("GetLeaderboard", model);
        }
    }
}