using MediatR;

namespace Core.Domain.Common
{
    public interface IAggregateRoot
    {
        IEnumerable<INotification> Notifications { get; }
    }
}
