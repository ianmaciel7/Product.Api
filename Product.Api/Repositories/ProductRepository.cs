using Product.Api.Data;
using Product.Api.Dtos;
using Product.Api.Repositories;

internal class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
{
    public Entities.Product? Find(FindProductInputModel inputModel)
    {
        var entities = dbContext.Products;
        if (inputModel is null)
        {
            return null;
        }
        return entities.Find(inputModel.ProductId);
    }

    public IEnumerable<Entities.Product> FindAll(FindAllProductsInputModel? inputModel = null)
    {
        var entities = dbContext.Products;

        if (inputModel == null || inputModel.ProductId == null)
        {
            return entities;
        }

        return entities.Where(e => e.ProductId == inputModel.ProductId);
    }
}