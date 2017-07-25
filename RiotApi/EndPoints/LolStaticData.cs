using Newtonsoft.Json;
using RiotApi.Commons;
using RiotApi.Dto.LolStaticData;
using RiotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.EndPoints
{
    public class LolStaticData : ILolStaticData
    {
        private string ApiKey { get; set; }
        private StaticRiotApiCaller Caller { get; set; }


        public LolStaticData(string apiKey)
        {
            this.ApiKey = apiKey;
            Caller = new StaticRiotApiCaller();
        }

        public Dto.LolStaticData.ChampionListDto GetChampions()
        {
            // TODO: cambiare la url per implementare il parametro "champData"
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion?champData=all" + "&api_key="+ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                var result = JsonConvert.DeserializeObject<ChampionListDto>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public RealmDto Realm()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/realm?api_key=" + ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                RealmDto result = JsonConvert.DeserializeObject<RealmDto>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ItemListDto GetItems()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/item?itemListData=all&api_key=" + ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                ItemListDto result = JsonConvert.DeserializeObject<ItemListDto>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ItemDto GetItem(int id) { throw new NotImplementedException(); }
        public MasteryListDto GetMasteries()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/mastery?masteryListData=all&api_key=" + ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                MasteryListDto result = JsonConvert.DeserializeObject<MasteryListDto>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public MasteryDto GetMastery(int id) { throw new NotImplementedException(); }
        public RuneListDto GetRunes()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/rune?runeListData=all&api_key=" + ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                RuneListDto result = JsonConvert.DeserializeObject<RuneListDto>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public RuneDto GetRune(int id) { throw new NotImplementedException(); }
        public SummonerSpellListDto GetSummonerSpells()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/summoner-spell?spellData=all&api_key=" + ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                SummonerSpellListDto result = JsonConvert.DeserializeObject<SummonerSpellListDto>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public SummonerSpellDto GetSummonerSpell(int id){ throw new NotImplementedException();}
        public List<string> GetVersions()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/versions?api_key=" + ApiKey;

            try
            {
                var json = Caller.MakeApiCall(url, Enums.Region.GLOBAL);
                List<string> result = JsonConvert.DeserializeObject<List<string>>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<string>> GetVersionsAsync()
        {
            string url = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/versions?api_key=" + ApiKey;
            var json = await Caller.MakeApiCallAsync(url, Enums.Region.GLOBAL);
            List<string> result = JsonConvert.DeserializeObject<List<string>>(json);

            return result;
        }

        
    }
}
