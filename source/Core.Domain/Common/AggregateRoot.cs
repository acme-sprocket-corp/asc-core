using MediatR;

namespace Core.Domain.Common
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        private readonly List<INotification> _notifications;

        protected AggregateRoot()
        {
            _notifications = new List<INotification>();
        }

        public IEnumerable<INotification> Notifications => _notifications.AsEnumerable();

        protected void AddNotification(INotification notification)
        {
            _notifications.Add(notification);
        }
    }
}
