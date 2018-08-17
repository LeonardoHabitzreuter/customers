using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Standard.Controllers.Responses;
using CrossCutting.Mediator;
using Domain.Commands;
using Domain.Filters;
using Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Standard.Controllers
{
    [Route("v1/customers")]
    public class CustomersController : BaseController
    {
        private readonly ICreateCustomerHandler _createCustomerHandler;
        private readonly IDomainNotificationManager _notifications;

        public CustomersController(ICreateCustomerHandler createCustomerHandler, IDomainNotificationManager notifications)
          : base(notifications)
        {
            _createCustomerHandler = createCustomerHandler;
            _notifications = notifications;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCustomerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorsResponse(ModelState));
            }

            var customer = _createCustomerHandler.CreateAsync(command);
            
            if (_notifications.HasNotifications())
            {
                return BadRequest(new ErrorsResponse(_notifications.GetNotifications().Select(x => x.Value)));
            }
           
            return Ok(customer);
        }
    }
}