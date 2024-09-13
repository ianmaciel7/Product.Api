namespace Product.Api.Data.Entities.Categories
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<Product> Products { get; init; } = [];
        public List<Category> SubCategories { get; init; } = [];
        public virtual int? ParentId { get; init; }
        public virtual Category? Parent { get; init; }
    }
}
