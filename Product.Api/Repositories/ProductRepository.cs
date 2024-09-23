using Product.Api.Data;
using Product.Api.Dtos;
using Product.Api.Repositories;
using Product.Api.Repositories.Extensions;

internal class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
{
    public Entities.Product? Find(FindProductInputModel inputModel)
    {
        return dbContext.Products.Find(inputModel?.ProductId);
    }

    public IEnumerable<Entities.Product> FindAll(FindAllProductsInputModel? inputModel = null)
    {
        return dbContext.Products.FindAll(inputModel?.ProductId);
    }
}