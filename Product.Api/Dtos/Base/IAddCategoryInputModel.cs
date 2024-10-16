using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IAddCategoryInputModel
    {
        string Name { get; }
        CategoryId? ParentId { get; }
        string Description { get; }
        IEnumerable<IAddCategoryInputModel>? Children { get; }
    }
}