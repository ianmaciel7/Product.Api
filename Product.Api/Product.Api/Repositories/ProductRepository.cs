
using Product.Api.Models.ValueObjects;

namespace Product.Api.Repositories
{
    public class ProductRepository(IGenericRepository<Models.Product,ProductId> repository) : IProductRepository
    {
        public Task<Models.Product?> CreateAsync(Models.Product entity)
        {
            return repository.CreateAsync(entity);
        }

        public Task<IEnumerable<Models.Product>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<Models.Product?> GetByIdAsync(ProductId id)
        {
            return repository.GetByIdAsync(id);
        }

        public bool Remove(Models.Product entity)
        {
            return repository.Remove(entity);
        }

        public Task SaveAsync()
        {
            return repository.SaveAsync();
        }

        public Models.Product Update(Models.Product entity)
        {
            return repository.Update(entity);
        }
    }
}
