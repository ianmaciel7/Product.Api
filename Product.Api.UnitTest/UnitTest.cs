using Xunit.Abstractions;

namespace Product.Api.UnitTest
{
    public abstract class UnitTest<T>(ITestOutputHelper outputHelper) : IClassFixture<T> where T : class
    {
    }
}