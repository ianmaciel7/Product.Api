using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.Dtos.Base
{
    public interface IFindAllCategoriesInputModel : ICategoryInputModel
    {
        public CategoryId? CategoryId { get; }
    }
}