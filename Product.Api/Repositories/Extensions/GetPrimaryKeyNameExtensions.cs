using Microsoft.EntityFrameworkCore;

namespace Product.Api.Repositories.Extensions
{
    public static class GetPrimaryKeyNameExtensions
    {
        public static string? GetPrimaryKeyName<T>(this DbSet<T> dbSet) where T : class
        {
            var entityType = dbSet.EntityType;
            var key = entityType.FindPrimaryKey();
            return key?.Properties?.FirstOrDefault()?.Name;
        }
    }
}
