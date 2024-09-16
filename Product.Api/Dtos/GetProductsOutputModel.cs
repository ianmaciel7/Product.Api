using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record GetProductsOutputModel(IEnumerable<CompactProcuctOutputModel> Products) : IEnumerableOutputModel<CompactProcuctOutputModel>
    {
        public IEnumerator<CompactProcuctOutputModel> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}