namespace Product.Api.Dtos.Base
{
    public interface IFindProductOutputModel : IProductOutputModel
    {
        int ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }
        public string Description { get; }
        public IFindCategoryOutputModel? Category { get; }
    }
}
