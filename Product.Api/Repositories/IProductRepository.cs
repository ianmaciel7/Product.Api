using Product.Api.Dtos;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface IProductRepository : IRepository
    {
        IEnumerable<Entities.Product> Get(GetProductsInputModel inputModel);
    }
}