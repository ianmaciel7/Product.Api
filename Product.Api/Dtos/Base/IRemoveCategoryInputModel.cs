namespace Product.Api.Dtos.Base
{
    public interface IRemoveCategoryInputModel : ICategoryInputModel
    {
        int CategoryId { get; }
    }
}