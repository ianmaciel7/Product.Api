using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindProductInputModel(ProductId ProductId) : IFindProductInputModel
    {
    }
}
