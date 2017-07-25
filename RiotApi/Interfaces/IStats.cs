using RiotApi.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface IStats
    {
        RiotApi.Dto.Stats.RankedStatsDto GetRankedStatsBySummonerId(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season);
        Task<RiotApi.Dto.Stats.RankedStatsDto> GetRankedStatsBySummonerIdAsync(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season);

        RiotApi.Dto.Stats.PlayerStatsSummaryListDto GetPlayerStatsBySummonerId(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season);
        Task<RiotApi.Dto.Stats.PlayerStatsSummaryListDto> GetPlayerStatsBySummonerIdAsync(Enums.Region region, long summonerId, Enums.SeasonNoPreSeasonType season);
    }
}
