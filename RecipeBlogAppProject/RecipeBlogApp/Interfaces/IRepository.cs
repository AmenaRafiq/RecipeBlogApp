using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RecipeBlogApp.Interfaces
{
    public interface IRepository<T, U>
    {
        IEnumerable<T> FindAll(Expression<Func<T, U>> expression);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> Expression);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
