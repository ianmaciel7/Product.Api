namespace Product.Api.Dtos
{
    public record FindAllProductsInputModel(int? ProductId) : IFindProductsInputModel
    {
    }
}