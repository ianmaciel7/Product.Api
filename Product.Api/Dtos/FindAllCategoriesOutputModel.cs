using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record FindAllCategoriesOutputModel(IEnumerable<FindCategoryOutputModel> Categories) : IEnumerableOutputModel<FindCategoryOutputModel>
    {
        public IEnumerator<FindCategoryOutputModel> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
