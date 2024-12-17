using Product.Api.Dtos.Requests;

namespace Product.Api.Services
{
    public interface IProductService : IServices<ProductRequest, Guid>
    {
        Task<IResult> UpdateAsync(Guid? id, ProductRequest dto);
    }
}
