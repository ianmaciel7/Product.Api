
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;
using System.Text.Json.Serialization;

namespace Product.Api.Dtos
{
    public record UpdateProductInputModel(
        [property: JsonIgnore] ProductId? ProductId,
        string Name,
        decimal Price,
        string Description,
        CategoryId CategoryId
    ) : IUpdateProductInputModel
    {
       
    }
}
