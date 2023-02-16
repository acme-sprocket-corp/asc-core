using Core.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    public static class ResponseOptions
    {
        public static IActionResult OkResponse(ApplicationResponse applicationResponse)
        {
            return new OkObjectResult(envelope.Response);
        }
                return new OkObjectResult(envelope.Response);
        public static CreatedResult Created<T>(Envelope<T> envelope)
            where T : new()
        {
            return new CreatedResult(string.Empty, envelope.Response);
        }

        private static IActionResult DetermineResponse<T>(Envelope<T> envelope, Func<Envelope<T>, IActionResult> responseFunc)
            where T : new()
        public static IActionResult Created<T>(Envelope<T> envelope)
            if (envelope.Status == Status.Success)
            {
                return responseFunc.Invoke(envelope);
            }

            return envelope.Status switch
        {
            return envelope.Status switch
            {
                Status.Success => successFunc.Invoke(applicationResponse),
                Status.ValidationError => new BadRequestObjectResult(applicationResponse),
                _ => new BadRequestResult(),
            };
        }
    }
}
