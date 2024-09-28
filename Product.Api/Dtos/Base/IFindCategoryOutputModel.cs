namespace Product.Api.Dtos.Base
{
    public interface IFindCategoryOutputModel : ICategoryOutputModel
    {
        int CategoryId { get; }
        string Name { get; }
        IEnumerable<IFindCategoryOutputModel> Children { get; }
    }
}
