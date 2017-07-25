using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Website.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Summoner> Summoner { get; set; }
        public DbSet<MasteryPage> MasteryPages { get; set; }
        public DbSet<RunePage> RunePages { get; set; }

        public DatabaseContext()
            : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}