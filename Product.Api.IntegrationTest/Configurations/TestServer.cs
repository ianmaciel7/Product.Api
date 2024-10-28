using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Product.Api.IntegrationTest.Configurations
{
    public class TestServer : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var inMemorySettings = new Dictionary<string, string>
                {
                    { "DatabaseProvider", "InMemory" },
                    { "DefaultDatabaseName", "ProductsTest" }
                };

                config.AddInMemoryCollection(inMemorySettings);
            });
        }
    }
}
