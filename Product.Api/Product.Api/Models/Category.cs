using Product.Api.Models.ValueObjects;

namespace Product.Api.Models
{
    public class Category
    {
        public virtual required CategoryId CategoryId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public virtual List<Product> Products { get; set; } = [];
        public virtual List<Category> Children { get; set; } = [];
        public virtual CategoryId? ParentId { get; set; }
        public virtual Category? Parent { get; set; }
    }
}
