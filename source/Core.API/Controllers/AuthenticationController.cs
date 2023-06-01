using Core.API.Common;
using Core.Application.Customers.AddCustomer;
using Core.Infrastructure.Authentication.LogIn;
using Core.Infrastructure.Authentication.LogOut;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status400BadRequest)]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator)
            : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("AddCustomer", Name = "AddCustomer")]
        [ProducesResponseType(typeof(AddCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest request)
        {
            return await Execute(request, ResponseOptions.OkResponse);
        }

        [AllowAnonymous]
        [HttpPost("LogIn", Name = "LogIn")]
        [ProducesResponseType(typeof(LogInResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> LogIn(LogInRequest request)
        {
            return await Execute(request, ResponseOptions.OkResponse);
        }

        [Authorize]
        [HttpPost("LogOut", Name = "LogOut")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogOut(LogOutRequest request)
        {
            return await Execute(request, ResponseOptions.OkResponse);
        }
    }
}
