using Core.Application.Common.Responses;
using Core.Infrastructure.Exceptions.GlobalExceptionHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> responseFunc)
            where TResponse : ApplicationResponse
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var response = await _mediator.Send(request);

                if (response.Status == Status.Success)
                {
                    return responseFunc.Invoke(response);
                }

                return response.Status switch
                {
                    Status.ValidationError => new BadRequestObjectResult(response.ErrorMessage),
                    _ => new BadRequestResult(),
                };
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new GlobalExceptionOccurred(exception));

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
