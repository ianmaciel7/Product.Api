
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record UpdateProductInputModel(
        ProductId? ProductId,
        string Name,
        decimal Price,
        string Description,
        CategoryId CategoryId
    ) : IUpdateProductInputModel
    {
       
    }
}
