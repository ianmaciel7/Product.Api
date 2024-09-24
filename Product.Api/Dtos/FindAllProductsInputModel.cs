using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindAllProductsInputModel(int? ProductId) : IFindAllProductsInputModel
    {
    }
}