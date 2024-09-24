using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record FindAllCategoriesOutputModel(IEnumerable<IFindCategoryOutputModel> Categories) : IFindAllCategoriesOutputModel 
    {
        public IEnumerator<IFindCategoryOutputModel> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
