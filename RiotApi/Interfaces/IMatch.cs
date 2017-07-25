using RiotApi.Commons;
using RiotApi.Dto.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface IMatch
    {
        MatchDetail GetMatchById(Enums.Region region, long matchId, bool timeLine);
        Task<MatchDetail> GetMatchByIdAsync(Enums.Region region, long matchId, bool timeLine);

    }
}
