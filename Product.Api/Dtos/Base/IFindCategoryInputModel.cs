namespace Product.Api.Dtos.Base
{
    public interface IFindCategoryInputModel : ICategoryInputModel
    {
        int CategoryId { get; }
    }
}