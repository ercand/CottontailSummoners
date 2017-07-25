using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CottontailApi.Commons;
using Website.Helpers;
using Website.Models.ViewModels;
using Website.Services.Interfaces;

namespace Website.Controllers
{
    public class SummonerController : Controller
    {
        CottontailApi.IRiotApiClient _riotClient;
        ISummonerService _summonerService;
        IRunePageService _runePageService;
        IMasteryPageService _masteryPageService;
        IPlayerLeagueService _playerLeagueService;
        IPlayerChampionRankedStatsService _playerRankedStats;
        IRankedMatchToProcessService _rankedToProcessService; 
        IMatchService _matchService;

        private SummonerController()
        { }

        public SummonerController(CottontailApi.IRiotApiClient riotClient, ISummonerService summonerService, IRunePageService runePageService, IMasteryPageService masteryPageService, IPlayerLeagueService playerLeagueService, IPlayerChampionRankedStatsService playerRankedStats, IMatchService matchService, IRankedMatchToProcessService rankedToProcessService)
        {
            this._riotClient = riotClient;
            this._summonerService = summonerService;
            this._runePageService = runePageService;
            this._masteryPageService = masteryPageService;
            this._playerLeagueService = playerLeagueService;
            this._playerRankedStats = playerRankedStats;
            this._matchService = matchService;
            this._rankedToProcessService = rankedToProcessService;
        }
        
        // GET: Summoner
        public ActionResult Index(string region, string name)
        {
            if (region == string.Empty || name == string.Empty)
            {
                //throw new Exception("Region o SummonerName null");
            }
            var tempPlatform = Utility.Platform.ToPlatform(Utility.Region.StringToRegion(region));//CottontailApi.Commons.GenericConverter.StringToRegion(region);
            Entities.Summoner tempSummoner = null;

            try
            {
                tempSummoner = _summonerService.Find(name, tempPlatform).SingleOrDefault();
            }
            catch (System.Exception ex)
            {
                int t = 0;
            }

            // Search last game in database
            var matchFromDb = _matchService.FindBySummonerRiotId(tempSummoner.RiotSummonerID, tempPlatform);
            if (matchFromDb.Count() > 0)
            {
                matchFromDb = matchFromDb.OrderByDescending(d => d.MatchCreation).Take(20).ToList();
            }
            else
            {
                UpdateRecentMatch(tempSummoner.AccountId, Utility.Region.RegionToInt(Utility.Region.StringToRegion(region)));
                matchFromDb = _matchService.FindBySummonerRiotId(tempSummoner.RiotSummonerID, tempPlatform).OrderByDescending(d=>d.MatchCreation).Take(20).ToList();
            }

            var allRiotSummonerId = matchFromDb.SelectMany(r => r.DataParticipant).Select(r => r.RiotSummonerID).Distinct().ToList();
            var summonerFromDb = _summonerService.Find(allRiotSummonerId, tempPlatform).ToList();

            SummonerViewModel model = new SummonerViewModel(matchFromDb.ToList(), summonerFromDb, tempSummoner);

            // Summoner rank info
            var tempRankInfo = this._playerLeagueService.Find(tempSummoner.RiotSummonerID, tempPlatform).SingleOrDefault();
            model.AddRankedInfo(tempRankInfo);

            // Ranked champion stats for recent champion played
            var tempChampStats = _playerRankedStats.FindChampionsStats(tempSummoner, tempPlatform, GlobalCustomConstants.CurrentSeasonNoPreseason).ToList();
            model.AddMostPlayedChampions(tempChampStats);

            return View(model);
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

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult RunePage(int id, int region)
        {
            var runes = _runePageService.Find(id, Utility.Platform.RegionIntToPlatform(region)).ToList();
            SummonerRunePageViewModel model = new SummonerRunePageViewModel(runes);
            return PartialView("RunePage", model);
        }

        [HttpPost]
        public ActionResult MasteryPage(int id, int region)
        {
            var masteries = _masteryPageService.Find(id, Utility.Platform.RegionIntToPlatform(region)).ToList();
            SummonerMasteryPageViewModel model = new SummonerMasteryPageViewModel(masteries);
            return PartialView("MasteryPage", model);
        }

        [HttpPost]
        public ActionResult Match(int id, int region)
        {
            var regionTemp = Utility.Platform.RegionIntToPlatform(region);
            Entities.Summoner tempSummoner = _summonerService.Find(id, regionTemp).SingleOrDefault();
            var matchFromDb = _matchService.FindBySummonerRiotId(tempSummoner.RiotSummonerID, regionTemp).OrderByDescending(d => d.MatchCreation).Take(10).ToList(); //GetRecentMatch(id, regionTemp);
            var allRiotSummonerId = matchFromDb.SelectMany(r => r.DataParticipant).Select(r => r.RiotSummonerID).Distinct().ToList();

            var summonerFromDb = _summonerService.Find(allRiotSummonerId, regionTemp).ToList();

            SummonerRecentMatchViewModel model = new SummonerRecentMatchViewModel(matchFromDb.ToList(), summonerFromDb, id);

            // Ranked champion stats for recent champion played
            var tempChampStats = _playerRankedStats.FindChampionsStats(tempSummoner, regionTemp, GlobalCustomConstants.CurrentSeasonNoPreseason).ToList();
            model.AddMostPlayedChampions(tempChampStats);

            return PartialView("Match", model);
        }

        //
        [HttpPost]
        public ActionResult ChampionStats(int id, int region)
        {

            var regionTemp = Utility.Platform.RegionIntToPlatform(region);
            Entities.Summoner tempSummoner = null;

            try
            {
                tempSummoner = _summonerService.Find(id, regionTemp).SingleOrDefault();
            }
            catch (System.Exception ex)
            {

            }
            var playerStats = _playerRankedStats.FindAllSeasonChampionStats(tempSummoner, Utility.Platform.RegionIntToPlatform(region)).ToList();
            var tempRankInfo = this._playerLeagueService.Find(tempSummoner.RiotSummonerID, Utility.Platform.RegionIntToPlatform(region)).SingleOrDefault();

            SummonerChampionStatsViewModel model = new SummonerChampionStatsViewModel(playerStats, tempRankInfo);
            return PartialView("ChampionStats", model);
        }

        [HttpPost]
        public ActionResult League(int id, int region)
        {
            var regionTemp = Utility.Platform.RegionIntToPlatform(region);
            var tempLeague = _riotClient.GetLeaguesBySummonerId(id, regionTemp);

            // Estraggo tutti gli ID per trovare le summoner icon
            var tempQueue = tempLeague.Where(s => s.Queue ==  CottontailApi.Commons.Enums.LeagueQueueType.RANKED_SOLO_5x5).SingleOrDefault();
            var allSummoner = tempQueue.Entries.Select(s => { var t = s.PlayerOrTeamId; return long.Parse(t); }).ToList();

            List<Entities.Summoner> tempSummoner = null;

            try
            {
                tempSummoner = _summonerService.Find(allSummoner, regionTemp, true).ToList();
            }
            catch (System.Exception ex)
            {

            }
            SummonerLeagueViewModel model = new SummonerLeagueViewModel(tempQueue, tempSummoner, id);
            return PartialView("League", model);
        }

        //
        [HttpPost]
        public ActionResult SummonerGameFilters(int id, int region, string queueType)
        {
            TempData["gg"] = ((int)TempData["gg"]) +1;

            var regionTemp = Utility.Platform.RegionIntToPlatform(region);
            List<Entities.MatchData> matchFromDb = null;

            if (queueType.ToLower() == "all")
            {
                matchFromDb = _matchService.FindBySummonerRiotId(id, regionTemp).ToList();
            }
            else if (queueType.ToLower() == "ranked_solo_5x5")
            {
                matchFromDb = _matchService.FindBySummonerRiotId(id, regionTemp).Where(m => m.QueueId == (int)CottontailApi.Commons.Enums.GameQueueType.TEAM_BUILDER_RANKED_SOLO).ToList();
            }
            else if (queueType.ToLower() == "flex_sr")
            {
                matchFromDb = _matchService.FindBySummonerRiotId(id, regionTemp).Where(m => m.QueueId == (int)CottontailApi.Commons.Enums.GameQueueType.RANKED_FLEX_SR).ToList();
            }
            else if (queueType.ToLower() == "flex_tt")
            {
                matchFromDb = _matchService.FindBySummonerRiotId(id, regionTemp).Where(m => m.QueueId == (int)CottontailApi.Commons.Enums.GameQueueType.RANKED_FLEX_TT).ToList();
            }
            else if (queueType.ToLower() == "aram")
            {
                matchFromDb = _matchService.FindBySummonerRiotId(id, regionTemp).Where(m => m.QueueId == (int)CottontailApi.Commons.Enums.GameQueueType.ARAM_5x5).ToList();
            }
            else if (queueType.ToLower() == "normal")
            {
                matchFromDb = _matchService.FindBySummonerRiotId(id, regionTemp).Where(m => m.QueueId == (int)CottontailApi.Commons.Enums.GameQueueType.NORMAL_5x5_BLIND).ToList();
            }

            // TODO: implementare il caso in cui non siano stati trovati dei match
            if (matchFromDb==null)
            {
                Trace.TraceWarning("No match found for queue:" + queueType);

            }
            var allRiotSummonerID = matchFromDb.SelectMany(r => r.DataParticipant).Select(r => r.RiotSummonerID).Distinct().ToList();
            var summonerFromDB = _summonerService.Find(allRiotSummonerID, regionTemp, true).ToList();

            SummonerRecentMatchViewModel model = new SummonerRecentMatchViewModel(matchFromDb.ToList(), summonerFromDB, id);
            return PartialView("Match", model);
            return PartialView("RecentMatch", model);
        }

        //
        [HttpPost]
        public ActionResult SummonerLiveGame(int id, int region)
        {
            CottontailApi.Commons.Enums.Platform tempPlatform = Utility.Platform.RegionIntToPlatform(region);
            CottontailApi.Dto.Spectator.CurrentGameInfo currentGame = null;

            try
            {
                currentGame = _riotClient.GetCurrentGameBySummonerId(id, tempPlatform);
            }
            catch (Exception)
            {
                throw;
            }
            if (currentGame == null)
            { }
            var allRiotSummonerID = currentGame.Participants.Select(r => r.SummonerId).Distinct().ToList();

            var summonerFromDB = _summonerService.Find(allRiotSummonerID, tempPlatform, true).ToList();
            var leagueSummoner = _playerLeagueService.Find(allRiotSummonerID, tempPlatform).ToList();
            var rankedChampionStats = _playerRankedStats.FindAllPlayerChampionStats(summonerFromDB, tempPlatform, GlobalCustomConstants.CurrentSeasonNoPreseason).ToList();
            var rankedLastSeasonChampionStats = _playerRankedStats.FindAllPlayerChampionStats(summonerFromDB, tempPlatform, GlobalCustomConstants.PreviousSeasonNoPreseason).ToList();

            SummonerLiveGameViewModel model = new SummonerLiveGameViewModel(currentGame, summonerFromDB, leagueSummoner, rankedChampionStats);
            return PartialView("SummonerLiveGame", model);
        }

        //
        [HttpPost]
        public ActionResult UpdateRecentMatch(long accountId, int region)
        {
            // TODO: aggiungere un controllo che eviti l'update se non è passato abbastanza tempo
            CottontailApi.Dto.Match.MatchlistDto recentGame = null;
            CottontailApi.Commons.Enums.Platform tempPlatform = Utility.Platform.RegionIntToPlatform(region);
            try
            {
                recentGame = _riotClient.GetRecentMatchListByAccountId(accountId, tempPlatform);
            }
            catch (Exception)
            {
                throw;
            }
            if (recentGame == null)
            { }

            var matchFromDb = _matchService.Find(recentGame, tempPlatform);
            return null;
        }

        //[HttpPost]
        //public ActionResult UpdateChampionStats(long id, int region)
        public void UpdateChampionStats(long id, int region)
        {
            CottontailApi.Commons.Enums.Platform tempPlatform = Utility.Platform.RegionIntToPlatform(region);
            
            _rankedToProcessService.Add(id, tempPlatform);
        }
        public ActionResult Test(int time)
        {
            System.Threading.Thread.Sleep(time);
            return View("3000");
        }
    }
}