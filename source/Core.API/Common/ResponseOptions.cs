using Core.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    public static class ResponseOptions
    {
        public static IActionResult OkResponse(ApplicationResponse applicationResponse)
        {
            return DetermineResult(applicationResponse, result => new OkObjectResult(applicationResponse));
        }

        public static IActionResult DetermineResult(ApplicationResponse applicationResponse, Func<ApplicationResponse, IActionResult> successFunc)
        {
            return applicationResponse.Status switch
            {
                Status.Success => successFunc.Invoke(applicationResponse),
                Status.ValidationError => new BadRequestObjectResult(applicationResponse),
                _ => new BadRequestResult(),
            };
        }
    }
}
