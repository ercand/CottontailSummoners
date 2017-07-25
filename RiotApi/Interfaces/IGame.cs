using RiotApi.Commons;
using RiotApi.Dto.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface IGame
    {
        RecentGamesDto GetRecentGames(Enums.Region region, long summonerId);
        Task<RecentGamesDto> GetRecentGamesAsync(Enums.Region region, long summonerId);
    }
}
