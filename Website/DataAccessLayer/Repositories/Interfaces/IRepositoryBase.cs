using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.DataAccessLayer.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Retrieves all records that have not been deleted
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        void Delete(T entity);
        void Insert(T entity);
        void Save();
        void Update(T entity);
        T Find(int? id);
    }
}