using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public interface IEnumerableOutputModel<T> : IOutputModel,IEnumerable<T>
    {

    }
}