using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IFindCategoryOutputModel : ICategoryOutputModel
    {
        CategoryId CategoryId { get; }
        string Name { get; }
        IEnumerable<IFindCategoryOutputModel> Children { get; }
    }
}
