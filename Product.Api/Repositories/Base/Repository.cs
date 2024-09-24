using Microsoft.EntityFrameworkCore;
using Product.Api.Repositories.Extensions;

namespace Product.Api.Repositories.Base
{
    public class Repository<T>(DbContext dbContext) where T : class
    {
        protected readonly DbContext dbContext = dbContext;
        protected DbSet<T> _dbset = dbContext.Set<T>();

        public T? FindById(int categoryId)
        {
            return _dbset.Find(categoryId);
        }

        public IEnumerable<T> FindAllById(int? categoryId = null)
        {
            return _dbset.FindAll(categoryId);
        }

        public void Add(T category)
        {
            _dbset.Add(category);
            var entry = _dbset.Entry(category);
            foreach (var navigation in entry.Navigations)
            {
                navigation.Load();
            }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}