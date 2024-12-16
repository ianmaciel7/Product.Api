using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface ICategoryService : IServices<CategoryDto, Guid>
    {
        Task<IResult> GetAllProductsAsync(Guid categoryId);
        Task<IResult> UpdateAsync(Guid? id, CategoryDto dto);
    }
}
