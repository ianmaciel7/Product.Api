

using Bogus;
using Product.Api.Data.Entities;
using Product.Api.Data.Entities.ValueObjects;

namespace Product.Api.IntegrationTest.Fakes
{
    internal class CategoryFaker : Faker<Category>
    {
        public CategoryFaker(bool isProductIdNull = true,bool isParentNull = true)
        {
            RuleFor(c => c.CategoryId, f => isProductIdNull ? null : new CategoryId(f.IndexFaker + 1));
            RuleFor(c => c.Name, f => f.Commerce.Department());
            RuleFor(c => c.Description, f => f.Lorem.Sentence());
            //RuleFor(c => c.Products, f => new ProductFaker().Generate(f.Random.Int(0, 5)));
            //RuleFor(c => c.Children, f => new CategoryFaker().Generate(f.Random.Int(0, 5)));
            RuleFor(c => c.ParentId, f => isParentNull ? null : new CategoryId(f.IndexFaker + 1));
            RuleFor(c => c.Parent, f => isParentNull ? null : new CategoryFaker().Generate());
        }

        internal static Category GenerateDefault()
        {
            return new CategoryFaker(true,true).Generate();
        }
    }
}
