using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Api.Data;
using Product.Api.IntegrationTest.Configurations;
using Xunit.Abstractions;

namespace Product.Api.IntegrationTest
{
    public abstract class IntegrationTest
        : IClassFixture<TestServer>, IAsyncLifetime
    {
        protected HttpClient HttpClient;
        protected readonly TestServer Server;
        protected readonly ITestOutputHelper OutputHelper;
        protected ApplicationDbContext DbContext;
        public static bool _isFirstTime { get; private set; }

        public IntegrationTest(TestServer server, ITestOutputHelper outputHelper)
        {
            Server = server;
            OutputHelper = outputHelper;
        }


        public virtual void Initialize()
        {
            HttpClient = Server.CreateClient();
            var scope = Server.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            DbContext = scopedServices.GetRequiredService<ApplicationDbContext>();
        }

        public Task InitializeAsync()
        {
            Initialize();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

        public Task DisposeAsync()
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}
