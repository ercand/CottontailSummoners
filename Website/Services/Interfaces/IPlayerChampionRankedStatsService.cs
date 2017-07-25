using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IPlayerChampionRankedStatsService
    {
        void AddChampionStats(List<CottontailApi.Dto.Match.ParticipantDto> stats, List<CottontailApi.Dto.Match.ParticipantIdentityDto> identitys, int platform, int queueId, int seasonId);
        
        /// <summary>
        /// Trova le statistiche di tutti i champion. L'ID da passare quello che della colonna ID e non il SummonerID
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlayerChampionRankedStats> FindChampionsStats(Entities.Summoner entitySummoner, CottontailApi.Commons.Enums.Platform platform, CottontailApi.Commons.Enums.SeasonNoPreSeasonType season);

        IEnumerable<PlayerChampionRankedStats> FindAllSeasonChampionStats(Entities.Summoner entitySummoner, CottontailApi.Commons.Enums.Platform platform);


        IEnumerable<PlayerChampionRankedStats> FindSingleChampionStats(Entities.Summoner entitySummoner, CottontailApi.Commons.Enums.Platform platform, List<int> championId, CottontailApi.Commons.Enums.SeasonNoPreSeasonType season);

        IEnumerable<PlayerChampionRankedStats> FindAllPlayerChampionStats(List<Entities.Summoner> entitySummoner, CottontailApi.Commons.Enums.Platform platform, CottontailApi.Commons.Enums.SeasonNoPreSeasonType season);

        /// <summary>
        /// Trova le statistiche dei champion elencati per ogni summoner. L'ID da passare quello che della colonna ID e non il SummonerID
        /// </summary>
        /// <param name="toSearch">Dizionario
        ///     <key>Valore del campo ID dell'entità <see cref="Entities.Summoner"/> del summoner che ci interessa</key>
        ///     <value>Lista che contiene gli ID dei champion di cui vogliamo le stats</value>
        /// </param>
        /// <returns></returns>
        IEnumerable<PlayerChampionRankedStats> Find(Dictionary<int, List<int>> toSearch);
        IEnumerable<PlayerChampionRankedStats> GetAll();
        void Save(PlayerChampionRankedStats summonerStats);
        void Save(IEnumerable<PlayerChampionRankedStats> summonerStats);
        void Delete(PlayerChampionRankedStats summonerStats);
        void Delete(IList<PlayerChampionRankedStats> summonerStats);
    }
}