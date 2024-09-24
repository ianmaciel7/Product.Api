using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public interface IFindAllCategoriesInputModel : ICategoryInputModel
    {
        public int? CategoryId { get; }
    }
}