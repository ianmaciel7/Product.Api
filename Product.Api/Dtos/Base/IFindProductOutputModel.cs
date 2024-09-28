using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IFindProductOutputModel : IProductOutputModel
    {
        ProductId ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }
        public string Description { get; }
        public CategoryId? CategoryId { get; }
        public string? CategoryName { get; }
    }
}
