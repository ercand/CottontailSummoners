using RiotApi.Commons;
using RiotApi.Dto.CurrentGame;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface ICurrentGame
    {
        /// <summary>
        /// Get current game information for the given summoner ID
        /// </summary>
        /// <param name="region">The platform ID for which to fetch data.</param>
        /// <param name="summonerId">The ID of the summoner.</param>
        /// <returns>CurrentGameInfo</returns>
        CurrentGameInfo GetCurrentGame(Enums.Region region, long summonerId);

        /// <summary>
        /// Get current game information for the given summoner ID
        /// </summary>
        /// <param name="region">The platform ID for which to fetch data.</param>
        /// <param name="summonerId">The ID of the summoner.</param>
        /// <returns>CurrentGameInfo</returns>
        Task<CurrentGameInfo> GetCurrentGameAsync(Enums.Region region, long summonerId);
    }
}
        
