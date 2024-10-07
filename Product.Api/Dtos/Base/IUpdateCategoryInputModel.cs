using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IUpdateCategoryInputModel : IAddCategoryInputModel
    {
        CategoryId? CategoryId { get; }
    }
}
