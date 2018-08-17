using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrossCutting.Mediator
{
    public interface IDomainNotificationManager
    {
        List<DomainNotification> GetNotifications();
        Task Handle(DomainNotification notification, CancellationToken cancellationToken);
        bool HasNotifications();
    }
}