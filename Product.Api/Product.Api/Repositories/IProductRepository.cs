namespace Product.Api.Repositories
{
    public interface IProductRepository : IRepository<Models.Product, Guid>
    {
        public Task<IEnumerable<Models.Product>> GetAllByCategoryIdAsync(Guid categoryId);
    }
}