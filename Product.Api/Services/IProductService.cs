using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface IProductService
    {
        FindAllProductsOutputModel FindAll(FindAllProductsInputModel inputModel);
        FindProductOutputModel Find(FindProductInputModel inputModel);
    }
}