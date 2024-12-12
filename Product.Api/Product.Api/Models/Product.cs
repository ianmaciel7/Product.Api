using Product.Api.Models.ValueObjects;

namespace Product.Api.Models
{
    public class Product
    {
        public virtual required ProductId ProductId { get; set; }
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public required string Description { get; init; }
        public virtual required CategoryId CategoryId { get; init; }
        public virtual Category? Category { get; init; }

    }
}
