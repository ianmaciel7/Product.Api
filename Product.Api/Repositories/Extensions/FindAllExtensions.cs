using Microsoft.EntityFrameworkCore;

namespace Product.Api.Repositories.Extensions
{
    public static class FindAllExtensions
    {
        public static IQueryable<T> FindAll<T>(this DbSet<T> dbSet, int? id = null) where T : class
        {
            var entities = dbSet.AsQueryable();

            if (id == null)
            {
                return entities;
            }

            var keyName = dbSet.GetPrimaryKeyName();

            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentException("Primary key not found.", nameof(keyName));
            }

            return entities.Where(e => EF.Property<int>(e, keyName) == id);
        }
    }

}