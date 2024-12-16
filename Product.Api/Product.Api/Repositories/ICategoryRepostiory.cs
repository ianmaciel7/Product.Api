using Product.Api.Models;
using Product.Api.Models.ValueObjects;

namespace Product.Api.Repositories
{
    public interface ICategoryRepostiory : IRepository<Category, CategoryId>
    {
    }
}
