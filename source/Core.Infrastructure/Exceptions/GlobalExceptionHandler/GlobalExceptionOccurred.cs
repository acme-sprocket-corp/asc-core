using MediatR;

namespace Core.Infrastructure.Exceptions.GlobalExceptionHandler
{
    public class GlobalExceptionOccurred : INotification
    {
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
