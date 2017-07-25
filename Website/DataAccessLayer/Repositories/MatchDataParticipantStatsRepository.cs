using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class MatchDataParticipantStatsRepository : RepositoryBase<MatchDataParticipantStats>, IMatchDataParticipantStatsRepository
    {
        public MatchDataParticipantStatsRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }
    }
}