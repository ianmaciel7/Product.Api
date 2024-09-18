using Product.Api.Data.Entities.Categories;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public interface IFindCategoriesInputModel : IInputModel<Category>
    {
        public int? CategoryId { get; }
    }
}