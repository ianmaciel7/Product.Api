using Microsoft.Extensions.DependencyInjection;
using Product.Api.Data;
using Product.Api.IntegrationTest.Configurations;
using Xunit.Abstractions;

namespace Product.Api.IntegrationTest
{
    public abstract class IntegrationTest(InMemoryServer server, ITestOutputHelper outputHelper) 
        : IClassFixture<InMemoryServer>, IAsyncLifetime
    {
        protected HttpClient HttpClient;
        protected readonly InMemoryServer server = server;
        protected readonly ITestOutputHelper outputHelper = outputHelper;
        protected ApplicationDbContext? DbContext;


        public virtual void Initialize()
        {
            HttpClient = server.CreateClient();
            using var scope = server.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            DbContext = scopedServices.GetRequiredService<ApplicationDbContext>();
          
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
        }

        public Task InitializeAsync()
        {
            Initialize();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

        public Task DisposeAsync()
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}
