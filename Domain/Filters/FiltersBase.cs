using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CrossCutting.Base;

namespace Domain.Filters
{
    public abstract class FiltersBase<T> where T : Entity
    {
        private readonly List<Expression<Func<T, bool>>> _filtersExpressions;
        protected IReadOnlyCollection<Expression<Func<T, bool>>> FiltersExpressions => _filtersExpressions;
        
        protected FiltersBase()
        {
            _filtersExpressions = new List<Expression<Func<T, bool>>>();
        }

        protected void Where(bool valid, Expression<Func<T, bool>> expression)
        {
            if (valid) _filtersExpressions.Add(expression);
        }

        public abstract IReadOnlyCollection<Expression<Func<T, bool>>> GetFilters();
    }
}