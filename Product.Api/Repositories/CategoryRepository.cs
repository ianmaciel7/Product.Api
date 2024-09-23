using Product.Api.Data;
using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Repositories.Extensions;

namespace Product.Api.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
    {
        public Category? Find(FindCategoryInputModel? inputModel = null)
        {
            return dbContext.Categories.Find(inputModel?.CategoryId);
        }

        public IEnumerable<Category> FindAll(FindAllCategoriesInputModel? inputModel = null)
        {
            return dbContext.Categories.FindAll(inputModel?.CategoryId);
        }
    }
}
