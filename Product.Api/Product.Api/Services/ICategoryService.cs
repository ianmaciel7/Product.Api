using Product.Api.Models.ValueObjects;

namespace Product.Api.Services
{
    public interface ICategoryService : IBasicService<Models.Category, CategoryId>
    {
    }
}
