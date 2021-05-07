using Microsoft.EntityFrameworkCore;
using RecipeBlogApp.Data;
using RecipeBlogApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecipeBlogApp.Repositories
{
    public class Repository<T, U> : IRepository<T, U> where T : class
    {
        protected ApplicationDbContext RepositoryContext{get; set;}
        public Repository(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, U>> expression)
        {
            return RepositoryContext.Set<T>().Include<T, U>(expression).AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            return RepositoryContext.Set<T>().Update(entity).Entity;
        }

    }
}
