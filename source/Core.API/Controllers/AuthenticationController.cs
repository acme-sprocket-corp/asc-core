// <copyright file="AuthenticationController.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Core.Application.Customers.AddCustomer;
using Core.Infrastructure.Authentication.LogIn;
using Core.Infrastructure.Authentication.LogOut;
using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Attributes;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    /// <summary>
    /// Controller for all authentication based actions.
    /// </summary>
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public AuthenticationController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Adds a new customer to the application.
        /// </summary>
        /// <param name="request">An instance of <see cref="AddCustomerRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("add-customer", Name = "AddCustomer")]
        [ProducesResponseType(typeof(AddCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.CreatedResponse<AddCustomerResponse>(response => new Uri($"{response.UserName}")));
        }

        /// <summary>
        /// Checks a request against an exiting user for a logIn action.
        /// </summary>
        /// <param name="request">An instance of <see cref="LogInRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("log-in", Name = "LogIn")]
        [MediatorBuddy404ErrorResponse]
        [MediatorBuddy401ErrorResponse]
        [ProducesResponseType(typeof(LogInResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> LogIn(LogInRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.OkObjectResponse<LogInResponse>());
        }

        /// <summary>
        /// Logs a user out of the application on the server.
        /// </summary>
        /// <param name="request">An instance of <see cref="LogOutRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        [Authorize]
        [HttpPost("log-out", Name = "LogOut")]
        [MediatorBuddy404ErrorResponse]
        [MediatorBuddy500ErrorResponse]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> LogOut(LogOutRequest request)
        {
            return await ExecuteRequest(request, ResponseOptions.NoContentResponse<Unit>());
        }
    }
}
