using chama.domain.Entities;
using chama.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace chama.domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly ChamaContext _chamaContext;

        public ServiceBase(ChamaContext chamaContext)
        {
            _chamaContext = chamaContext;
        }

        public void Add(TEntity obj)
        {
            _chamaContext.Add(obj);
        }

        public TEntity GetByID(int id)
        {
            return _chamaContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _chamaContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _chamaContext.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity obj)
        {
            _chamaContext.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _chamaContext.Remove(obj);
        }
    }
}
