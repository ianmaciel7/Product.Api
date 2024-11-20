using Microsoft.EntityFrameworkCore;

namespace Product.Api.Data.Extensions
{
    public static class MigrateExtensions
    {
        public static IHost Migrate(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsInMemory())
            {
                return host;
            }
            context.Database.Migrate();
            return host;
        }
    }
}
