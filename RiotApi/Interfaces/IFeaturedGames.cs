using RiotApi.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface IFeaturedGames
    {
        Dto.FeaturedGames.FeaturedGames GetFeaturedGames(Enums.Region region);
        Task<Dto.FeaturedGames.FeaturedGames> GetFeaturedGamesAsync(Enums.Region region);
    }
}
