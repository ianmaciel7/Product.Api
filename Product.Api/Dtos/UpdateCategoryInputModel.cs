using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;
using System.Text.Json.Serialization;

namespace Product.Api.Dtos
{
    public record UpdateCategoryInputModel(
        [property: JsonIgnore] CategoryId? CategoryId,
        string Name,
        CategoryId? ParentId,
        string Description,
        IEnumerable<IAddCategoryInputModel>? Children
    ) : IUpdateCategoryInputModel
    {  
    }
}
