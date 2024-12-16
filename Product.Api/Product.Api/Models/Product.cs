using Product.Api.Models.ValueObjects;

namespace Product.Api.Models
{
    public class Product
    {
        public required ProductId ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Description { get; set; }
        public required CategoryId CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
