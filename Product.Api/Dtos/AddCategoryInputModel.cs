using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record AddCategoryInputModel(
        string Name,
        string Description,
        int? ParentId = null,
        IEnumerable<IAddCategoryInputModel>? Children = null
    ) : IAddCategoryInputModel
    {
    }
}
