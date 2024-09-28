using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public interface IFindAllCategoriesInputModel : ICategoryInputModel
    {
        public CategoryId? CategoryId { get; }
    }
}