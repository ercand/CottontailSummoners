using RiotApi.Commons;
using RiotApi.Dto.Champion;
using RiotApi.EndPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface IChampion
    {
        ChampionListDto GetChampions(Enums.Region region, bool freeToPlay = false);
        Task<ChampionListDto> GetChampionsAsync(Enums.Region region, bool freeToPlay = false);
        ChampionDto GetChampion(Enums.Region region, int championId);
        Task<ChampionDto> GetChampionAsync(Enums.Region region, int championId);
    }
}
