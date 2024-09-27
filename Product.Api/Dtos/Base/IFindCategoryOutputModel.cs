namespace Product.Api.Dtos.Base
{
    public interface IFindCategoryOutputModel : ICategoryOutputModel
    {
        int CategoryId { get; }
        string Name { get; }
        IEnumerable<Uri> Children { get; }
        IEnumerable<Uri> Products { get; }
        IFindCategoryOutputModel Parent { get; }
    }
}
