

using Bogus;
using Product.Api.Data.Entities;
using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.IntegrationTest.Fakes
{
    internal class CategoryFaker : Faker<Category>
    {
        public CategoryFaker()
        {
            RuleFor(c => c.CategoryId, f => new CategoryId(f.IndexFaker + 1));
            RuleFor(c => c.Name, f => f.Commerce.Department());
            RuleFor(c => c.Description, f => f.Lorem.Sentence());
            //RuleFor(c => c.Products, f => new ProductFaker().Generate(f.Random.Int(0, 5)));
            //RuleFor(c => c.Children, f => new CategoryFaker().Generate(f.Random.Int(0, 5)));
            RuleFor(c => c.ParentId, (f, c) => f.Random.Bool() ? new CategoryId(f.IndexFaker + 1) : null);
            RuleFor(c => c.Parent, f => f.Random.Bool() ? new CategoryFaker().Generate() : null);
        }

        internal static Category Create()
        {
            return new CategoryFaker().Generate();
        }
    }
}
