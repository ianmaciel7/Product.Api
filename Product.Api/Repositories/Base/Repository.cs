using Microsoft.EntityFrameworkCore;
using Product.Api.Repositories.Extensions;

namespace Product.Api.Repositories.Base
{
    public class Repository<T>(DbContext dbContext) where T : class
    {
        protected readonly DbContext dbContext = dbContext;
        protected DbSet<T> _dbset = dbContext.Set<T>();

        public T? FindById(int id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<T> FindAllById(int? id = null)
        {
            return _dbset.FindAll(id);
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
            var entry = _dbset.Entry(entity);
            foreach (var navigation in entry.Navigations)
            {
                navigation.Load();
            }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }
    }
}