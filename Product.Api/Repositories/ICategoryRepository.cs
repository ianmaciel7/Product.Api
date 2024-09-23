using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        IEnumerable<Category> FindAll(FindAllCategoriesInputModel? inputModel = null);
        Category? Find(FindCategoryInputModel? inputModel = null);
    }
}
