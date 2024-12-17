namespace Product.Api.Dtos.Reponses
{
    public class ProductReponse(
        Guid CategoryId,
        string Name,
        string Description,
        decimal Price,
        ProductReponse.CategoryResponse category
    )
    {
        public record CategoryResponse(
            Guid CategoryId,
            string Name,
            string Description,
            IEnumerable<ProductResponse> Products
        );

        public record ProductResponse(
            Guid ProductId,
            string Name,
            string Description,
            decimal Price
        );
    }
}
