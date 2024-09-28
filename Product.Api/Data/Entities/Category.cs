using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Data.Entities
{
    public class Category
    {
        public virtual required CategoryId CategoryId { get; set; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public virtual List<Product> Products { get; init; } = [];
        public virtual List<Category> Children { get; init; } = [];
        public virtual CategoryId? ParentId { get; init; }
        public virtual Category? Parent { get; init; }
    }
}
