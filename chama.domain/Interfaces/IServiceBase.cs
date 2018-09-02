using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace chama.domain.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}