using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface IProductRepository : IRepository<Entities.Product>
    {
        IEnumerable<Entities.Product> FindAllById(ProductId? productId = null);
        Entities.Product? FindById(ProductId productId);
        void Add(Entities.Product product);
        void SaveChanges();
        void Update(Entities.Product product);
        void Remove(Entities.Product product);
    }
}