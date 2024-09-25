using Product.Api.Data;
using Product.Api.Repositories;
using Product.Api.Repositories.Base;

internal class ProductRepository(ApplicationDbContext dbContext) : Repository<Entities.Product>(dbContext), IProductRepository
{
}