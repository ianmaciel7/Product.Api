namespace Product.Api.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<T, TKey> : IRepository where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T?> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        T Update(T entity);
        bool Remove(T entity);
        Task SaveAsync();
    }
}