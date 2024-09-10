namespace Product.Api.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<Product> Products { get; init; }
    }
}
