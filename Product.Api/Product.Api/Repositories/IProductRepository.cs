using Product.Api.Models.ValueObjects;

namespace Product.Api.Repositories
{
    public interface IProductRepository : IBasicRepository<Models.Product, ProductId>
    {
        public Task<IEnumerable<Models.Product>> GetAllByCategoryIdAsync(CategoryId categoryId);
    }
}