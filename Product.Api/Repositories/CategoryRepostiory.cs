using Microsoft.EntityFrameworkCore;
using Product.Api.Models;

namespace Product.Api.Repositories
{
    public class CategoryRepostiory(IGenericRepository<Models.Category, Guid> repository) : ICategoryRepostiory
    {
        public Task<Category> CreateAsync(Category entity)
        {
            return repository.CreateAsync(entity);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> GetAllByParentIsNullAsync()
        {
            return await repository.DbSet.Where(e => e.Parent == null).ToListAsync();
        }

        public Task<Category?> GetByIdAsync(Guid id)
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
