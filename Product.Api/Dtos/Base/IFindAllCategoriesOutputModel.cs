namespace Product.Api.Dtos.Base
{
    public interface IFindAllCategoriesOutputModel : IEnumerableOutputModel<IFindCategoryOutputModel>
    {
        IEnumerable<IFindCategoryOutputModel> Categories { get; }
    }
}