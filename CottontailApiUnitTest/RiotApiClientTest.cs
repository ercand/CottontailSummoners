using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using CottontailApi;
using CottontailApi.Commons;
using CottontailApi.Dto.Champion;
using CottontailApi.Dto.ChampionMastery;
using CottontailApi.Dto.League;
using CottontailApi.Dto.Match;
using CottontailApi.Dto.Spectator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CottontailApiUnitTest
{
    [TestClass]
    public class RiotApiClientTest
    {
        private static readonly IRiotApiClient api = new RiotApiClient(CommonTestData.apiKey);

        #region Summoner-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerByAccountId()
        {
            var summoner = api.GetSummonerByAccountId(CommonTestData.AccountId, CommonTestData.Platform);

            Assert.AreEqual(summoner.Name, CommonTestData.SummonerName);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerByName()
        {
            var summoner = api.GetSummonerByName("Ercand", Enums.Platform.NA1);

            Assert.AreEqual(summoner.Name, "Ercand");
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetSummonerById()
        {
            var summoner = api.GetSummonerById(CommonTestData.SummonerId, CommonTestData.Platform);

            Assert.AreEqual(summoner.Id, CommonTestData.SummonerId);
        }
        #endregion

        #region Runes-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRuneBySummonerId()
        {
            var runePages = api.GetRunePagesBySummonerId(CommonTestData.SummonerId, CommonTestData.Platform);

            Assert.AreEqual(runePages.SummonerId, CommonTestData.SummonerId);
        }
        #endregion

        #region Masteries-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMasteryBySummonerId()
        {
            var masteryPages = api.GetMasteryPagesBySummonerId(CommonTestData.SummonerId, CommonTestData.Platform);

            Assert.AreEqual(masteryPages.SummonerId, CommonTestData.SummonerId);
        }
        #endregion

        #region Champion-Mastery-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMasteriesBySummonerId()
        {
            var championMastery = api.GetChampionMasteriesBySummonerId(CommonTestData.SummonerId, CommonTestData.Platform);
            Assert.IsTrue(championMastery.Count > 0);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMasteriesByChampionId()
        {
            var championMastery = api.GetChampionMasteriesByChampionId(CommonTestData.SummonerId, 1, CommonTestData.Platform);
            Assert.IsTrue(championMastery.ChampionPoints >= 171);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionMasteriesScore()
        {
            var championMastery = api.GetChampionMasteriesScore(CommonTestData.SummonerId, CommonTestData.Platform);
            Assert.IsTrue(championMastery >= 236);
        }

        #endregion

        #region Champion-V3
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetAllChampion()
        {
            var champion = api.GetAllChampion(CommonTestData.Platform);

            Assert.IsNotNull(champion);
            Assert.IsNotNull(champion.Champions);
            Assert.IsTrue(champion.Champions.Count > 0);
        }
        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetChampionById()
        {
            var champion = api.GetChampionById(CommonTestData.ChampionId, CommonTestData.Platform);

            Assert.IsNotNull(champion);
            Assert.IsTrue(champion.Id == CommonTestData.ChampionId);
        }

        #endregion

        #region League-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagueChallenger()
        {
            var league = api.GetLeagueChallenger(Enums.LeagueQueueType.RANKED_SOLO_5x5, CommonTestData.Platform);
            Assert.IsNotNull(league);
            Assert.IsTrue(league.Queue == Enums.LeagueQueueType.RANKED_SOLO_5x5);
            Assert.IsTrue(league.Tier == Enums.TierType.CHALLENGER);

            league = api.GetLeagueChallenger(Enums.LeagueQueueType.RANKED_FLEX_SR, CommonTestData.Platform);

            Assert.IsNotNull(league);
            Assert.IsTrue(league.Queue == Enums.LeagueQueueType.RANKED_FLEX_SR);
            Assert.IsTrue(league.Tier == Enums.TierType.CHALLENGER);

            league = api.GetLeagueChallenger(Enums.LeagueQueueType.RANKED_FLEX_TT, CommonTestData.Platform);

            Assert.IsNotNull(league);
            Assert.IsTrue(league.Queue == Enums.LeagueQueueType.RANKED_FLEX_TT);
            Assert.IsTrue(league.Tier == Enums.TierType.CHALLENGER);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeagueMaster()
        {
            var league = api.GetLeagueMaster(Enums.LeagueQueueType.RANKED_SOLO_5x5, CommonTestData.Platform);

            Assert.IsNotNull(league);
            Assert.IsTrue(league.Queue == Enums.LeagueQueueType.RANKED_SOLO_5x5);
            Assert.IsTrue(league.Tier == Enums.TierType.MASTER);

            league = api.GetLeagueMaster(Enums.LeagueQueueType.RANKED_FLEX_SR, CommonTestData.Platform);

            Assert.IsNotNull(league);
            Assert.IsTrue(league.Queue == Enums.LeagueQueueType.RANKED_FLEX_SR);
            Assert.IsTrue(league.Tier == Enums.TierType.MASTER);

            league = api.GetLeagueMaster(Enums.LeagueQueueType.RANKED_FLEX_TT, CommonTestData.Platform);

            Assert.IsNotNull(league);
            Assert.IsTrue(league.Queue == Enums.LeagueQueueType.RANKED_FLEX_TT);
            Assert.IsTrue(league.Tier == Enums.TierType.MASTER);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeaguesBySummonerId()
        {
            var league = api.GetLeaguePositionBySummonerId(CommonTestData.SummonerId, CommonTestData.Platform);
            Assert.IsNotNull(league);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetLeaguePositionBySummonerId()
        {
            var league = api.GetLeaguePositionBySummonerId(CommonTestData.SummonerId, CommonTestData.Platform);
            Assert.IsNotNull(league);
        }

        #endregion

        #region Match-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchById()
        {
            var match = api.GetMatchById(CommonTestData.GameId, CommonTestData.Platform);

            Assert.IsNotNull(match);
            Assert.IsTrue(match.GameId == CommonTestData.GameId);
        }

        //[TestMethod]
        //[TestCategory("RiotApi")]
        public void GetRankedMatchListByAccountId()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetRecentMatchListByAccountId()
        {
            var match = api.GetRecentMatchListByAccountId(CommonTestData.AccountId, CommonTestData.Platform);

            Assert.IsNotNull(match);
            Assert.IsTrue(match.TotalGames == 20);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetMatchTimelineByMatchId()
        {
            var match = api.GetMatchTimelineByMatchId(CommonTestData.GameId, CommonTestData.Platform);

            Assert.IsNotNull(match);
            Assert.IsNotNull(match.Frames);
        }

        #endregion

        #region Spectator-V3

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetCurrentGameBySummonerId()
        {
            var featuredGames = api.GetFeaturedGames(CommonTestData.Platform);
            var summoner=api.GetSummonerByName(featuredGames.GameList[0].Participants[0].SummonerName, CommonTestData.Platform);
            var currentGame = api.GetCurrentGameBySummonerId(summoner.Id, CommonTestData.Platform);

            Assert.IsNotNull(currentGame);
        }

        [TestMethod]
        [TestCategory("RiotApi")]
        public void GetFeaturedGames()
        {
            var featuredGames = api.GetFeaturedGames(CommonTestData.Platform);

            Assert.IsNotNull(featuredGames);
        }
        #endregion
    }
}
