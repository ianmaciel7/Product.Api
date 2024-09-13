using Product.Api.Dtos.Base;
using System.Collections;

namespace Product.Api.Dtos
{
    public record GetProductOutputModel(IEnumerable<Entities.Product> Products) : IEnumerableOutputModel<Entities.Product>
    {
        public IEnumerator<Entities.Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}