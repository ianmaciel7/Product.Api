using Product.Api.Data;
using Product.Api.Data.Entities.Categories;
using Product.Api.Dtos;

namespace Product.Api.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
    {
        public Category? Find(FindCategoryInputModel? inputModel = null)
        {
            var entities = dbContext.Categories;

            if (inputModel is null)
            {
                return null;
            }

            return entities.Find(inputModel.CategoryId);
        }

        public IEnumerable<Category> FindAll(FindAllCategoriesInputModel? inputModel = null)
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
