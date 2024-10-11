using Bogus;
using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.IntegrationTest.Fakes
{
    internal class ProductFaker : Faker<Product.Api.Data.Entities.Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.ProductId, f => new ProductId(f.IndexFaker + 1));
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Description, f => f.Lorem.Sentence());
            RuleFor(p => p.CategoryId, f => new CategoryId(f.IndexFaker + 1));
            RuleFor(p => p.Category, f => new CategoryFaker().Generate());
        }
    }
}
