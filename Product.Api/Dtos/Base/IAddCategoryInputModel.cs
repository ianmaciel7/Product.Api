namespace Product.Api.Dtos.Base
{
    public interface IAddCategoryInputModel
    {
        string Name { get; }
        string Description { get; }
        int? ParentId { get; }
        IEnumerable<IAddCategoryInputModel>? Children { get; }
    }
}