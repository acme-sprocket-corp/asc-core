namespace Core.Application.Common.Responses
{
    /// <inheritdoc/>
    public class Envelope<TResponse> : IEnvelope<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="response">The response for a successful operation.</param>
        public Envelope(TResponse response)
        {
            Status = ApplicationStatus.Success;
            Response = response;
            Detail = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="status">An error based status.</param>
        /// <param name="detail">Any error details from the operation.</param>
        public Envelope(ApplicationStatus status, string detail)
        {
            Response = default!;
            Status = status;
            Detail = detail;
        }

        /// <inheritdoc/>
        public TResponse Response { get; }

        /// <inheritdoc/>
        public ApplicationStatus Status { get; }

        /// <inheritdoc/>
        public string Detail { get; }

        /// <summary>
        /// Factory method for failed operation.
        /// </summary>
        /// <param name="status">The status type of the failure.</param>
        /// <param name="detail">Details on the error message.</param>
        /// <returns>An instance of an <see cref="IEnvelope{TResponse}"/>.</returns>
        public static IEnvelope<TResponse> Failure(ApplicationStatus status, string detail = "An error occurred.")
        {
            return new Envelope<TResponse>(status, detail);
        }

        /// <summary>
        /// Factory method for a successful operation.
        /// </summary>
        /// <param name="response">The response object from the operation.</param>
        /// <returns>An instance of an <see cref="IEnvelope{TResponse}"/>.</returns>
        public static IEnvelope<TResponse> Success(TResponse response)
        {
            return new Envelope<TResponse>(response);
        }
    }
}
