using Core.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    public static class ResponseOptions
    {
        public static IActionResult OkResponse(ApplicationResponse applicationResponse)
        {
            return DetermineResult(applicationResponse, new OkObjectResult(applicationResponse));
        }

        public static IActionResult DetermineResult(ApplicationResponse applicationResponse, IActionResult successResult)
        {
            return applicationResponse.Status switch
            {
                Status.Success => successResult,
                Status.ValidationError => new BadRequestObjectResult(applicationResponse),
                _ => new BadRequestResult(),
            };
        }
    }
}
