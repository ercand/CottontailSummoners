using System.Collections.Generic;
using System.Linq;
using Website.DataAccessLayer.Repositories.Interfaces;
using Website.DataAccessLayer.UnitOfWork;

namespace Website.DataAccessLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IUnitOfWork dataContext;

        public RepositoryBase(IUnitOfWork dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DataSource();
        }

        public virtual T Find(int? id)
        {
            return this.dataContext.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            this.dataContext.Set<T>().Add(entity);
            this.dataContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
        }

        public virtual void Update(T entity)
        {
            this.dataContext.Set<T>().Attach(entity);
            this.dataContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this.dataContext.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            this.SaveChanges();
        }
        
/*
        public void ExecuteCommand(string sql, params object[] parameters)
        {
            this.dataContext.ExecuteCommand(sql, parameters);
        }*/

        protected IQueryable<T> DataSource()
        {
            var query = dataContext.Set<T>().AsQueryable<T>();

            return query;
        }

        protected IQueryable<T> LocalDataSource()
        {
            var query = dataContext.Set<T>().Local.AsQueryable<T>();

            return query;
        }

        #region Private Helpers
        /// <summary>
        /// Returns expression to use in expression trees, like where statements. For example query.Where(GetExpression("IsDeleted", typeof(boolean), false));
        /// </summary>
        /// <param name="propertyName">The name of the property. Either boolean or a nulleable typ</param>
   /*     private Expression<Func<T, bool>> GetExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(T));
            var actualValueExpression = Expression.Property(param, propertyName);

            var lambda = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(actualValueExpression,
                    Expression.Constant(value)),
                param);

            return lambda;
        }*/

        protected virtual void SaveChanges()
        {
            this.dataContext.SaveChanges();
        }
        #endregion
    }
}