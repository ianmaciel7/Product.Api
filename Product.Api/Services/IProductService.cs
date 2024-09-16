using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface IProductService
    {
        GetProductsOutputModel Get(GetProductsInputModel inputModel);
    }
}