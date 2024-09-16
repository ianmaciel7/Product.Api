using Microsoft.EntityFrameworkCore;
using Product.Api.Data;
using Product.Api.Dtos;
using Product.Api.Repositories;

internal class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
{
    public IEnumerable<Entities.Product> Get(GetProductsInputModel inputModel)
    {
        var entities = dbContext.Products;
        if (inputModel == null)
        {
            return entities;
        }

        return entities.Include(e => e.Category);
    }
}