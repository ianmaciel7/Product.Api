using Product.Api.Dtos;
using Product.Api.Models.ValueObjects;

namespace Product.Api.Services
{
    public interface IProductService : IServices<Models.Product, ProductId>
    {
        Task<IResult> CreateAsync(ProductDto product);
        Task<IResult> UpdateAsync(ProductId? productId, ProductDto product);
    }
}
