using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Filters
{
  public class CustomerFilters : FiltersBase<Customer>
  {
    public override IReadOnlyCollection<Expression<Func<Customer, bool>>> GetFilters()
    {
      return FiltersExpressions;
    }
  }
}