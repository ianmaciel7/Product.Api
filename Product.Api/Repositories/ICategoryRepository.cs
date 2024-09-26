using Product.Api.Data.Entities;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> FindAllById(int? categoryId =null);
        Category? FindById(int categoryId);
        void Add(Category category);
        void SaveChanges();
        void Update(Category category);
    }
}
