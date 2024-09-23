using Product.Api.Data.Entities;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public interface IFindCategoriesInputModel : IInputModel<Category>
    {
        public int? CategoryId { get; }
    }
}