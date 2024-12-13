using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Product.Api.Repositories
{
    public interface IGenericRepository<T,TKey> : IBasicRepository<T,TKey> where T : class
    {
        Task<EntityEntry<T>?> CreateByEntry(T entity);
        EntityEntry<T> UpdateByEntry(T entity);
    }
}