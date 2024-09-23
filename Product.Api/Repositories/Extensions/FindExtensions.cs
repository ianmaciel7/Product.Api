using Microsoft.EntityFrameworkCore;

namespace Product.Api.Repositories.Extensions
{
    public static class FindExtensions
    {
        public static T? Find<T>(this DbSet<T> dbSet,int? id=null) where T : class
        {
            if (id is null)
            {
                return null;
            }
            //var keyName = dbSet.GetPrimaryKeyName();
            //ArgumentException.ThrowIfNullOrEmpty(keyName, nameof(keyName));
            return dbSet.Find(id);
        }
    }
}
