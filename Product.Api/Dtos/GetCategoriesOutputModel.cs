using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record GetCategoriesOutputModel(IEnumerable<CompactCategoryOutputModel> Categories) : IEnumerableOutputModel<CompactCategoryOutputModel>
    {
        public IEnumerator<CompactCategoryOutputModel> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
