using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.Api.Data;

namespace Product.Api.Repositories
{
    public class GenericRepository<T, TKey>(ApplicationDbContext dbContext) : IGenericRepository<T, TKey> where T : class
    {
        public DbSet<T> DbSet => dbContext.Set<T>();

        public async Task<T> CreateAsync(T entity)
        {
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public async Task<EntityEntry<T>> CreateByEntry(T entity)
        {
            return await DbSet.AddAsync(entity);
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
            return DbSet.Remove(entity).State == EntityState.Deleted;
        }

        public Task SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            return DbSet.Update(entity).Entity;
        }

        public EntityEntry<T> UpdateByEntry(T entity)
        {
            return DbSet.Update(entity);
        }
    }
}
