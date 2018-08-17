using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.Base;
using CrossCutting.Mediator;
using Domain.Commands;
using Domain.Entities;
using Domain.Filters;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Domain.Handlers
{
    public class CreateCustomerHandler : DomainServiceBase, ICreateCustomerHandler
    {
        private readonly ILogger<CreateCustomerHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
  
        public CreateCustomerHandler(
          ILogger<CreateCustomerHandler> logger,
          ICustomerRepository customerRepository,
          IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
      
        public Customer CreateAsync(CreateCustomerCommand command)
        {
            return new Customer("Name", null, DateTime.Now);
        }
    }
}