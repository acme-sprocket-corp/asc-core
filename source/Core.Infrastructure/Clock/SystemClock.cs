using Core.Application.Common.Clock;

namespace Core.Infrastructure.Clock
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
