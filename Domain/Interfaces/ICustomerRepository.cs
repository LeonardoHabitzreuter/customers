using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Filters;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Task<List<Customer>> GetAsync(CustomerFilters filters);
    }
}