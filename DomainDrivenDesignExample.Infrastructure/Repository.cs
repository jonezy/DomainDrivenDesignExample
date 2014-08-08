using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DomainDrivenDesignExample.Infrastructure
{
    public class Repository<T> : IRepository<T>
    {
        private IList<T> _storage;

        public Repository()
        {
            _storage = new List<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _storage.AsQueryable<T>();
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList<T>();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _storage.AsQueryable<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Single<T>();
        }

        public void Add(T entity)
        {
            _storage.Add(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
