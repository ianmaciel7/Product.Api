﻿using Microsoft.EntityFrameworkCore;
using Product.Api.Repositories.Extensions;

namespace Product.Api.Repositories.Base
{
    public class Repository<T, TId>(DbContext dbContext) where T : class where TId : class
    {
        protected readonly DbContext dbContext = dbContext;
        protected DbSet<T> _dbset = dbContext.Set<T>();

        public virtual T? FindById(TId id)
        {
            return _dbset.Find(id);
        }

        public virtual IEnumerable<T> FindAllById(TId? id = null)
        {
            return _dbset.FindAll(id);
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
            var entry = _dbset.Entry(entity);
            foreach (var navigation in entry.Navigations)
            {
                navigation.Load();
            }
        }

        public virtual void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbset.Update(entity);
            var entry = _dbset.Entry(entity);
            foreach (var navigation in entry.Navigations)
            {
                navigation.Load();
            }
        }

        public virtual void Remove(T entity)
        {
            _dbset.Remove(entity);
        }


    }
}