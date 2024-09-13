using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface IProductService
    {
        GetProductOutputModel Get(GetProductInputModel inputModel);
    }
}