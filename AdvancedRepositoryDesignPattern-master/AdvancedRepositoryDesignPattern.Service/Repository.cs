using System.Collections.Generic;
using System.Linq;
using AdvancedRepositoryDesignPattern.Data.Contexts;
using AdvancedRepositoryDesignPattern.Data.Interfaces;

namespace AdvancedRepositoryDesignPattern.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dbContext)
        {
            _dataContext = dbContext;
        }


        public IEnumerable<T> List()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T Find(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            _dataContext.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var result = false;

            var entity = Find(id);

            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                _dataContext.SaveChanges();

                result = true;
            }

            return result;
        }

        public IQueryable<T> Query()
        {
            return _dataContext.Set<T>();
        }
    }
}