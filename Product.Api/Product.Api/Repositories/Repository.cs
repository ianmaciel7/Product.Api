using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.Api.Data;

namespace Product.Api.Repositories
{
    public class Repository<T, TKey>(ApplicationDbContext dbContext) : IGenericRepository<T, TKey> where T : class
    {
        private DbSet<T> DbSet => dbContext.Set<T>();

        public async Task<EntityEntry<T>?> CreateByEntry(T entity)
        {
            var entry = await DbSet.AddAsync(entity);
            return entry;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public bool Remove(T entity)
        {
            DbSet.Remove(entity);
            return true;
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public EntityEntry<T> UpdateByEntry(T entity)
        {
            return DbSet.Update(entity);
        }

        async Task<T?> IBasicRepository<T, TKey>.CreateAsync(T entity)
        {
            var entry = await CreateByEntry(entity);
            return entry?.Entity;
        }

        T IBasicRepository<T, TKey>.Update(T entity)
        {
            var entry = UpdateByEntry(entity);
            return entry.Entity;
        }
    }
}
