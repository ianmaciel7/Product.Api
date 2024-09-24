using Product.Api.Dtos;
using Product.Api.Dtos.Base;

namespace Product.Api.Services
{
    public interface IProductService
    {
        IFindAllProductsOutputModel FindAll(IFindAllProductsInputModel inputModel);
        IFindProductOutputModel Find(IFindProductInputModel inputModel);
        IAddProductOutputModel Add(IAddProductInputModel inputModel);
    }
}