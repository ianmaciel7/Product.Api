namespace Product.Api.Dtos.Requests
{
    public record ProductRequest(
        string Name,
        string Description,
        decimal Price,
        Guid? CategoryId = null,
        ProductRequest.CategoryRequest? Category = null
    )
    {
        public record CategoryRequest(
            Guid CategoryId,
            string Name,
            string Description,
            IEnumerable<ProductPreviewRequest> Products
        );

        public record ProductPreviewRequest(
            Guid ProductId,
            string Name,
            string Description,
            decimal Price
        );
    };
}
