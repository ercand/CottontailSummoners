using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;
using Website.Entities;

namespace Website.DataAccessLayer.Repositories
{
    public class MatchDataParticipantRepository : RepositoryBase<MatchDataParticipant>, IMatchDataParticipantRepository
    {
        public MatchDataParticipantRepository(IUnitOfWork dataContext)
            : base(dataContext)
        {

        }
    }
}