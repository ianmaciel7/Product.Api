using Product.Api.Data;
using Product.Api.Data.Entities;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    internal class CategoryRepository(ApplicationDbContext dbContext) : Repository<Category, CategoryId>(dbContext), ICategoryRepository
    {
    }
}
