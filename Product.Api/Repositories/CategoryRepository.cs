using Product.Api.Data;
using Product.Api.Data.Entities;
using Product.Api.Dtos;

namespace Product.Api.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
    {
        public IEnumerable<Category> List(GetCategoryInputModel? inputModel = null)
        {
            var entities = dbContext.Categories;
            if (inputModel == null)
            {
                return entities;
            }

            return entities;
        }
    }
}
