namespace Product.Api.Models
{
    public class Category
    {
        public required Guid CategoryId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Product> Products { get; set; } = [];
        public List<Category> Children { get; set; } = [];
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
    }
}
