using Core.Domain.Common.Clock;

namespace Core.Infrastructure.Clock
{
    /// <inheritdoc />
    public class SystemClock : IClock
    {
        /// <inheritdoc/>
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
