using Product.Api.Dtos.Base;
using Product.Api.Repositories.Base;

namespace Product.Api.Repositories
{
    public interface IProductRepository : IRepository
    {
        IEnumerable<Entities.Product> FindAllById(int? productId = null);
        Entities.Product? FindById(int productId);
        void Add(Entities.Product product);
        void SaveChanges();
    }
}