using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entities;

namespace Website.Services.Interfaces
{
    public interface IMatchDataParticipantService
    {
        IEnumerable<MatchDataParticipant> Find();
        IEnumerable<MatchDataParticipant> GetAll();
        void AddEntity(List<CottontailApi.Dto.Match.ParticipantDto> listParticipantsStats, List<Tuple<int, int, int, int, int>> participantRiotSummonerIdList, long matchDatabaseId);
        void AddEntity(List<CottontailApi.Dto.Match.ParticipantDto> listParticipants, List<CottontailApi.Dto.Match.ParticipantIdentityDto> identitys, long matchDatabaseId);
        void Save(MatchDataParticipant matchDataParticipant);
        void Save(IEnumerable<MatchDataParticipant> matchDataParticipant);
        void Delete(MatchDataParticipant matchDataParticipant);
        void Delete(IList<MatchDataParticipant> matchDataParticipant);
    }
}
