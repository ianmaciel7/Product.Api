namespace Product.Api.Repositories
{
    public interface IBasicRepository<T, TKey> : IRepository
    {
        Task<T?> CreateAsync(T entity);
        Task<T?> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        T Update(T entity);
        bool Remove(T entity);
        Task SaveAsync();
    }
}