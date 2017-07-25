using RiotApi.Commons;
using RiotApi.Dto.Summoner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface ISummoner
    {
        /// <summary>
        /// Get summoner objects mapped by standardized summoner name for a given list of summoner names.
        /// Implementation Notes
        /// The response object contains the summoner objects mapped by the standardized summoner name, 
        /// which is the summoner name in all lower case and with spaces removed.
        /// Use this version of the name when checking if the returned object contains the data for a given summoner.
        /// This API will also accept standardized summoner names as valid parameters, although they are not required.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerNames">Comma-separated list of summoner names or standardized summoner names associated with summoners to retrieve. Maximum allowed at once is 40.</param>
        /// <returns> Map[string, SummonerDto] SummonerDto - This object contains summoner information.</returns>
        Dictionary<string, SummonerDto> GetSummonersByName(Enums.Region region, string[] summonerNames);
        Task<Dictionary<string, SummonerDto>> GetSummonersByNameAsync(Enums.Region region, string[] summonerNames);

        /// <summary>
        /// Get summoner objects mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with summoners to retrieve. Maximum allowed at once is 40.</param>
        /// <returns>Return Value: Map[string, SummonerDto] SummonerDto - This object contains summoner information.</returns>
        Dictionary<long, SummonerDto> GetSummonersById(Enums.Region region, long[] summonerIds);
        Task<Dictionary<long, SummonerDto>> GetSummonersByIdAsync(Enums.Region region, long[] summonerIds);

        /// <summary>
        /// Get mastery pages mapped by summoner ID for a given list of summoner IDs
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with masteries to retrieve. Maximum allowed at once is 40.</param>
        /// <returns></returns>
        Dictionary<string, MasteryPagesDto> GetSummonerMasteryBySummonersId(Enums.Region region, long[] summonerIds);
        Task<Dictionary<string, MasteryPagesDto>> GetSummonerMasteryBySummonersIdAsync(Enums.Region region, long[] summonerIds);

        /// <summary>
        /// Get summoner names mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with summoner names to retrieve. Maximum allowed at once is 40.</param>
        /// <returns>Return Value: Map[string, string]</returns>
        Dictionary<string, string> GetSummonersNameById(Enums.Region region, long[] summonerIds);
        Task<Dictionary<string, string>> GetSummonersNameByIdAsync(Enums.Region region, long[] summonerIds);

        /// <summary>
        /// Get rune pages mapped by summoner ID for a given list of summoner IDs.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerIds">Comma-separated list of summoner IDs associated with runes to retrieve. Maximum allowed at once is 40.</param>
        /// <returns>Return Value: Map[string, RunePagesDto] RunePagesDto - This object contains rune pages information.</returns>
        Dictionary<string, RunePagesDto> GetSummonersRunesById(Enums.Region region, long[] summonerIds);
        Task<Dictionary<string, RunePagesDto>> GetSummonersRunesByIdAsync(Enums.Region region, long[] summonerIds);
    }
}
