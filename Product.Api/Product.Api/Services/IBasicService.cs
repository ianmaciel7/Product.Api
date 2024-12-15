namespace Product.Api.Services
{
    public interface IBasicService<T, TKey>
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateAsync(TKey? id,T entity);
        Task<bool> RemoveAsync(TKey id);
    }
}
