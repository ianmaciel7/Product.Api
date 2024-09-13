using Product.Api.Data.Entities.Categories;
using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record GetCategoryOutputModel(IEnumerable<Category> Categories) : IEnumerableOutputModel<Category>
    {
        public IEnumerator<Category> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
