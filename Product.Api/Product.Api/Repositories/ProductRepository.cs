
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Models.Product>> GetAllByCategoryIdAsync(CategoryId categoryId)
        {
            return await repository.DbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
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
