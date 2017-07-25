using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Website.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
      //  void ExecuteCommand(string command, params object[] parameters);
    }
}