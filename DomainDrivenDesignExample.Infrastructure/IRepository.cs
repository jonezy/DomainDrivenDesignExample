using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DomainDrivenDesignExample.Infrastructure
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Save();

    }
}
