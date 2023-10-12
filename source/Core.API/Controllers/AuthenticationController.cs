// <copyright file="AuthenticationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Core.API.Common;
using Core.Application.Customers.AddCustomer;
using Core.Infrastructure.Authentication.LogIn;
using Core.Infrastructure.Authentication.LogOut;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    /// <summary>
    /// Controller for all authentication based actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
    public class AuthenticationController : BaseController
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
        [HttpPost("AddCustomer", Name = "AddCustomer")]
        [ProducesResponseType(typeof(AddCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest request)
        {
            return await Execute(request, ResponseOptions.OkObjectResponse);
        }

        /// <summary>
        /// Checks a request against an exiting user for a logIn action.
        /// </summary>
        /// <param name="request">An instance of <see cref="LogInRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("LogIn", Name = "LogIn")]
        [ProducesResponseType(typeof(LogInResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> LogIn(LogInRequest request)
        {
            return await Execute(request, ResponseOptions.OkObjectResponse);
        }

        /// <summary>
        /// Logs a user out of the application on the server.
        /// </summary>
        /// <param name="request">An instance of <see cref="LogOutRequest"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IActionResult"/> representing the asynchronous operation.</returns>
        [Authorize]
        [HttpPost("LogOut", Name = "LogOut")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogOut(LogOutRequest request)
        {
            return await Execute(request, ResponseOptions.OkObjectResponse);
        }
    }
}
