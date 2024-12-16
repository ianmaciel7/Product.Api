using Product.Api.Models;
using Product.Api.Models.ValueObjects;

namespace Product.Api.Repositories
{
    public class CategoryRepostiory(IGenericRepository<Models.Category, CategoryId> repository) : ICategoryRepostiory
    {
        public Task<Category> CreateAsync(Category entity)
        {
            return repository.CreateAsync(entity);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<Category?> GetByIdAsync(CategoryId id)
        {
            return repository.GetByIdAsync(id);
        }

        public bool Remove(Category entity)
        {
            return repository.Remove(entity);
        }

        public Task SaveAsync()
        {
            return repository.SaveAsync();
        }

        public Category Update(Category entity)
        {
            return repository.Update(entity);
        }
    }
}
