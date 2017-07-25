using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website.Entities;

namespace Website.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public UnitOfWork()
            : base("DefaultConnection")
        {
            //    base.Set<Summoner>().Include(p => p.PlayerLeague).ToArray();
            //   base.Configuration.AutoDetectChangesEnabled = false;
            treeeeeeeeeeeeeeeeeeee = DateTime.UtcNow;
        }
        public DateTime treeeeeeeeeeeeeeeeeeee;
        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<MasteryPage> MasteryPages { get; set; }
        public DbSet<RunePage> RunePages { get; set; }
        public DbSet<PlayerLeague> PlayersLeague { get; set; }
        public DbSet<PlayerChampionRankedStats> PlayerChampionRankedStats { get; set; }
        public DbSet<MatchData> Match { get; set; }
        public DbSet<MatchDataParticipant> MatchParticipant { get; set; }
        public DbSet<MatchDataParticipantStats> MatchParticipantStats { get; set; }
        public DbSet<MatchDataTeam> MatchTeam { get; set; }
        public DbSet<RankedMatchToProcess> RankedMatchToProcess { get; set; }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry<T>(entity);
        }
        public new int SaveChanges()
        {
            base.Configuration.AutoDetectChangesEnabled = true;
            int result = 0;
            bool saved = false;
            do
            {
                try
                {
                    result = base.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var databaseEntry = entry.GetDatabaseValues();
                    base.Entry(ex.Entries.First().Entity).State = System.Data.Entity.EntityState.Detached;
                }
                catch (DbUpdateException ex)
                {
                    var sqlException = ex.InnerException.InnerException as SqlException;


                    if (sqlException != null && sqlException.Errors.OfType<SqlError>()
                         .Any(se => se.Number == 2601 || se.Number == 2627))  /* PK or UKC violation */
                    {
                        // it's a dupe... do something about it, 
                        //depending on business rules, maybe discard new insert and attach to existing item
                        base.Entry(ex.Entries.First().Entity).State = System.Data.Entity.EntityState.Detached;
                        //    ctx.Students.Local.Remove(item.Entity as Student);

                        saved = false;
                    }
                    else
                    {
                        // it's some other error, throw back exception
                        throw;
                    }

                }

            } while (saved == false);
            return result;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}