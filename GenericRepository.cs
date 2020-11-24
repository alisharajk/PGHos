using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Virtual.Generic.Entities;

namespace CodeFirst
{
    public class GenericRepository<T> : IGenericRepository<T>
          where T : BaseEntity
    {
        protected GenericFireSale _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(GenericFireSale context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return _dbset.AsQueryable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).AsQueryable();
        }

        public virtual T Add(T entity)
        {
            if (entity == null)
                throw new Virtual.Helpers.FailureException("Entity cannot be null");
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            if (entity == null)
                throw new Virtual.Helpers.FailureException("Entity cannot be null");
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            if (entity == null)
                throw new Virtual.Helpers.FailureException("Entity cannot be null");
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}