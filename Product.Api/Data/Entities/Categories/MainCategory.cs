namespace Product.Api.Data.Entities.Categories
{
    public class MainCategory : Category
    {
        public override int? ParentId => null;
        public override Category? Parent => null;
    }
}
