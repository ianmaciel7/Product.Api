using Product.Api.Data.Entities;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> FindAllById(CategoryId? categoryId = null);
        Category? FindById(CategoryId categoryId);
        void Add(Category category);
        void SaveChanges();
        void Update(Category category);
        void Remove(Category category);
    }
}
