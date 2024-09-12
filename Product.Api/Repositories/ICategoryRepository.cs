using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        IEnumerable<Category> List(GetCategoryInputModel? inputModel = null);
    }
}
