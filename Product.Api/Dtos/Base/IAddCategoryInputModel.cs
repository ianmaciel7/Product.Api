using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IAddCategoryInputModel
    {
        string Name { get; }
        string Description { get; }
        CategoryId? ParentId { get; }
        IEnumerable<IAddCategoryInputModel>? Children { get; }
    }
}