
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record UpdateProductInputModel(
        int? ProductId,
        string Name,
        decimal Price,
        string Description,
        int CategoryId
    ) : IUpdateProductInputModel
    {
       
    }
}
