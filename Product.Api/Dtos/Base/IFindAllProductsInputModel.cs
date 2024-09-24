namespace Product.Api.Dtos.Base
{
    public interface IFindAllProductsInputModel : ICategoryInputModel
    {
        int? ProductId { get; }
    }
}
