using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IFindCategoryInputModel : ICategoryInputModel
    {
        CategoryId CategoryId { get; }
    }
}