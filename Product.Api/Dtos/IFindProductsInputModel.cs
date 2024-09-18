using Product.Api.Data.Entities.Categories;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public interface IFindProductsInputModel : IInputModel<Category>
    {
        int? ProductId { get; }
    }
}