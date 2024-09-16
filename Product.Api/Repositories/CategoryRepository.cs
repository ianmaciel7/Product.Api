using Microsoft.EntityFrameworkCore;
using Product.Api.Data;
using Product.Api.Data.Entities.Categories;
using Product.Api.Dtos;

namespace Product.Api.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
    {
        public IEnumerable<Category> Get(GetCategoriesInputModel? inputModel = null)
        {
            var entities = dbContext.Categories;
            if (inputModel == null)
            {
                return entities;
            }

            return entities.Include(e => e.SubCategories).Include(e => e.Products);
        }
    }
}
