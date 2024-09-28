using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IFindAllProductsInputModel : ICategoryInputModel
    {
        ProductId? ProductId { get; }
    }
}
