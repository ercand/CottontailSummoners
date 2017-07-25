using RiotApi.Dto.LolStaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface ILolStaticData
    {
        Dto.LolStaticData.ChampionListDto GetChampions();
        ItemListDto GetItems();
        ItemDto GetItem(int id);
        MasteryListDto GetMasteries();
        MasteryDto GetMastery(int id);
        RealmDto Realm();
        RuneListDto GetRunes();
        RuneDto GetRune(int id);
        SummonerSpellListDto GetSummonerSpells();
        SummonerSpellDto GetSummonerSpell(int id);
        List<string> GetVersions();
        Task<List<string>> GetVersionsAsync();
        
    }
}
