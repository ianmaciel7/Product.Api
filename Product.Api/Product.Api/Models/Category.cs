using Product.Api.Models.ValueObjects;

namespace Product.Api.Models
{
    public class Category
    {
        public required CategoryId CategoryId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Product> Products { get; set; } = [];
        public List<Category> Children { get; set; } = [];
        public CategoryId? ParentId { get; set; }
        public Category? Parent { get; set; }
    }
}
