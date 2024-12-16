using Product.Api.Dtos;
using Product.Api.Models.ValueObjects;

namespace Product.Api.Services
{
    public interface ICategoryService : IServices<Models.Category, CategoryId>
    {
        Task<IResult> CreateAsync(CategoryDto category);
        Task<IResult> GetAllProductsAsync(CategoryId categoryId);
        Task<IResult> UpdateAsync(CategoryId? categoryId, CategoryDto category);
    }
}
