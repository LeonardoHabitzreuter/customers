using System.Threading.Tasks;
using Domain.Commands;
using Domain.Entities;

namespace Domain.Handlers
{
    public interface ICreateCustomerHandler
    {
        Customer CreateAsync(CreateCustomerCommand command);
    }
}