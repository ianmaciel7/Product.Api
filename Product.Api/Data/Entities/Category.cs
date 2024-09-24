namespace Product.Api.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public virtual List<Product> Products { get; init; } = [];
        public virtual List<Category> Children { get; init; } = [];
        public int? ParentId { get; init; }
        public virtual Category? Parent { get; init; }
    }
}
