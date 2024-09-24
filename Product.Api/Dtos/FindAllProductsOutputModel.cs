using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record FindAllProductsOutputModel(IEnumerable<IFindProductOutputModel> Products) : IFindAllProductsOutputModel
    {
        public IEnumerator<IFindProductOutputModel> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}