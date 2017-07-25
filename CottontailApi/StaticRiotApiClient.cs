using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;
using CottontailApi.Dto.League;
using CottontailApi.Dto.LolStatus;
using CottontailApi.Dto.StaticData;
using CottontailApi.Http;
using Newtonsoft.Json;

namespace CottontailApi
{
    public class StaticRiotApiClient : IStaticRiotApiClient
    {
        private readonly RiotApiRequester requester = new RiotApiRequester();
        private string ApiKeyUrl;
        private string apiKey;
        private JsonSerializerSettings settings;
        private const string StaticDataBaseUrl = "/lol/static-data/v3";

        public StaticRiotApiClient(string apiKey)
        {
            settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            this.ApiKeyUrl = "api_key=" + apiKey;
            this.apiKey = apiKey;
        }
        #region Lol-Status-V3

        public ShardStatus GetShardStatus(Enums.Platform platform)
        {
            var shardData = requester.GetRequestApiCall("/lol/status/v3/shard-data?" + ApiKeyUrl, platform);
            var result = JsonConvert.DeserializeObject<ShardStatus>(shardData);

            return result;
        }

        #endregion

        #region StaticData-V3

        public ChampionListDto GetChampions(Enums.Platform platform, StaticDataEnums.ChampionData tags = StaticDataEnums.ChampionData.basic, bool? dataById = null, string version = null, string locale = null)
        {
            string parameters = "";

            if (tags != StaticDataEnums.ChampionData.basic)
            {
                parameters += "tags=" + tags.ToString().ToLower() + "&";
            }
            if (dataById.HasValue)
            {
                parameters += "dataById=" + dataById.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            string data = requester.GetRequestApiCall(StaticDataBaseUrl + "/champions?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<ChampionListDto>(data);

            return result;
        }

        public ChampionListDto GetChampionById(int championId, Enums.Platform platform) { throw new NotImplementedException(); }

        public ItemListDto GetItems(Enums.Platform platform, StaticDataEnums.ItemData tags = StaticDataEnums.ItemData.Basic, string version = null, string locale = null)
        {
            string parameters = "";

            if (tags != StaticDataEnums.ItemData.Basic)
            {
                parameters += "tags=" + tags.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/items?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<ItemListDto>(data);

            return result;
        }

        public ItemDto GetItemById(int id, Enums.Platform platform) { throw new NotImplementedException(); }

        public LanguageStringsDto GetLanguageString(Enums.Platform platform, string version = null, string locale = null)
        {
            string parameters = "";

            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/language-strings?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<LanguageStringsDto>(data);

            return result;
        }

        public List<string> GetLanguages(Enums.Platform platform)
        {
            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/languages?" + ApiKeyUrl, platform);
            var result = Deserialize<List<string>>(data);

            return result;
        }

        public MapDataDto GetMaps(Enums.Platform platform, string version = null, string locale = null)
        {
            string parameters = "";

            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/maps?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<MapDataDto>(data);

            return result;
        }

        public MasteryListDto GetMasteries(Enums.Platform platform, StaticDataEnums.MasteryData tags = StaticDataEnums.MasteryData.basic, string version = null, string locale = null)
        {
            string parameters = "";

            if (tags != StaticDataEnums.MasteryData.basic)
            {
                parameters += "tags=" + tags.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/masteries?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<MasteryListDto>(data);

            return result;
        }
        public MasteryDto GetMasteryById(int id, Enums.Platform platform) { throw new NotImplementedException(); }

        public ProfileIconDataDto GetProfileIcons(Enums.Platform platform, string version = null, string locale = null)
        {
            string parameters = "";

            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/profile-icons?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<ProfileIconDataDto>(data);

            return result;
        }

        public RealmDto Realms(Enums.Platform platform)
        {
            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/realms?" + ApiKeyUrl, platform);
            var result = Deserialize<RealmDto>(data);

            return result;
        }

        public RuneListDto GetRunes(Enums.Platform platform, StaticDataEnums.RuneData tags = StaticDataEnums.RuneData.basic, string version = null, string locale = null)
        {
            string parameters = "";

            if (tags != StaticDataEnums.RuneData.basic)
            {
                parameters += "tags=" + tags.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/runes?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<RuneListDto>(data);

            return result;
        }
        public RuneDto GetRuneById(int runeId, Enums.Platform platform) { throw new NotImplementedException(); }
        public SummonerSpellListDto GetSummonerSpells(Enums.Platform platform, StaticDataEnums.SummonerSpellData tags = StaticDataEnums.SummonerSpellData.basic, bool? dataById = null, string version = null, string locale = null)
        {
            string parameters = "";

            if (tags != StaticDataEnums.SummonerSpellData.basic)
            {
                parameters += "tags=" + tags.ToString().ToLower() + "&";
            }
            if (dataById.HasValue)
            {
                parameters += "dataById=" + dataById.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(version) == false)
            {
                parameters += "version=" + version.ToString().ToLower() + "&";
            }
            if (String.IsNullOrEmpty(locale) == false)
            {
                parameters += "locale=" + locale + "&";
            }

            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/summoner-spells?" + parameters + ApiKeyUrl, platform);
            var result = Deserialize<SummonerSpellListDto>(data);

            return result;
        }
        public SummonerSpellDto GetSummonerSpellById(int spellId, Enums.Platform platform) { throw new NotImplementedException(); }

        public List<string> GetVersions(Enums.Platform platform)
        {
            var data = requester.GetRequestApiCall(StaticDataBaseUrl + "/versions?" + ApiKeyUrl, platform);
            var result = Deserialize<List<string>>(data);

            return result;
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

        private T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, settings);
        }
    }
}
