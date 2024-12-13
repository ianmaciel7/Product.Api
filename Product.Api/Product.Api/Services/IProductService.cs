using Product.Api.Models.ValueObjects;

namespace Product.Api.Services
{
    public interface IProductService : ICrudService<Models.Product, ProductId>
    {

    }
}
