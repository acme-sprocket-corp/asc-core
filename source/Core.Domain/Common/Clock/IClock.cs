namespace Core.Domain.Common.Clock
{
    public interface IClock
    {
        DateTime UtcNow();
    }
}
