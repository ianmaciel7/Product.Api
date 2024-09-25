using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record AddCategoryInputModel(
        string Name,
        string Description,
        int? ParentId = null,
        IEnumerable<AddCategoryInputModel>? Children = null
    ) : IAddCategoryInputModel
    {
        IEnumerable<IAddCategoryInputModel>? IAddCategoryInputModel.Children => Children;
    }
}
