using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using Domain.Interfaces;
using CrossCutting.Base;
using Domain.Filters;

namespace Infra.Data.Repositories
{
    public class Repository<TEntity, TFilter> : IRepository<TEntity, TFilter> where TEntity : Entity where TFilter : FiltersBase<TEntity>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _set.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return _set.AddRangeAsync(entities);
        }

        public Task<List<TEntity>> GetAsync(TFilter filters)
        {
          return filters
            .GetFilters()
            .Aggregate(_set.AsQueryable(), (current, filter) => current.Where(filter))
            .ToListAsync();
        }

        private TEntity EntityInstance(Guid id)
        {
            var entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            PropertyInfo prop = entity.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(prop, id, null);
            }
            return entity;
        }
    }
}