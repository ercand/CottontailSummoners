using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IMatchDataParticipantStatsService
    {
        IEnumerable<MatchDataParticipantStats> Find();
        IEnumerable<MatchDataParticipantStats> GetAll();
        void AddEntity(List<CottontailApi.Dto.Match.ParticipantDto> listParticipantsStats, long matchDatabaseId, int platform);
        void Save(MatchDataParticipantStats matchDataParticipantStats);
        void Save(IEnumerable<MatchDataParticipantStats> matchDataParticipantStats);
        void Delete(MatchDataParticipantStats matchDataParticipantStats);
        void Delete(IList<MatchDataParticipantStats> matchDataParticipantStats);
    }
}
