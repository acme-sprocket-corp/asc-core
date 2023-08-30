namespace Core.Domain.Common.Clock
{
    /// <summary>
    /// An interface to abstract SystemClock functions.
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Gets the current clock instance at UTC.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> at the current UTC instance.</returns>
        DateTime UtcNow();
    }
}
