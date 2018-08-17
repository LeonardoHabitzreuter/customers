using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrossCutting.Base;
using Domain.Filters;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity, TFilter> where TEntity : Entity where TFilter : FiltersBase<TEntity>
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<List<TEntity>> GetAsync(TFilter filters);
    }
}