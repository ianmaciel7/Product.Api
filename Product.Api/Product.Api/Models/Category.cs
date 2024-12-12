using Product.Api.Models.ValueObjects;

namespace Product.Api.Models
{
    public class Category
    {
        public virtual required CategoryId CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public virtual List<Product> Products { get; init; } = [];
        public virtual List<Category> Children { get; init; } = [];
        public virtual CategoryId? ParentId { get; init; }
        public virtual Category? Parent { get; init; }
    }
}
