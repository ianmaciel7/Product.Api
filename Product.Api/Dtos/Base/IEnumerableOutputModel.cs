namespace Product.Api.Dtos.Base
{
    public interface IEnumerableOutputModel<T> : IOutputModel, IEnumerable<T>
    {

    }
}