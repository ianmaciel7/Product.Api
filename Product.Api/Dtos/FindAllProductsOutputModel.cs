using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record FindAllProductsOutputModel(IEnumerable<FindProductOutputModel> Products) : IEnumerableOutputModel<FindProductOutputModel>
    {
        public IEnumerator<FindProductOutputModel> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}