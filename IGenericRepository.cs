using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Virtual.Generic.Entities
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable();
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
