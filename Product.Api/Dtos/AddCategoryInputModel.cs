using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record AddCategoryInputModel(
        string Name,
        string Description,
        CategoryId? ParentId = null,
        IEnumerable<IAddCategoryInputModel>? Children = null
    ) : IAddCategoryInputModel
    {
    }
}
