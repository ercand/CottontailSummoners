using System;
using CottontailApi;
using CottontailApi.Commons;
using CottontailApi.Dto.StaticData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CottontailApiUnitTest
{
    [TestClass]
    public class StaticRiotApiClientTest
    {
        private static readonly IStaticRiotApiClient api = new StaticRiotApiClient(CommonTestData.apiKey);

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetShardStatus()
        {
            var shardData = api.GetShardStatus(Enums.Platform.NA1);

            Assert.AreEqual(shardData.Name, "North America");
            Assert.AreEqual(shardData.Region_tag, "na1");
        }

        #region StaticData-V3

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions()
        {
            var data = api.GetChampions(Enums.Platform.NA1, StaticDataEnums.ChampionData.All);

            Assert.IsNotNull(data);
        }

        public void GetChampionById(int championId, Enums.Platform platform) { throw new NotImplementedException(); }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems()
        {
            var data = api.GetItems(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }

        public void GetItemById(int id, Enums.Platform platform) { throw new NotImplementedException(); }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetLanguageString()
        {
            var data = api.GetLanguageString(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetLanguages()
        {
            var data = api.GetLanguages(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMaps()
        {
            var data = api.GetMaps(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMasteries()
        {
            var data = api.GetMasteries(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }
        public void GetMasteryById(int id, Enums.Platform platform) { throw new NotImplementedException(); }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetProfileIcons()
        {
            var data = api.GetProfileIcons(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void Realms()
        {
            var data = api.Realms(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRunes()
        {
            var data = api.GetRunes(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }
        public void GetRuneById(int runeId, Enums.Platform platform) { throw new NotImplementedException(); }


        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpells()
        {
            var data = api.GetSummonerSpells(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }
        public void GetSummonerSpellById(int spellId, Enums.Platform platform) { throw new NotImplementedException(); }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetVersions()
        {
            var data = api.GetVersions(Enums.Platform.NA1);

            Assert.IsNotNull(data);
        }
        /*
                public async Task<List<string>> GetVersionsAsync(Enums.Platform platform)
                {
                    string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/versions?api_key=" + ApiKey;
                    var json = await Caller.MakeApiCallAsync(url, Enums.Region.GLOBAL);
                    List<string> result = JsonConvert.DeserializeObject<List<string>>(json);

                    return result;
                }*/

        #endregion
    }
}
