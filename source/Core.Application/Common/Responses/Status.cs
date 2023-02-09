namespace Core.Application.Common.Responses
{
    public enum Status
    {
        /// <summary>
        /// Request succeeded.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Entity did not meet validation requirements.
        /// </summary>
        ValidationError = 1,
    }
}
