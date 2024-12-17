using Product.Api.Dtos.Requests;

namespace Product.Api.Services
{
    public interface ICategoryService : IServices<CategoryRequest, Guid>
    {
        Task<IResult> GetAllProductsAsync(Guid categoryId);
        Task<IResult> UpdateAsync(Guid? id, CategoryRequest dto);
    }
}
