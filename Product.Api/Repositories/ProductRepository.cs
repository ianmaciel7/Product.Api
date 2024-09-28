using Product.Api.Data;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Repositories;
using Product.Api.Repositories.Base;

internal class ProductRepository(ApplicationDbContext dbContext)
    : Repository<Entities.Product, ProductId>(dbContext), IProductRepository
{
    public IEnumerable<Entities.Product> FindAllById(ProductId? productId = null)
    {
        throw new NotImplementedException();
    }
}