using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface IProductService : IServices<ProductDto, Guid>
    {
        Task<IResult> UpdateAsync(Guid? id, ProductDto dto);
    }
}
