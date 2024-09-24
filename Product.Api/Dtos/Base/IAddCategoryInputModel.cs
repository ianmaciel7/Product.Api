namespace Product.Api.Dtos.Base
{
    public interface IAddCategoryInputModel
    {
        string Name { get; }
        string Description { get; }
        int? ParentId { get; }
        IEnumerable<object>? Children { get; }
    }

    public interface IAddCategoryInputModel<T> : IAddCategoryInputModel where T : class
    {
        new IEnumerable<T>? Children { get; }
    }
}