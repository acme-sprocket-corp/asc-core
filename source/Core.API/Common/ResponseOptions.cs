using Core.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    /// <summary>
    /// Response callbacks for API actions.
    /// </summary>
    public static class ResponseOptions
    {
        /// <summary>
        /// Returns an <see cref="OkObjectResult"/> on success.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="applicationResponse">The <see cref="IEnvelope{TResponse}"/> from the operation.</param>
        /// <returns>An <see cref="IActionResult"/> of type <see cref="OkObjectResult"/>.</returns>
        public static IActionResult OkObjectResponse<TResponse>(IEnvelope<TResponse> applicationResponse)
        {
            return DetermineResult(applicationResponse, new OkObjectResult(applicationResponse.Response));
        }

        /// <summary>
        /// Switch statement to determine what response to return.
        /// </summary>
        /// <typeparam name="TResponse">The desired success response.</typeparam>
        /// <param name="envelope">The <see cref="IEnvelope{TResponse}"/> from the operation.</param>
        /// <param name="successResult">THe response to return in the event of a successful operation.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        public static IActionResult DetermineResult<TResponse>(IEnvelope<TResponse> envelope, IActionResult successResult)
        {
            return envelope.Status switch
            {
                ApplicationStatus.Success => successResult,
                ApplicationStatus.ValidationError => new BadRequestObjectResult(envelope.Detail),
                _ => new BadRequestResult(),
            };
        }
    }
}
