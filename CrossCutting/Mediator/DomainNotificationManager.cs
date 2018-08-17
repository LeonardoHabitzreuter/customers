using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace CrossCutting.Mediator
{
    public class DomainNotificationManager : IDomainNotificationManager
    {
        private readonly IDomainNotificationHandler _notifications;

        public DomainNotificationManager(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (IDomainNotificationHandler)notifications;
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications.GetNotifications();
        }

        public bool HasNotifications()
        {
            return _notifications.HasNotifications();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            return _notifications.Handle(notification, cancellationToken);
        }
    }
}