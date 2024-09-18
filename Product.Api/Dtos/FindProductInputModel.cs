namespace Product.Api.Dtos
{
    public record FindProductInputModel(int? ProductId) : IFindProductsInputModel
    {
    }
}
