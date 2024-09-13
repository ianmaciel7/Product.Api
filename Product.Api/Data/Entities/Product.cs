using Product.Api.Data.Entities.Categories;

namespace Product.Api.Data.Entities
{
    public class Product
    {
        public int ProductId { get; init; }
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public required string Description { get; init; }
        public required int CategoryId { get; init; }
        public Category? Category { get; init; }

    }
}
