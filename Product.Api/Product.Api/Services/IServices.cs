namespace Product.Api.Services
{
    public interface IServices
    {
    }

    public interface IServices<TDto, TKey> : IServices
    {
        Task<IResult> CreateAsync(TDto dto);
        Task<IResult> GetByIdAsync(TKey id);
        Task<IResult> GetAllAsync();
        Task<IResult> UpdateAsync(TKey? id, TDto dto);
        Task<IResult> RemoveAsync(TKey id);
    }
}
