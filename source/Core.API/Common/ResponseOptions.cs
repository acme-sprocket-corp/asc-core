using Core.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    public static class ResponseOptions
    {
        public static IActionResult OkObject<T>(Envelope<T> envelope)
        {
            if (envelope.Status == Status.Success)
            {
                return new OkObjectResult(envelope.Response);
            }

            return DetermineResponse(envelope);
        }

        private static IActionResult DetermineResponse<T>(Envelope<T> envelope)
        {
            return envelope.Status switch
            {
                Status.ValidationError => new BadRequestObjectResult(envelope),
                _ => new BadRequestResult(),
            };
        }
    }
}
