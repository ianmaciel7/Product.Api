using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Product.Api.IntegrationTest.Configurations
{
    public class TestServer : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(static (context, config) =>
            {
                var env = new Dictionary<string, string?>
                {
                        { "DatabaseProvider", "InMemory" }
                };

                config.AddInMemoryCollection(env);
            });
        }
    }
}
