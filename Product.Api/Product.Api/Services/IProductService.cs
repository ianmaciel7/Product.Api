using Product.Api.Models.ValueObjects;

namespace Product.Api.Services
{
    public interface IProductService : IBasicService<Models.Product, ProductId>
    {
        Task<IResult> GetAllAsync(CategoryId categoryId);
    }
}
