// <copyright file="BaseController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Core.Application.Common.Responses;
using Core.Infrastructure.Exceptions.GlobalExceptionHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Common
{
    /// <summary>
    /// Base controller for all controllers.
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Executes a request object and returns the appropriate response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <param name="request">A request object of type <see cref="IEnvelopeRequest{TResponse}"/>.</param>
        /// <param name="responseFunc">A call back in the event of a success.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> Execute<TResponse>(IEnvelopeRequest<TResponse> request, Func<IEnvelope<TResponse>, IActionResult> responseFunc)
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var response = await _mediator.Send(request);

                return responseFunc.Invoke(response);
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new GlobalExceptionOccurred(exception));

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Executes a request object and returns the appropriate response.
        /// </summary>
        /// <param name="request">A request object of type <see cref="IEnvelopeRequest{TResponse}"/>.</param>
        /// <param name="responseFunc">A call back in the event of a success.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> Execute(IEnvelopeRequest request, Func<IEnvelope<Unit>, IActionResult> responseFunc)
        {
            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var response = await _mediator.Send(request);

                return responseFunc.Invoke(response);
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new GlobalExceptionOccurred(exception));

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
