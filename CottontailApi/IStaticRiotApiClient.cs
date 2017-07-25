using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottontailApi.Commons;
using CottontailApi.Dto.LolStatus;
using CottontailApi.Dto.StaticData;

namespace CottontailApi
{
    public interface IStaticRiotApiClient
    {
        #region Lol-Status-V3

        ShardStatus GetShardStatus(Enums.Platform platform);

        #endregion

        #region StaticData-V3

        ChampionListDto GetChampions(Enums.Platform platform, StaticDataEnums.ChampionData championData = StaticDataEnums.ChampionData.basic, bool? dataById = null, string version = null, string locale = null);
        ChampionListDto GetChampionById(int championId, Enums.Platform platform);
        ItemListDto GetItems(Enums.Platform platform, StaticDataEnums.ItemData tags = StaticDataEnums.ItemData.Basic, string version = null, string locale = null);
        ItemDto GetItemById(int itemId, Enums.Platform platform);
        LanguageStringsDto GetLanguageString(Enums.Platform platform, string version = null, string locale = null);
        List<string> GetLanguages(Enums.Platform platform);
        MapDataDto GetMaps(Enums.Platform platform, string version = null, string locale = null);
        MasteryListDto GetMasteries(Enums.Platform platform, StaticDataEnums.MasteryData tags = StaticDataEnums.MasteryData.basic, string version = null, string locale = null);
        MasteryDto GetMasteryById(int masteryId, Enums.Platform platform);
        ProfileIconDataDto GetProfileIcons(Enums.Platform platform, string version = null, string locale = null);
        RealmDto Realms(Enums.Platform platform);
        RuneListDto GetRunes(Enums.Platform platform, StaticDataEnums.RuneData tags = StaticDataEnums.RuneData.basic, string version = null, string locale = null);
        RuneDto GetRuneById(int runeId, Enums.Platform platform);
        SummonerSpellListDto GetSummonerSpells(Enums.Platform platform, StaticDataEnums.SummonerSpellData tags = StaticDataEnums.SummonerSpellData.basic, bool? dataById = null, string version = null, string locale = null);
        SummonerSpellDto GetSummonerSpellById(int spellId, Enums.Platform platform);
        List<string> GetVersions(Enums.Platform platform);
        //Task<List<string>> GetVersionsAsync(Enums.Platform platform);

        #endregion
    }
}
