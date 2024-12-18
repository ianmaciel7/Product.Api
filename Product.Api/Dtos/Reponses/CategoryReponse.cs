
namespace Product.Api.Dtos.Reponses
{
    public record CategoryReponse(
        Guid CategoryId, 
        string Name, 
        string Description, 
        IEnumerable<CategoryReponse.Product> Products, 
        IEnumerable<CategoryReponse.Child> Children)
    {
        public record Child(
            string Name,
            string Description,
            IEnumerable<Product> Products,
            IEnumerable<Child> Children
        );

        public record Product(Guid ProductId, string Name, string Description, decimal Price);
    }


}
