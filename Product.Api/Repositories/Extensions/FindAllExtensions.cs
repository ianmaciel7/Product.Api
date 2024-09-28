using Microsoft.EntityFrameworkCore;

namespace Product.Api.Repositories.Extensions
{
    public static class FindAllExtensions
    {
        public static IQueryable<T> FindAll<T,TId>(this DbSet<T> dbSet, TId? id = null) 
            where T : class
            where TId : class
        {
            var entities = dbSet.AsQueryable();

            if (id == null || id.Equals(default(TId)))
            {
                return entities;
            }

            var keyName = dbSet.GetPrimaryKeyName();

            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentException("Primary key not found.", nameof(keyName));
            }

            return entities.Where(e => EF.Property<TId>(e, keyName).Equals(id));
        }
    }

}