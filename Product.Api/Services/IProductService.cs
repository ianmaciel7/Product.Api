using Product.Api.Dtos.Base;

namespace Product.Api.Services
{
    public interface IProductService : IService
    {
        IFindAllProductsOutputModel FindAll(IFindAllProductsInputModel inputModel);
        IFindProductOutputModel Find(IFindProductInputModel inputModel);
        IAddProductOutputModel Add(IAddProductInputModel inputModel);
        IRemoveProductOutputModel Remove(IRemoveProductInputModel inputModel);
        IUpdateProductOutputModel Update(IUpdateProductInputModel inputModel);
    }
}