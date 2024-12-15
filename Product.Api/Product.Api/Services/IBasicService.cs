namespace Product.Api.Services
{
    public interface IBasicService<T, TKey>
    {
        Task<IResult> CreateAsync(T entity);
        Task<IResult> GetByIdAsync(TKey id);
        Task<IResult> GetAllAsync();
        Task<IResult> UpdateAsync(TKey? id,T entity);
        Task<IResult> RemoveAsync(TKey id);
    }
}
