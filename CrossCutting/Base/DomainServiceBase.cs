using System.Threading.Tasks;
using CrossCutting.Mediator;

namespace CrossCutting.Base
{
    public class DomainServiceBase
    {
        protected readonly IMediatorHandler _mediatorHandler;

        public DomainServiceBase(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected async Task NotifyValidationErrors(DtoBase message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                await _mediatorHandler.RaiseEvent(new DomainNotification(message.GetType().Name, error.ErrorMessage));
            }
        }
        protected async Task NotifyValidationErrors(params string[] messages)
        {
            foreach (var error in messages)
            {
                await _mediatorHandler.RaiseEvent(new DomainNotification(GetType().Name, error));
            }
        }
    }
}